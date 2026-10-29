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
            List<Citizen> poorCitizen = new List<Citizen>();
            Queue<string> info = new Queue<string>();
            Prison prison = new Prison(arrestedThiefs, 0, 0, new char[10, 10]);
            PovertyHouse povertyHouse = new PovertyHouse(poorCitizen, 0, 0, new char[10, 50]);


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
                    prison.DrawPrison(arrestedThiefs, thiefs, info);

                    PovertyHouse.MovePoverty(poorCitizen);
                    povertyHouse.DrawPoverty(poorCitizen);

                    City.ShowStatus(polices, citizens, thiefs, arrestedThiefs, info, poorCitizen);
                    Thread.Sleep(500);


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

                    // metod för att röra på personerna
                    City.MovePeople(thiefs, polices, citizens);

                    City.CheckPoliceMeetings(polices, thiefs, arrestedThiefs, info);

                    // metod för att stöta på en annan person
                    City.CheckMeetings(thiefs, polices, citizens, arrestedThiefs, info, poorCitizen);
                    Console.Clear();

                    // metod för att rita staden med tjuvar, poliser och medborgare
                    City.DrawCity(thiefs, polices, citizens);

                    Prison.MoveThiefs(arrestedThiefs);
                    prison.DrawPrison(arrestedThiefs, thiefs, info);

                    PovertyHouse.MovePoverty(poorCitizen);
                    povertyHouse.DrawPoverty(poorCitizen);

                    City.ShowStatus(polices, citizens, thiefs, arrestedThiefs, info, poorCitizen);

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

                    Prison.MoveThiefs(arrestedThiefs);

                    PovertyHouse.MovePoverty(poorCitizen);

                    // metod för att lagra stöldgods, beslagtaget och tillhörigheter för tjuvar, poliser och medborgare
                    Item.StoreItems(thiefs, polices, citizens);

                    City.ShowStatus(polices, citizens, thiefs, arrestedThiefs, info, poorCitizen);
                    Thread.Sleep(1000);
                    Console.Clear();


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

                    City.MovePeople(thiefs, polices, citizens);

                    City.CheckPoliceMeetings(polices, thiefs, arrestedThiefs, info);

                    Prison.MoveThiefs(arrestedThiefs);

                    PovertyHouse.MovePoverty(poorCitizen);

                    // metod för att stöta på en annan person
                    City.CheckMeetings(thiefs, polices, citizens, arrestedThiefs, info, poorCitizen);

                    Item.StoreItems(thiefs, polices, citizens);

                    City.ShowStatus(polices, citizens, thiefs, arrestedThiefs, info, poorCitizen);
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }           
        }
    }
}



