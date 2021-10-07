using _03_Badges_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    class ProgramUI
    {
        private BadgeRepository _repo = new BadgeRepository();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Title = "Komodo Badges";
                Console.Clear();
                Console.WriteLine
                    (
                        "1. Add a badge\n" +
                        "2. Edit a badge\n" +
                        "3. List all badges\n" +
                        "0. Exit\n" +
                        "\nEnter the number of your selection:"
                    );
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid number..." +
                            "\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddBadge()
        {
            Console.Title = "Komodo Badges - Create Badge";
            Console.Clear();

            List<EDoor> doorList = new List<EDoor>();
            Badge badge = null;

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();

                bool inputValid = false;

                int count = 1;
                foreach (string doorName in Enum.GetNames(typeof(EDoor)))
                {
                    Console.WriteLine($"{count}. {doorName}");
                    count++;
                }

                Console.WriteLine("0. Done\n\nEnter a door this badge needs access to:");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    badge = _repo.CreateBadge(doorList);
                    keepRunning = false;
                    inputValid = true;
                }

                for (int i = 1; i <= count; i++)
                {
                    if (input == $"{i}")
                    {
                        if (!doorList.Contains((EDoor)(i - 1)))
                        {
                            doorList.Add((EDoor)(i - 1));
                        }
                        else
                        {
                            Console.WriteLine($"Badge already has access to door: {(EDoor)(i - 1)}");
                            Console.ReadKey();
                        }
                        inputValid = true;
                    }
                }

                if (!inputValid)
                {
                    if (keepRunning)
                    {
                        Console.WriteLine("\n\nPlease enter a valid input...");
                        Console.ReadKey();
                    }
                }
            }

            Console.Clear();
            Console.WriteLine($"Created Badge: {badge.BadgeID}\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void EditBadge()
        {
            Console.Title = "Komodo Badges - Edit Badge";

            Dictionary<Guid, List<EDoor>> doorDictionary = _repo.GetDictionary();

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                bool inputValid = false;
                int count = 1;

                foreach (KeyValuePair<Guid, List<EDoor>> kvp in doorDictionary)
                {
                    Console.Write($"({count}.)\nBadge ID: {kvp.Key}\nDoor access: ");

                    foreach (EDoor door in kvp.Value)
                    {
                        Console.Write($"{door} ");
                    }

                    Console.WriteLine("\n");
                    count++;
                }

                Console.WriteLine("0. Done\n\n\nEnter the number of your selection: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    keepRunning = false;
                    inputValid = true;
                }

                for (int i = 1; i <= count; i++)
                {
                    if (input == $"{i}")
                    {
                        int count2 = 1;
                        KeyValuePair<Guid, List<EDoor>> kvpToUpdate = new KeyValuePair<Guid, List<EDoor>>();
                        bool shouldUpdate = false;

                        foreach (KeyValuePair<Guid, List<EDoor>> kvp in doorDictionary)
                        {
                            int.TryParse(input, out int result);

                            if (result == count2)
                            {
                                kvpToUpdate = kvp;
                                shouldUpdate = true;
                            }

                            count2++;
                        }

                        if (shouldUpdate)
                        {
                            UpdateBadge(kvpToUpdate);
                        }

                        inputValid = true;
                    }
                }

                if (!inputValid)
                {
                    if (keepRunning)
                    {
                        Console.WriteLine("\n\nPlease enter a valid input...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private void UpdateBadge(KeyValuePair<Guid, List<EDoor>> kvp)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Title = "Komodo Badges - Edit Badge";
                Console.Clear();

                Console.WriteLine("1. Add a door\n2. Remove a door\n0. Done\n\nEnter the number of you selection:");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    AddDoor(kvp);
                }

                else if (input == "2")
                {
                    RemoveDoor(kvp);
                }

                else if (input == "0")
                {
                    keepRunning = false;
                }

                else
                {
                    Console.WriteLine("\n\nPlease enter a valid input...");
                    Console.ReadKey();
                }
            }
        }

        private void AddDoor(KeyValuePair<Guid, List<EDoor>> kvp)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Title = "Komodo Badges - Edit Badge - Add Door";
                Console.Clear();

                bool inputValid = false;
                int count = 1;

                foreach (string doorName in Enum.GetNames(typeof(EDoor)))
                {
                    if (!kvp.Value.Contains((EDoor)Enum.Parse(typeof(EDoor), doorName)))
                    {
                        Console.WriteLine($"{count}. {doorName} ");
                        count++;
                    }
                }

                Console.WriteLine("0. Done");

                Console.WriteLine("\nEnter the number of you selection: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    keepRunning = false;
                    inputValid = true;
                }

                for (int i = 1; i <= count; i++)
                {
                    if (input == $"{i}")
                    {
                        int count2 = 1;
                        EDoor doorToAdd = new EDoor();
                        bool doorAdded = false;

                        foreach (string doorName in Enum.GetNames(typeof(EDoor)))
                        {
                            int.TryParse(input, out int result);

                            if (result == count2)
                            {
                                doorToAdd = (EDoor)Enum.Parse(typeof(EDoor), doorName);
                                doorAdded = true;
                            }

                            if (!kvp.Value.Contains((EDoor)Enum.Parse(typeof(EDoor), doorName)))
                            {
                                count2++;
                            }
                        }

                        if (doorAdded)
                        {
                            kvp.Value.Add(doorToAdd);
                            _repo.UpdateDictionary(kvp);
                        }

                        inputValid = true;
                    }
                }

                if (!inputValid)
                {
                    if (keepRunning)
                    {
                        Console.WriteLine("\n\nPlease enter a valid input...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private void RemoveDoor(KeyValuePair<Guid, List<EDoor>> kvp)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Title = "Komodo Badges - Edit Badge - Remove Door";
                Console.Clear();

                bool inputValid = false;
                int count = 1;

                foreach (EDoor door in kvp.Value)
                {
                    Console.WriteLine($"{count}. {door} ");
                    count++;
                }

                Console.WriteLine("0. Done");

                Console.WriteLine("\nEnter the number of you selection: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    keepRunning = false;
                    inputValid = true;
                }

                for (int i = 1; i <= count; i++)
                {
                    if (input == $"{i}")
                    {
                        int count2 = 1;

                        EDoor doorToRemove = new EDoor();

                        foreach (EDoor door in kvp.Value)
                        {
                            int.TryParse(input, out int result);

                            if (result == count2)
                            {
                                doorToRemove = door;
                            }

                            count2++;
                        }

                        kvp.Value.Remove(doorToRemove);
                        _repo.UpdateDictionary(kvp);

                        inputValid = true;
                    }
                }

                if (!inputValid)
                {
                    if (keepRunning)
                    {
                        Console.WriteLine("\n\nPlease enter a valid input...");
                        Console.ReadKey();
                    }
                }
            }
        }

        private void ListBadges()
        {
            Console.Title = "Komodo Badges - List Badges";
            Console.Clear();

            Dictionary<Guid, List<EDoor>> doorDictionary = _repo.GetDictionary();

            foreach (KeyValuePair<Guid, List<EDoor>> kvp in doorDictionary)
            {
                Console.WriteLine($"Badge ID: {kvp.Key}\nDoor access: ");

                foreach (EDoor door in kvp.Value)
                {
                    Console.Write($"{door} ");
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }

        private void SeedData()
        {
            List<EDoor> doorsList1 = new List<EDoor>();
            List<EDoor> doorsList2 = new List<EDoor>();

            doorsList1.Add(EDoor.A1);
            doorsList1.Add(EDoor.B1);

            doorsList2.Add(EDoor.A2);
            doorsList2.Add(EDoor.B2);

            _repo.CreateBadge(doorsList1);
            _repo.CreateBadge(doorsList2);
        }
    }
}
