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
        public static void CreatePeople(List<Thief> thiefs, List<Police> polices, List<Citizen> citizens)
        {
            string[] names =
            {
            "John", "Jane", "Joe",
            "Alice", "Bob", "Charlie",
            "Anna", "David", "Eve",
            "Sofia", "Grace", "Henry",
            "Liam", "Olivia", "Noah",
            "Emma", "Ava", "Isabella",
            "Mia", "Charlotte", "Amelia",
            "Harper", "Evelyn", "Abigail",
            "Ella", "Scarlett", "Victoria",
            "Aria", "Luna", "Aurora"
            };

            for (int i = 0; i < 10; i++)
            {
                int x = Random.Shared.Next(1, 99);
                int y = Random.Shared.Next(1, 24);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Thief name = new Thief(names[rnd], x, y, xDir, yDir, 'T', ConsoleColor.Red);
                thiefs.Add(name);
            }

            for (int i = 0; i < 6; i++)
            {
                int x = Random.Shared.Next(1, 99);
                int y = Random.Shared.Next(1, 24);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Police name = new Police(names[rnd], x, y, xDir, yDir, 'P', ConsoleColor.Blue);
                polices.Add(name);
            }

            for (int i = 0; i < 20; i++)
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
    }

    class Thief : Person
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
