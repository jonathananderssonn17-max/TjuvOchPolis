using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    internal class Person
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Xdirection { get; set; }
        public int Ydirection { get; set; }
        public List<Item> Inventory { get; set;}

        public Person(string name, int x, int y, int xdirection, int ydirection)
        {
            Name = name;
            X = x;
            Y = y;
            Xdirection = xdirection;
            Ydirection = ydirection;
            Inventory = new List <Item>();
        }

    }
    class Thief :Person
        
    {
        public List<Item> Stöldgods { get; set; } = new List<Item>();
        public Thief(string name, int x, int y, int xdirection, int ydirection) : base(name, x, y, xdirection, ydirection)
        {

        }
    }
    class Police : Person
       
    {
        public List<Item> Beslagtaget { get; set; } = new List<Item>();
        public Police(string name, int x, int y, int xdirection, int ydirection) : base(name, x, y, xdirection, ydirection)
        {

        }

    }
    class Citizen : Person
    {
        public List<Item> Tillhörigheter { get; set; } = new List<Item>();
       
        public Citizen(string name, int x, int y, int xdirection, int ydirection) : base(name, x, y, xdirection, ydirection)

        {
            Tillhörigheter.Add(new Item("keys"));
            Tillhörigheter.Add(new Item("wallet"));
            Tillhörigheter.Add(new Item("mobile"));
            Tillhörigheter.Add(new Item("watch"));

        }
    }
}
