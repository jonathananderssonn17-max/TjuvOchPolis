using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TjuvOchPolis
{
    internal class City
    {
        public static void DrawCity(List<Thief> thiefs, List<Police> polices, List<Citizen> citizens)
        {

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

                        foreach (Citizen citizen in citizens)
                        {
                            if (citizen.X == x && citizen.Y == y)
                            {
                                symbol = citizen.Symbol;
                                color = citizen.Color;
                            }
                        }

                        foreach (Police police in polices)
                        {
                            if (police.X == x && police.Y == y)
                            {
                                symbol = police.Symbol;
                                color = police.Color;
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

        }
    }
}
