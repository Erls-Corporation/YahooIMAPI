using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace YahooIMAPI
{
    public class SmartWebClient : WebClient
    {
        private CookieContainer cookieContainer = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = cookieContainer;
            }
            return request;
        }


        public bool JSONContent
        {
            set
            {
                if (value)
                {
                    this.Headers.Add("Content-type", "application/json");
                    this.Headers.Add("charset", "utf-8");
                }
                else
                {
                    this.Headers.Remove("Content-type");
                    this.Headers.Remove("charset");
                }
            }
        }

    }
}
