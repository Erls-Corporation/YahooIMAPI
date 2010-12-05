using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using Dynamic.Json;
using Dynamic.Duck;
using Newtonsoft.Json.Linq;

namespace DynamicJsonSample
{
    public interface IUser
    {
        string Username { get; set; }
    }

    static class Sample
    {
        public static void Main()
        {
            string json = @"{  ""Username"": ""atucker"",  ""Expiration"": new Date(1230422400000),  ""AccessRights"": [    ""Search"",    ""Edit"",    ""Add""  ]}";

            JObject jo = JObject.Parse(json);
            dynamic user = jo.AsDynamic();

            // Loop through dynamic list of access rights
            foreach (var size in user.AccessRights)
            {
                if (size != null)
                    Console.WriteLine(size);
            }

            user.FullName = "Adam Tucker";

            Console.WriteLine(jo.ToString());

            // Use Dynamic Duck to use our dynamic JSON via a static interface
            AddUser(DynamicDuck.AsIf<IUser>(user));

            Console.ReadLine();
        }

        public static void AddUser(IUser user)
        {
            Console.WriteLine("Adding user {0}", user.Username);
        }


    }


}
