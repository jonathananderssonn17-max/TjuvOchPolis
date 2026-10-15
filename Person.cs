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
       
        public Person(string name, int x, int y, int xdirection, int ydirection)
        {
            Name = name;
            X = x;
            Y = y;
            Xdirection = xdirection;
            Ydirection = ydirection;
        }

    }
    class Thief :Person
    {
        public Thief(string name, int x, int y, int xdirection, int ydirection) : base(name, x, y, xdirection, ydirection)
        {

        }
    }
    class Police : Person
    {
        public Police(string name, int x, int y, int xdirection, int ydirection) : base(name, x, y, xdirection, ydirection)
        {

        }

    }
    class Citizen : Person
    {
        public Citizen(string name, int x, int y, int xdirection, int ydirection) : base(name, x, y, xdirection, ydirection)
        {

        }
    }
}
