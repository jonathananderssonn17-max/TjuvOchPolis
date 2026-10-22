using System.Drawing;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Thief> thiefs = new List<Thief>();
            List<Police> polices = new List<Police>();
            List<Citizen> citizens = new List<Citizen>();
            Queue<Thief> arrestedThiefs = new Queue<Thief>();
            Queue<string> info = new Queue<string>();

            // metod för att skapa tjuvar, poliser och medborgare
            Person.CreatePeople(thiefs, polices, citizens);

            while (true)
            {
                    while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.V))
                    {
                        // metod för att röra på poliserna (polisen går ett extra steg)
                        City.MovePolice(polices);

                        City.CheckPoliceMeetings(polices, thiefs, arrestedThiefs, info);
                        Console.Clear();

                        City.DrawCity(thiefs, polices, citizens);

                        City.ShowStatus(polices, citizens, thiefs, arrestedThiefs, info);

                        Thread.Sleep(500);


                        // metod för att röra på personerna
                        City.MovePeople(thiefs, polices, citizens);

                        City.CheckPoliceMeetings(polices, thiefs, arrestedThiefs, info);

                        // metod för att stöta på en annan person
                        City.CheckMeetings(thiefs, polices, citizens, arrestedThiefs, info);
                        Console.Clear();
                        // metod för att rita staden med tjuvar, poliser och medborgare
                        City.DrawCity(thiefs, polices, citizens);

                        City.ShowStatus(polices, citizens, thiefs, arrestedThiefs, info);

                        Thread.Sleep(500);
                    }

                    while(!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.V))
                    {

                        City.MovePolice(polices);

                        City.CheckPoliceMeetings(polices, thiefs, arrestedThiefs, info);

                        // metod för att lagra stöldgods, beslagtaget och tillhörigheter för tjuvar, poliser och medborgare
                        Item.StoreItems(thiefs, polices, citizens);
                        Thread.Sleep(1000);
                        Console.Clear();

                         City.MovePeople(thiefs, polices, citizens);

                         City.CheckPoliceMeetings(polices, thiefs, arrestedThiefs, info);

                         // metod för att stöta på en annan person
                         City.CheckMeetings(thiefs, polices, citizens, arrestedThiefs, info);
                         Item.StoreItems(thiefs, polices, citizens);

                         Thread.Sleep(1000);
                         Console.Clear();
                    }
                }           
        }
    }
}



