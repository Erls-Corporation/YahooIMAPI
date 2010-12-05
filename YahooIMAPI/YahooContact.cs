using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooIMAPI
{

    public struct ContactList
    {
        public Contact[] contacts;
    }

    public struct Contact
    {
        public string id;
        public string uri;
        public Presence presence;
        public Group[] groups;
    }

    public struct Presence
    {
        public int presenceState;
    }

    public struct Group
    {
        public string group;
        public string name;
        public string uri;
    }
     
}
