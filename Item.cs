using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    internal class Item
    {
        public string Name { get; set; }
        public Item (string name) {  Name = name;}

        public List<Item> Beslagtaget { get; set; }

        public List<Item> Stöldgods { get; set; }
        public List<Item> Tillhörigheter { get; set; }


        // Metod för att lagra stöldgods, beslagtaget och tillhörigheter för tjuvar, poliser och medborgare
        public static void StoreItems(List<Thief> thiefs, List<Police> polices, List<Citizen> citizens)
        {
            Console.WriteLine("Tjuvar: ");

            foreach (Thief thief in thiefs)
            {
                Console.WriteLine(thief.Name + " - X: " + thief.X + ", Y: " + thief.Y);
                foreach (Item item in thief.Stöldgods)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.WriteLine();


            Console.WriteLine("Poliser:");

            foreach (Police police in polices)
            {
                Console.WriteLine(police.Name + " - X: " + police.X + ", Y: " + police.Y);
                foreach (Item item in police.Beslagtaget)
                {
                    Console.WriteLine(item.Name);
                }
            }
            Console.WriteLine();


            Console.WriteLine("Medborgare: ");

            foreach (Citizen citizen in citizens)
            {
                Console.WriteLine(citizen.Name + " - X:" + citizen.X + ", Y:" + citizen.Y);
                foreach (Item item in citizen.Tillhörigheter)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}