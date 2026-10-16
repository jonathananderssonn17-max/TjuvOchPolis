using System.Drawing;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Thief> thiefs = new List<Thief>();
            List<Police> polices = new List<Police>();
            List<Citizen> citizens = new List<Citizen>();

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

            for (int i = 0; i < 6; i++)
            {
                int x = Random.Shared.Next(1, 99);
                int y = Random.Shared.Next(1, 24);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Thief name = new Thief(names[rnd], x, y, xDir, yDir, 'T', ConsoleColor.Red);
                thiefs.Add(name);
            }

            for (int i = 0; i < 10; i++)
            {
                int x = Random.Shared.Next(1, 100);
                int y = Random.Shared.Next(1, 25);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Police name = new Police(names[rnd], x, y, xDir, yDir, 'P', ConsoleColor.Blue);
                polices.Add(name);
            }

            for (int i = 0; i < 20; i++)
            {
                int x = Random.Shared.Next(1, 100);
                int y = Random.Shared.Next(1, 25);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Citizen name = new Citizen(names[rnd], x, y, xDir, yDir, 'C', ConsoleColor.Green);
                citizens.Add(name);
            }
            foreach (Thief thief in thiefs)
            {
                Console.WriteLine(thief.Name + ":" + thief.X + ":" + thief.Y + ":");
                //foreach (Item item in citizen.Tillhörigheter)
                //{
                //    Console.WriteLine(item.Name);
                //}
            }
            Console.WriteLine();
            //foreach (Citizen citizen in citizens)
            //{
            //    Console.WriteLine(citizen.Name + ":" + citizen.X + ":" + citizen.Y + ":");
            //    foreach (Item item in citizen.Tillhörigheter)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}
            //Console.WriteLine();


            //Ritar staden
            char[,] city = new char[25, 100];

            for (int y = 0; y < city.GetLength(0); y++)
            {

                for (int x = 0; x < city.GetLength(1); x++)
                {
                    char symbol = ' ';
                    ConsoleColor color = ConsoleColor.Gray;

                    if (y == 0 || y == city.GetLength(0) - 1 || x == 0 || x == city.GetLength(1) - 1)
                    {
                        symbol = 'X';
                        Console.Write(city[y, x]);
                    }
                    
                    else
                    {
                        foreach (Thief thief in thiefs)
                        {
                            if (thief.X == x && thief.Y == y)
                            {
                                
                                symbol = thief.Symbol;
                                color = thief.Color;

                                
                            }
                        }
                    }
                    city[y, x] = symbol;
                    Console.ForegroundColor = color;
                    Console.Write(city[y, x]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            //else if(thiefs[0].Y == y && thiefs[0].X == i)
            //{

            //    city[i, y] = thiefs[0].Symbol;
            //    Console.ForegroundColor = thiefs[0].Color;
            //    Console.Write(city[i, y]);
            //    Console.ResetColor();
            //    Console.Write(thiefs[0].Symbol);
            //}
        }
    }

}



