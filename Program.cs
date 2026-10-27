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

            List<Thief> thiefs = new List<Thief>();
            List<Police> polices = new List<Police>();
            List<Citizen> citizens = new List<Citizen>();
            List<Thief> arrestedThiefs = new List<Thief>();
            Queue<string> info = new Queue<string>();
            Prison prison = new Prison(arrestedThiefs, 0, 0, new char[10, 10]);

            // metod för att skapa tjuvar, poliser och medborgare
            Person.CreatePeople(thiefs, polices, citizens, names);

            bool runningCity = true;
            bool runningText = true;

            while (true)
            {
                while (runningCity) // loopen körs tills man trycker på v
                {
                    
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey(true).Key;

                        switch (key) 
                        {
                            case ConsoleKey.P:
                                Person.AddPolice(polices, names, info);
                                break;
                            case ConsoleKey.T:
                                Person.AddThief(thiefs, names, info);
                                break;
                            case ConsoleKey.M:
                                Person.AddCitizen(citizens, names, info);
                                break;
                            case ConsoleKey.V:
                                runningCity = false;
                                runningText = true;
                                break;
                        }

                    }

                    // metod för att röra på poliserna (polisen går ett extra steg)
                    City.MovePolice(polices);

                    City.CheckPoliceMeetings(polices, thiefs, arrestedThiefs, info);
                    Console.Clear();

                    City.DrawCity(thiefs, polices, citizens);
                    Prison.MoveThiefs(arrestedThiefs);

                    prison.DrawPrison(arrestedThiefs, thiefs);

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

                    prison.DrawPrison(arrestedThiefs, thiefs);

                    City.ShowStatus(polices, citizens, thiefs, arrestedThiefs, info);

                    Thread.Sleep(500);
                }

                while(runningText) // loopen körs tills man trycker på v
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey(true).Key;

                        switch (key)
                        {
                            case ConsoleKey.P:
                                Person.AddPolice(polices, names, info);
                                break;
                            case ConsoleKey.T:
                                Person.AddThief(thiefs, names, info);
                                break;
                            case ConsoleKey.M:
                                Person.AddCitizen(citizens, names, info);
                                break;
                            case ConsoleKey.V:
                                runningText = false;
                                runningCity = true;
                                break;
                        }
                    }

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



