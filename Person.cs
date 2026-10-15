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
        public List<string> Inventory { get; set; } 
        public Person(string name, int x, int y, int xdirection, int ydirection, List<string> inventory)
        {
            Name = name;
            X = x;
            Y = y;
            Xdirection = xdirection;
            Ydirection = ydirection;
            Inventory = new List<string>(inventory);

        }

    }
    class Thief :Person
    {
        public Thief(string name, int x, int y, int xdirection, int ydirection, List<string> inventory) : base(name, x, y, xdirection, ydirection, inventory)
        {

        }
    }
    class Police : Person
    {
        public Police(string name, int x, int y, int xdirection, int ydirection, List<string> inventory) : base(name, x, y, xdirection, ydirection, inventory)
        {
        }

    }
    class Citizen : Person
    {
        public Citizen(string name, int x, int y, int xdirection, int ydirection, List<string> inventory) : base(name, x, y, xdirection, ydirection, inventory)
        {
        }
    }
}
