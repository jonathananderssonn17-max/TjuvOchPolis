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
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public Person(string name, int x, int y, int xdirection, int ydirection, char symbol, ConsoleColor color)
        {
            Name = name;
            X = x;
            Y = y;
            Xdirection = xdirection;
            Ydirection = ydirection;
            Inventory = new List <Item>();
            Symbol = symbol;
            Color = color;
        }

    }
    class Thief :Person
        
    {
        public List<Item> Stöldgods { get; set; } = new List<Item>();
        public Thief(string name, int x, int y, int xdirection, int ydirection, char symbol, ConsoleColor color) : base(name, x, y, xdirection, ydirection, symbol, color)
        {
            
        }
    }
    class Police : Person
       
    {
        public List<Item> Beslagtaget { get; set; } = new List<Item>();
        public Police(string name, int x, int y, int xdirection, int ydirection, char symbol, ConsoleColor color) : base(name, x, y, xdirection, ydirection, symbol, color)
        {
            
        }

    }
    class Citizen : Person
    {
        public List<Item> Tillhörigheter { get; set; } = new List<Item>();
       
        public Citizen(string name, int x, int y, int xdirection, int ydirection, char symbol, ConsoleColor color) : base(name, x, y, xdirection, ydirection, symbol, color)

        {
            
            Tillhörigheter.Add(new Item("keys"));
            Tillhörigheter.Add(new Item("wallet"));
            Tillhörigheter.Add(new Item("mobile"));
            Tillhörigheter.Add(new Item("watch"));

        }
    }
}
