
/*
 *
 *Software Copyright License Agreement (BSD License)
 *
 *Copyright (c) 2010, Yahoo! Inc.
 *All rights reserved.
 *
 *  Redistribution and use of this software in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
 *
 ** Redistributions of source code must retain the above
 *  copyright notice, this list of conditions and the
 *  following disclaimer.
 *
 ** Redistributions in binary form must reproduce the above
 *  copyright notice, this list of conditions and the
 *  following disclaimer in the documentation and/or other
 *  materials provided with the distribution.
 *
 ** Neither the name of Yahoo! Inc. nor the names of its
 *  contributors may be used to endorse or promote products
 *  derived from this software without specific prior
 *  written permission of Yahoo! Inc.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 Note
 *  This class is converted from http://github.com/yahoo/messenger-sdk-php
 *  This class is written by haughtycool@yahoo.com. If you use this code, please do not remove this line :D.
 *  I'm a poor person, please help me less poor by your thanks :D
 *  This class contains some basic funtion, please continue to develope

 *  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Dynamic.Json;
using Dynamic.Duck;

namespace YahooIMAPI
{



    public class YMEngine
    {
        const string URL_OAUTH_DIRECT = "https://login.yahoo.com/WSLogin/V1/get_auth_token";
        const string URL_OAUTH_ACCESS_TOKEN = "https://api.login.yahoo.com/oauth/v2/get_token";
        const string URL_YM_SESSION = "http://developer.messenger.yahooapis.com/v1/session";
        const string URL_YM_PRESENCE = "http://developer.messenger.yahooapis.com/v1/presence";
        const string URL_YM_CONTACT = "http://developer.messenger.yahooapis.com/v1/contacts";
        const string URL_YM_MESSAGE = "http://developer.messenger.yahooapis.com/v1/message/yahoo/{{USER}}";
        const string URL_YM_NOTIFICATION = "http://developer.messenger.yahooapis.com/v1/notifications";
        const string URL_YM_NOTIFICATION_LONG = "http://{{NOTIFICATION_SERVER}}/v1/pushchannel/{{USER}}";
        const string URL_YM_BUDDYREQUEST = "http://developer.messenger.yahooapis.com/v1/buddyrequest/yahoo/{{USER}}";
        const string URL_YM_GROUP = "http://developer.messenger.yahooapis.com/v1/group/{{GROUP}}/contact/yahoo/{{USER}}";

        protected string _requestToken = "";
        protected Dictionary<string, string> _accessToken = new Dictionary<string, string>();
        dynamic _signonData = null;
        protected Dictionary<string, string> _config = new Dictionary<string, string>();
        protected string _error;
        protected SmartWebClient _webClient = new SmartWebClient();

        public bool IsDebug = false;

        /*
         * constructor
         */
        public YMEngine(string consumerKey = "", string secretKey = "", string username = "", string password = "")
        {
            this._config["consumer_key"] = consumerKey;
            this._config["secret_key"] = secretKey;
            this._config["username"] = username;
            this._config["password"] = password;

            this._error = "";
            this._webClient.Headers = new WebHeaderCollection();

        }

        #region Private Method
        /// <summary>
        /// Request token
        /// This function is tested by haughtycool
        /// </summary>
        /// <returns></returns>
        protected bool GetRequestToken()
        {
            //prepare url
            string url = URL_OAUTH_DIRECT;
            url += "?login=" + this._config["username"];
            url += "&passwd=" + this._config["password"];
            url += "&oauth_consumer_key=" + this._config["consumer_key"];

            _webClient.JSONContent = false;
            string result = _webClient.DownloadString(url);

            if (result.IndexOf("RequestToken=") < 0)
            {
                _error = "Failed to request token";
                return false;
            }

            try
            {
                this._requestToken = result.Replace("RequestToken=", "").Trim(); ;
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// Register access token
        /// This function is tested by haughtycool
        /// </summary>
        /// <returns></returns>
        protected bool RegisterAccessToken()
        {
            //prepare url
            string url = URL_OAUTH_ACCESS_TOKEN;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26";
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + this._requestToken;
            url += "&oauth_version=1.0";

            _webClient.JSONContent = false;
            try
            {
                string result = _webClient.DownloadString(url);
                result = result.Trim();
                if (result.IndexOf("oauth_token") < 0)
                {
                    this._error = result;
                    return false;
                }

                //parse access token
                string[] tmp = result.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string row in tmp)
                {
                    string[] col = row.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (col.Length >= 2) _accessToken[col[0]] = col[1];
                }
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// Login with user name and password
        /// This function is tested by haughtycool
        /// </summary>
        /// <param name="status">Presence status</param>
        /// <param name="state">Status (invisible, available, ..) please see the YM API document</param>
        /// <returns></returns>
        protected bool Login(string status = "", int state = 0)
        {
            //prepare url
            string url = URL_YM_SESSION;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid() + ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&notifyServerToken=1";

            string postdata = string.Format("{{\"presenceState\" : {0}, \"presenceMessage\" : \"{1}\"}}", state, status);

            //additional header
            _webClient.JSONContent = true;
            try
            {
                string result = _webClient.UploadString(url, postdata);
                if (result.IndexOf("sessionId") < 0) return false;
                _signonData = JObject.Parse(result).AsDynamic();
            }
            catch { return false; }

            return true;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Request token
        /// Register access token
        /// Sign on
        /// This function is tested by haughtycool
        /// </summary>
        /// <param name="status">Presence status</param>
        /// <param name="state">Status (invisible, available, ..) please see the YM API document</param>
        /// <returns></returns>
        public bool SignOn(string status = "", int state = 0)
        {
            if (!GetRequestToken()) return false;
            if (!RegisterAccessToken()) return false;

            return Login(status, state);
        }
        /// <summary>
        /// Sign off
        /// Un register token
        /// This function is tested by haughtycool
        /// </summary>
        /// <returns></returns>
        public bool SignOff()
        {

            //prepare url
            string url = URL_YM_SESSION;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&sid=" + _signonData.sessionId;

            //additional header
            _webClient.JSONContent = true;
            try
            {
                _webClient.UploadString(url, "DELETE", "");
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// Change presence status
        /// This function is tested by haughtycool
        /// </summary>
        /// <param name="status">Presence status</param>
        /// <param name="state">Status (invisible, available, ..) please see the YM API document</param>
        /// <returns></returns>
        public bool ChangePresence(string status = "", int state = 0)
        {
            //prepare url
            string url = URL_YM_PRESENCE;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&sid=" + _signonData.sessionId;

            string postdata = string.Format("{{\"presenceState\" : {0}, \"presenceMessage\" : \"{1}\"}}", state, status);
            //additional header
            _webClient.JSONContent = true;
            try
            {
                _webClient.UploadString(url, "PUT", postdata);
            }
            catch { return false; }

            return true;
        }
        /// <summary>
        /// Send message to other user
        /// This function is tested by haughtycool
        /// </summary>
        /// <param name="user">yahoo nick</param>
        /// <param name="message">message which will be sent</param>
        /// <returns></returns>
        public bool SendMessage(string user, string message)
        {
            //prepare url
            string url = URL_YM_MESSAGE;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&sid=" + _signonData.sessionId;
            url = url.Replace("{{USER}}", user);

            //additional header
            message = GetUnicodeEscape(message);
            string postdata = string.Format("{{\"message\" : \"{0}\"}}", message);

            _webClient.JSONContent = true;
            try
            {
                string result=_webClient.UploadString(url, postdata);
            
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// Get contact list
        /// This function is tested by haughtycool
        /// </summary>
        /// <returns>
        /// I has not read Yahoo IM API, so I don't know what will be returned :D
        /// </returns>
        public Contact[] GetContactList()
        {
            //prepare url
            string url = URL_YM_CONTACT;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&sid=" + _signonData.sessionId;
            url += "&fields=%2Bpresence";
            url += "&fields=%2Bgroups";

            //additional header
            _webClient.JSONContent = true;
            try
            {
                string result = _webClient.DownloadString(url);
                ContactList contactList = JsonConvert.DeserializeObject<ContactList>(result);
                return contactList.contacts;
            }
            catch { return new Contact[0]; }
        }

        /// <summary>
        /// Add new contact
        /// This function is tested by haughtycool
        /// </summary>
        /// <param name="user">Yahoo nick</param>
        /// <param name="group">Group name</param>
        /// <param name="message">Invitation message</param>
        /// <returns></returns>
        public bool AddContact(string user, string group = "Friends", string message = "")
        {
            //prepare url
            string url = URL_YM_GROUP;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&sid=" + _signonData.sessionId;
            url = url.Replace("{{GROUP}}", group);
            url = url.Replace("{{USER}}", user);

            //additional header            
            string postdata = string.Format("{{\"message\" : \"{0}\"}}", message);

            _webClient.JSONContent = true;
            try
            {
                _webClient.UploadString(url, "PUT", postdata);
            }
            catch { return false; }

            return true;
        }
        /// <summary>
        /// Delete contact
        /// This function is tested by haughtycool
        /// </summary>
        /// <param name="user">Yahoo nick</param>
        /// <param name="group">Group name</param>
        /// <returns></returns>
        public bool DeleteContact(string user, string group = "Friends")
        {
            //prepare url
            string url = URL_YM_GROUP;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&sid=" + _signonData.sessionId;
            url = url.Replace("{{GROUP}}", group);
            url = url.Replace("{{USER}}", user);


            //additional header
            _webClient.JSONContent = true;
            try
            {
                _webClient.UploadString(url, "DELETE", "");
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// Respnse invitation request
        /// This function is tested by haughtycool
        /// </summary>
        /// <param name="user">Yahoo nick</param>
        /// <param name="accept">Accept or deny</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public bool ResponseContact(string user, bool accept = true, string message = "")
        {
            string method = accept ? "POST" : "DELETE";
            string reason = message;
            if (message.Length == 0) reason = accept ? "Welcome" : "No thanks";

            //prepare url
            string url = URL_YM_BUDDYREQUEST;
            url += "?oauth_consumer_key=" + this._config["consumer_key"];
            url += "&oauth_nonce=" + System.Guid.NewGuid().ToString();
            url += "&oauth_signature=" + this._config["secret_key"] + "%26" + _accessToken["oauth_token_secret"];
            url += "&oauth_signature_method=PLAINTEXT";
            url += "&oauth_timestamp=" + DateTime.Now.Ticks.ToString();
            url += "&oauth_token=" + _accessToken["oauth_token"];
            url += "&oauth_version=1.0";
            url += "&sid=" + _signonData.sessionId;
            url = url.Replace("{{USER}}", user);

            string postdata = string.Format("{{\"authReason\" : \"{0}\"}}", reason);

            //additional header
            _webClient.JSONContent = true;
            try
            {
                _webClient.UploadString(url, method, postdata);
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Get last error message
        /// </summary>
        /// <returns></returns>
        public string GetLastError()
        {
            return this._error;
        }
        #endregion


        #region Utility

        private string GetUnicodeEscape(string value)
        {
            var sb = new StringBuilder();
            foreach (var c in value)
            {
                if (c <= 0x7f)
                    sb.Append(c);
                else
                {
                    int intValue = Convert.ToInt32(c);
                    string escape = intValue.ToString("x2");
                    for (int i = escape.Length; i < 4; i++)
                    {
                        escape = "0" + escape;
                    }

                    sb.Append("\\u" + escape);
                }
            }
            return sb.ToString();
        }
        #endregion

    }
}

