using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YahooIMAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Dynamic.Json;
using Dynamic.Duck;

namespace Test
{
    class Program
    {

        const string CONSUMERKEY = "dj0yJmk9RkNyckRCTWI5MjY1JmQ9WVdrOVJGRnRVbXd5TlRnbWNHbzlNVEU0T1RZeU9UYzJNZy0tJnM9Y29uc3VtZXJzZWNyZXQmeD1lZA--";
        const string SECRETKEY = "4043ea6ae761316491ac19ea977f589b0cf08fb6";
        const string USER_NAME = "yournick";
        const string PASSWORD = "yourpassword";

        static void Main(string[] args)
        {
            

            YMEngine engine = new YMEngine(CONSUMERKEY, SECRETKEY, USER_NAME, PASSWORD);
            engine.SignOn("Test status from C#");
            //engine.SendMessage("someonenick", "Test message from C#");
            //engine.ChangePresence("Test presence");
            //Contact[] contactList=engine.GetContactList();
            //engine.AddContact("someonenick");
            //engine.DeleteContact("someonenick");
            engine.ResponseContact("someonenick", false, "I don't know who you are");
            Console.WriteLine("Press enter key to terminate");
            Console.ReadLine();
            engine.SignOff();

        }
    }
}
