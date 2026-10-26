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
        public Queue<Thief> ArrestedThiefs { get; set; }
        public Prison(Queue<Thief> arrestedThiefs, int x, int y, char[,] map) : base(x, y, map)
        {
            ArrestedThiefs = arrestedThiefs;
        }
        public void DrawPrison()
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
                    Map[y, x] = symbol;
                    Console.ForegroundColor = color;
                    Console.Write(Map[y, x]);
                    Console.ResetColor();
                    

                    //else
                    //{
                    //foreach (Thief thief in ArrestedThiefs)
                    //{
                    //    if (thief.X == x && thief.Y == y)
                    //    {
                    //        symbol = thief.Symbol;
                    //        color = thief.Color;
                    //    }
                    //}
                    //}

                }
                Console.WriteLine();
            }
        }
    }
}

