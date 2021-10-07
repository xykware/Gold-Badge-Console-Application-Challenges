using _04_Outings_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Console
{
    public class ProgramUI
    {
        private OutingRepository _repo = new OutingRepository();

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
                Console.Title = "Komodo Outings";
                Console.Clear();
                Console.WriteLine
                    (
                        "1. Add an outing\n" +
                        "2. List outings\n" +
                        "3. Show outing costs\n" +
                        "0. Exit\n" +
                        "\nEnter the number of your selection:"
                    );
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddOuting();
                        break;
                    case "2":
                        //ListOutings();
                        break;
                    case "3":
                        //OutingsCost();
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

        private void AddOuting()
        {
            Console.Title = "Komodo Outings - Add Outing";

            Outing outing = new Outing();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();

                bool inputValid = false;

                int count = 1;

                foreach (string eventTypeName in Enum.GetNames(typeof(EEventType)))
                {
                    if (eventTypeName == EEventType.AmusementPark.ToString())
                    {
                        Console.WriteLine($"{count}. Amusement Park");
                    }
                    else
                    {
                        Console.WriteLine($"{count}. {eventTypeName}");
                    }
                    count++;
                }

                Console.WriteLine("0. Cancel\n\nEnter the event type:");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    return;
                }

                for (int i = 1; i <= count; i++)
                {
                    if (input == $"{i}")
                    {
                        outing.EventType = (EEventType)(i - 1);

                        keepRunning = false;
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

            keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of people who attended this event (or enter 'cancel'):");
                string input = Console.ReadLine();

                if (input.ToLower() == "cancel")
                {
                    return;
                }

                if (int.TryParse(input, out int result))
                {
                    outing.Attendees = result;
                    keepRunning = false;
                }
                else
                {
                    if (keepRunning)
                    {
                        Console.WriteLine("\n\nPlease enter a valid input...");
                        Console.ReadKey();
                    }
                }
            }

            Console.Clear();
            Console.WriteLine($"Created {outing.EventType} Outing!\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void SeedData()
        {
            DateTime date1 = new DateTime(2009, 12, 27);
            Outing outing1 = new Outing(EEventType.Bowling, 4, date1, 20, 60);

            DateTime date2 = new DateTime(2007, 8, 15);
            Outing outing2 = new Outing(EEventType.AmusementPark, 100, date2, 40, 5000);

            _repo.AddOuting(outing1);
            _repo.AddOuting(outing2);
        }
    }
}
