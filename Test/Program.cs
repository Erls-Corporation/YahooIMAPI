using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YahooIMAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Dynamic.Json;
using Dynamic.Duck;
using System.Data.Objects;

namespace Test
{
    class Program
    {
        const string CONSUMERKEY = "dj0yJmk9bHB2RU1KRHFNWHppJmQ9WVdrOVNrdG9jbTlCTkdzbWNHbzlNek14T0RNMk5UWXkmcz1jb25zdW1lcnNlY3JldCZ4PTM5";
        const string SECRETKEY = "2cc31a795381ed7280a9981d0f6fbb70fefe8dfb";
        const string USER_NAME = "monalisatl88";
        const string PASSWORD = "snowstorm";

        static void Main(string[] args)
        {
            YMEngine engine = new YMEngine(CONSUMERKEY, SECRETKEY, USER_NAME, PASSWORD);
            engine.SignOn("Test status from C#");

            engine.SendMessage("vhtuan81", "Ban muốn làm giảu không lam giau. Tin nhắn gửi từ C# nè anh tuấn?");
            //engine.SendMessage("vhtuan81", "Ban muon lam giau?");
            

            //engine.SendMessage("someonenick", "Test message from C#");
            //engine.ChangePresence("Test presence");
            //Contact[] contactList=engine.GetContactList();
            //engine.AddContact("someonenick");
            //engine.DeleteContact("someonenick");
            //engine.ResponseContact("someonenick", false, "I don't know who you are");

            Console.WriteLine("Finished! Press enter key to terminate!");
            Console.ReadLine();
            engine.SignOff();
        }
    }
}
