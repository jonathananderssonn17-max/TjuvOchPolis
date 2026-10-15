using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    internal class Item
    {
        public string Name { get; set; }
        public Item (string name) {  Name = name;}

        public List<string> Beslagtaget { get; set; }

        public List<string> Stöldgods { get; set; }
        public List<string> Tillhörigheter { get; set; }
        
    }
    class Stöldgods()
    {

    }
    class Beslagtaget()
    {

    }

    class Tillhörigheter()
    {

    }
}
