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

            // metod för att skapa tjuvar, poliser och medborgare
            Person.CreatePeople(thiefs, polices, citizens);

            // metod för att lagra stöldgods, beslagtaget och tillhörigheter för tjuvar, poliser och medborgare
            Item.StoreItems(thiefs, polices, citizens);

            while (true)
            {
                // metod för att röra på poliserna (polisen går ett extra steg)
                City.MovePolice(polices);

                City.CheckMeetings(thiefs, polices, citizens);
                Console.Clear();

                City.DrawCity(thiefs, polices, citizens);

                City.ShowStatus(polices, citizens, thiefs);

                Thread.Sleep(1000);



                // metod för att röra på personerna
                City.MovePeople(thiefs, polices, citizens);

                // metod för att stöta på en annan person
                City.CheckMeetings(thiefs, polices, citizens);
                Console.Clear();

                // metod för att rita staden med tjuvar, poliser och medborgare
                City.DrawCity(thiefs, polices, citizens);

                City.ShowStatus(polices, citizens, thiefs);

                Thread.Sleep(1000);
            }
        }
    }
}



