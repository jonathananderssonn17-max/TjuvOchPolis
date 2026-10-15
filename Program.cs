using System.Security.Cryptography.X509Certificates;

namespace TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Thief> thiefs = new List<Thief>();
            List<Police> polices = new List<Police>();
            List<Citizen> citizens = new List<Citizen>();

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

            for (int i = 0; i < 6; i++)
            {
                int x = Random.Shared.Next(-100, 100);
                int y = Random.Shared.Next(-100, 100);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Thief name = new Thief(names[rnd], x, y, xDir, yDir);
                thiefs.Add(name);
            }

            for (int i = 0; i < 10; i++)
            {
                int x = Random.Shared.Next(-100, 100);
                int y = Random.Shared.Next(-100, 100);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Police name = new Police(names[rnd], x, y, xDir, yDir);
                polices.Add(name);
            }

            for (int i = 0; i < 20; i++)
            {
                int x = Random.Shared.Next(-100, 100);
                int y = Random.Shared.Next(-100, 100);
                int xDir = Random.Shared.Next(-1, 2);
                int yDir = Random.Shared.Next(-1, 2);
                int rnd = Random.Shared.Next(0, names.Length);

                Citizen name = new Citizen(names[rnd], x, y, xDir, yDir);
                citizens.Add(name);
            }
            foreach(Citizen citizen in citizens)
            {
                Console.WriteLine(citizen.Name + ":" + citizen.X + ":" + citizen.Y + ":" );
              foreach(Item item in citizen.Tillhörigheter)
                {
                    Console.WriteLine(item.Name);
                } 
            }
            
        }

    }
}
