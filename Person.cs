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
        public List<Item> Inventory { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public Person(string name, int x, int y, int xdirection, int ydirection, char symbol, ConsoleColor color)
        {
            Name = name;
            X = x;
            Y = y;
            Xdirection = xdirection;
            Ydirection = ydirection;
            Inventory = new List<Item>();
            Symbol = symbol;
            Color = color;
        }

        // skapar personerna och dess värden och lägger till dem i listorna
        public static void CreatePeople(List<Thief> thiefs, List<Police> polices, List<Citizen> citizens, string[] names)
        {

            for (int i = 0; i < 25; i++)
            {
                int x = Random.Shared.Next(1, 99);
                int y = Random.Shared.Next(1, 24);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Thief name = new Thief(names[rnd], x, y, xDir, yDir, 'T', ConsoleColor.Red);
                thiefs.Add(name);
            }

            for (int i = 0; i < 20; i++)
            {
                int x = Random.Shared.Next(1, 99);
                int y = Random.Shared.Next(1, 24);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Police name = new Police(names[rnd], x, y, xDir, yDir, 'P', ConsoleColor.Blue);
                polices.Add(name);
            }

            for (int i = 0; i < 30; i++)
            {
                int x = Random.Shared.Next(1, 99);
                int y = Random.Shared.Next(1, 24);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Citizen name = new Citizen(names[rnd], x, y, xDir, yDir, 'C', ConsoleColor.Green);
                citizens.Add(name);
            }
        }

        public static void AddThief(List<Thief> thiefs, string[] names, Queue<string> info)
        {
            int x = Random.Shared.Next(1, 99);
            int y = Random.Shared.Next(1, 24);
            int xDir = Random.Shared.Next(-1, 2);
            int yDir = Random.Shared.Next(-1, 2);
            int rnd = Random.Shared.Next(0, names.Length);

            Thief thief = new Thief(names[rnd], x, y, xDir, yDir, 'T', ConsoleColor.Red);
            thiefs.Add(thief);

            City.counter++;
            info.Enqueue(City.counter + ": Tjuven " + thief.Name + " flyttade in i staden!");
        }

        public static void AddPolice(List<Police> polices, string[] names, Queue<string> info)
        {
            int x = Random.Shared.Next(1, 99);
            int y = Random.Shared.Next(1, 24);
            int xDir = Random.Shared.Next(-1, 2);
            int yDir = Random.Shared.Next(-1, 2);
            int rnd = Random.Shared.Next(0, names.Length);

            Police police = new Police(names[rnd], x, y, xDir, yDir, 'P', ConsoleColor.Blue);
            polices.Add(police);

            City.counter++;
            info.Enqueue(City.counter + ": Polisen " + police.Name + " flyttade in i staden!");
        }

        public static void AddCitizen(List<Citizen> citizens, string[] names, Queue<string> info)
        {
            int x = Random.Shared.Next(1, 99);
            int y = Random.Shared.Next(1, 24);
            int xDir = Random.Shared.Next(-1, 2);
            int yDir = Random.Shared.Next(-1, 2);
            int rnd = Random.Shared.Next(0, names.Length);

            Citizen citizen = new Citizen(names[rnd], x, y, xDir, yDir, 'C', ConsoleColor.Green);
            citizens.Add(citizen);

            City.counter++;
            info.Enqueue(City.counter + ": Medborgaren " + citizen.Name + " flyttade in i staden!");
        }
    }

    class Thief : Person
    {
        public List<Item> Stöldgods { get; set; } = new List<Item>();
        public DateTime ReleaseTime { get; set; } 
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
            Tillhörigheter.Add(new Item("nycklar"));
            Tillhörigheter.Add(new Item("plånbok"));
            Tillhörigheter.Add(new Item("mobil"));
            Tillhörigheter.Add(new Item("klocka"));
        }
    } 
}
