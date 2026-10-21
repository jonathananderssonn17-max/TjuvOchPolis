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
                var key = new ConsoleKeyInfo();
                if (Console.KeyAvailable) // Non-blocking peek
                {
                    // vi måste på något sätt göra så att programmet förstår vilken tangent som trycks ned. Ska göra här

                    switch (key.KeyChar)
                    {
                        case 'v':
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
                            break;

                        case 'q':
                            // metod för att lagra stöldgods, beslagtaget och tillhörigheter för tjuvar, poliser och medborgare
                            Item.StoreItems(thiefs, polices, citizens);
                            break;
                    }
                }           
            }
        }
    }
}



