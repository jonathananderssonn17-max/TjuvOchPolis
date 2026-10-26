using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TjuvOchPolis
{
    internal class City
    {
        
        public static int counter = 0;
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

        public static void MovePeople(List<Thief> thiefs, List<Police> polices, List<Citizen> citizens)
        {
            foreach (Thief thief in thiefs)
            {
                thief.X += thief.Xdirection;
                thief.Y += thief.Ydirection;

                if (thief.X > 99)
                {
                    thief.X = 1;
                }

                else if (thief.X < 1)
                {
                    thief.X = 99;
                }

                if (thief.Y > 24)
                {
                    thief.Y = 1;
                }

                else if (thief.Y < 1)
                {
                    thief.Y = 24;
                }
            }

            foreach (Police police in polices)
            {
                police.X += police.Xdirection;
                police.Y += police.Ydirection;

                if (police.X > 99)
                {
                    police.X = 1;
                }

                else if (police.X < 1)
                {
                    police.X = 99;
                }

                if (police.Y > 24)
                {
                    police.Y = 1;
                }

                else if (police.Y < 1)
                {
                    police.Y = 24;
                }
            }

            foreach (Citizen citizen in citizens)
            {
                citizen.X += citizen.Xdirection;
                citizen.Y += citizen.Ydirection;

                if (citizen.X > 99)
                {
                    citizen.X = 1;
                }

                else if (citizen.X < 1)
                {
                    citizen.X = 99;
                }

                if (citizen.Y > 24)
                {
                    citizen.Y = 1;
                }

                else if (citizen.Y < 1)
                {
                    citizen.Y = 24;
                }
            }
        }
        public static int countArrest = 0;
        public static int countStolen = 0;
        public static int countBeslagtaget = 0;

        public static void MovePolice(List<Police> polices) // metod som har syfte att låta polisen gå ett extra steg
        {
            foreach (Police police in polices)
            {
                police.X += police.Xdirection;
                police.Y += police.Ydirection;

                if (police.X > 99)
                {
                    police.X = 1;
                }

                else if (police.X < 1)
                {
                    police.X = 99;
                }

                if (police.Y > 24)
                {
                    police.Y = 1;
                }

                else if (police.Y < 1)
                {
                    police.Y = 24;
                }
            }
        }

        public static void CheckMeetings(List<Thief> thiefs, List<Police> polices, List<Citizen> citizens, Queue<Thief> arrestedThiefs, Queue<string> info)
        {
            foreach (Thief thief in thiefs)
            {
                foreach (Citizen citizen in citizens)
                {
                    if (thief.X == citizen.X && thief.Y == citizen.Y)
                    {
                        if(citizen.Tillhörigheter.Count > 0)
                        {
                            int rnd = new Random().Next(0, citizen.Tillhörigheter.Count);
                            Item stolenItem = citizen.Tillhörigheter[rnd];
                            citizen.Tillhörigheter.RemoveAt(rnd);

                            counter++;
                            thief.Stöldgods.Add(stolenItem);
                            info.Enqueue(counter + ": " + thief.Name + " stjäl " + stolenItem.Name + " från medborgaren " + citizen.Name + "!");

                            // För att se om listan fungerar korrekt.
                            //Console.WriteLine("Antal stöldgods hos tjuven: " + thief.Stöldgods.Count);
                            countStolen++;
                        }

                        else
                        {
                            counter++;
                            info.Enqueue(counter + ": " + thief.Name + " försöker råna medborgaren " + citizen.Name + ", men det finns inget att stjäla!");
                        }
                    }
                }
            }

            foreach (Citizen citizen in citizens)
            {
                foreach (Police police in polices)
                {
                    if (citizen.X == police.X && citizen.Y == police.Y)
                    {
                        counter++;
                        info.Enqueue(counter + ": " +citizen.Name + " hälsar på polisen " + police.Name + "!");
                    }
                }
            }
        }
        public static void CheckPoliceMeetings(List<Police> polices, List<Thief> thiefs, Queue<Thief> arrestedThiefs, Queue<string> info)
        {
            foreach (Police police in polices)
            {
                for (int i = 0; i < thiefs.Count; i++)
                {
                    if (police.X == thiefs[i].X && police.Y == thiefs[i].Y)
                    {
                        if (thiefs[i].Stöldgods.Count > 0)
                        {
                            foreach (Item item in thiefs[i].Stöldgods)
                            {
                                police.Beslagtaget.Add(item);
                            }
                            thiefs[i].Stöldgods.Clear();

                            counter++;
                            info.Enqueue(counter + ": " + police.Name + " beslagtar all stöldgods från tjuven och arrersterar " + thiefs[i].Name + "!");
                           
                            arrestedThiefs.Enqueue(thiefs[i]);
                            thiefs.RemoveAt(i);

                            countArrest++;             
                            countBeslagtaget += police.Beslagtaget.Count;
                            countStolen -= police.Beslagtaget.Count;
                        }

                        else
                        {
                            counter++;
                            info.Enqueue(counter + ": " + police.Name + " stöter på tjuven " + thiefs[i].Name + ", men det finns inget stöldgods så inget brott har begåtts!");
                        }
                    }
                }
            }
        }

        public static void ShowStatus(List<Police> polices, List<Citizen> citizens, List< Thief> thiefs, Queue<Thief> arrestedThiefs, Queue<string> info)
        {
            Console.WriteLine("=STATUS=============================================================================================");
            Console.WriteLine($"Av {thiefs.Count + arrestedThiefs.Count} tjuvar är det nu {thiefs.Count} tjuvar kvar.");
            Console.WriteLine($"Av {citizens.Count} medborgare är det nu {citizens.Count} kvar.");
            Console.WriteLine($"Det finns {polices.Count} poliser i staden.");
            Console.WriteLine("Antal arresterade tjuvar: " + countArrest);
            Console.WriteLine("Antal beslagtagna saker: " + countBeslagtaget);
            Console.WriteLine("Antal stöldgods: " + countStolen);
            Console.WriteLine("=NEWS FEED==========================================================================================");
            
            while (info.Count > 5)
            {
                info.Dequeue();
            }

            foreach (string news in info)
            {
                Console.WriteLine(news);
            }

            Console.WriteLine("=ARRESTLISTA========================================================================================");
            foreach (Thief arrestedThief in arrestedThiefs)
            {
                Console.WriteLine("Arresterade tjuvar: " + arrestedThief.Name);
            }
        }
    }
}
