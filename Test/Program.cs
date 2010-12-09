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

        const string CONSUMERKEY = "dj0yJmk9RkNyckRCTWI5MjY1JmQ9WVdrOVJGRnRVbXd5TlRnbWNHbzlNVEU0T1RZeU9UYzJNZy0tJnM9Y29uc3VtZXJzZWNyZXQmeD1lZA--";
        const string SECRETKEY = "4043ea6ae761316491ac19ea977f589b0cf08fb6";
        const string USER_NAME = "vietinfo681";
        const string PASSWORD = "456789!";

        static void Main(string[] args)
        {
            YMEngine engine = new YMEngine(CONSUMERKEY, SECRETKEY, USER_NAME, PASSWORD);
            engine.SignOn("Test status from C#");

            //engine.SendMessage("vhtuan81", "Ban muon lam giau? Ban muon tim ban, tim nguoi yeu, tim mot nua cua doi minh? Ban muon tim ban tam su moi van de trong cuoc song? Muon lam quen voi ban be khap noi tren ca nuoc va toan the gioi? Dang tin MUA BAN nhanh chong, chinh xac? Hay den voi chung toi http://VietInfo68.com");

            Test.EmailListEntities _entities = new Test.EmailListEntities();
            var data = from a in _entities.People where a.YahooNick != "" select a;
            foreach (var item in data)
            {
                engine.SendMessage(item.YahooNick, "Ban muon lam giau? Ban muon tim ban, tim nguoi yeu, tim mot nua cua doi minh? Ban muon tim ban tam su moi van de trong cuoc song? Muon lam quen voi ban be khap noi tren ca nuoc va toan the gioi? Dang tin MUA BAN nhanh chong, chinh xac? Hay den voi chung toi http://VietInfo68.com");
            }

            //Test.AdvServicesEntities _entities = new Test.AdvServicesEntities();
            ////var data = from a in _entities.emails where a.Type==1 orderby a.Id ascending select a;
            //var data = from a in _entities.emails where a.Type == 1 select a;
            //foreach (var item in data)
            //{
            //    var pp = item.YahooNick;
            //    //engine.SendMessage(item.YahooNick, "Test message from C# 123 test");
            //}

            //engine.SendMessage("vhtuan81", "Test message from C# 123 test");
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
