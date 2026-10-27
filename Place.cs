using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TjuvOchPolis
{
    internal class Place
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char[,] Map { get; set; }

        public Place(int x, int y, char[,] map)
        {
            X = x;
            Y = y;
            Map = map;
        }
    }
    class Prison : Place
    {
        public List<Thief> ArrestedThiefs { get; set; }
        public Prison(List<Thief> arrestedThiefs, int x, int y, char[,] map) : base(x, y, map)
        {
            ArrestedThiefs = arrestedThiefs;
        }
        public void DrawPrison(List<Thief> arrestedThiefs, List<Thief> thiefs)
        {
            
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    char symbol = ' ';
                    ConsoleColor color = ConsoleColor.Gray;


                    if (y == 0 || y == Map.GetLength(0) - 1 || x == 0 || x == Map.GetLength(1) - 1)
                    {
                        symbol = 'X';
                        
                    }

                    else
                    {
                        foreach (Thief thief in ArrestedThiefs)
                        {
                            if (thief.X == x && thief.Y == y)
                            {
                                symbol = thief.Symbol;
                                color = thief.Color;
                            }
                        }
                    }
                    Map[y, x] = symbol;
                    Console.ForegroundColor = color;
                    Console.Write(Map[y, x]);
                    Console.ResetColor();
                }
                Console.WriteLine();

         
           
            }
            Timer(arrestedThiefs, thiefs);
        }
        public static void MoveThiefs(List<Thief> arrestedThiefs)
        {
            foreach (Thief thief in arrestedThiefs)
            {
                thief.X += thief.Xdirection;
                thief.Y += thief.Ydirection;

                if (thief.X > 9)
                {
                    thief.X = 1;
                }

                else if (thief.X < 1)
                {
                    thief.X = 9;
                }

                if (thief.Y > 9)
                {
                    thief.Y = 1;
                }

                else if (thief.Y < 1)
                {
                    thief.Y = 9;
                }
            }

        }
        public static void Timer(List<Thief> arrestedThiefs, List<Thief> thiefs)
        {
          
           for (int i= 0; 0 <arrestedThiefs.Count; i++)
            {
                if (DateTime.Now >= arrestedThiefs[i].ReleaseTime)
                {
                    arrestedThiefs[i].X = Random.Shared.Next(1, 99);
                    int y = Random.Shared.Next(1, 24);
                    int xDir = Random.Shared.Next(-1, 2);
                    int yDir = Random.Shared.Next(-1, 2);
                    int rnd = Random.Shared.Next(0, names.Length);
                    thiefs.Add(arrestedThiefs[i]);
                    arrestedThiefs.RemoveAt(i);
                }
            }

           
           
        }
    }
}

