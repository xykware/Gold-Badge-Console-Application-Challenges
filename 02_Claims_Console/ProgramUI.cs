using _02_Claims_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    class ProgramUI
    {
        private ClaimRepository _repo = new ClaimRepository();

        public void Run()
        {
            Console.Title = "Komodo Claims";
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                        "1. See all claims\n" +
                        "2. Take care of next claim\n" +
                        "3. Enter a new claim\n" +
                        "0. Exit\n" +
                        "\nEnter the number of your selection:"
                    );
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowClaims();
                        break;
                    case "2":
                        ManageClaims();
                        break;
                    case "3":
                        AddClaim();
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

        private void AddClaim()
        {
            Claim claimItem = new Claim();

            string input;
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();

                int count = 1;
                foreach (string claimType in Enum.GetNames(typeof(EClaimType)))
                {
                    Console.WriteLine($"{count}. {claimType}");
                    count++;
                }

                Console.WriteLine("Enter the claim type:");
                input = Console.ReadLine();

                for (int i = 1; i <= count; i++)
                {
                    if (input == $"{i}")
                    {
                        claimItem.ClaimType = ((EClaimType)(i - 1));
                        keepRunning = false;
                    }
                }

                if(keepRunning)
                {
                    Console.WriteLine("\n\nPlease enter a valid input...");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Console.WriteLine("Enter the description:");
            claimItem.Description = Console.ReadLine();
            Console.Clear();

            keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Enter the amount of damage:");
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    claimItem.ClaimAmount = result;
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input...");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Enter the date of incident (MM/DD/YYYY):");
                input = Console.ReadLine();

                if(DateTime.TryParse(input, out DateTime result))
                {
                    claimItem.DateOfIncident = result;
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("\n\nPlease enter a valid input...");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Enter the date of claim (MM/DD/YYYY):");
                input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime result))
                {
                    claimItem.DateOfClaim = result;
                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("\n\nPlease enter a valid input...");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            _repo.CreateClaim(claimItem);

            string valid;

            if (claimItem.IsValid)
            {
                valid = "Yes";
            }
            else
            {
                valid = "No";
            }

            Console.Write
                (
                    $"Claim ID: {claimItem.ClaimID}\n" +
                    $"Claim Type: {claimItem.ClaimType}\n" +
                    $"Description: {claimItem.Description}\n" +
                    $"Claim Amount: {claimItem.ClaimAmount}\n" +
                    $"Date of Incident: {claimItem.DateOfIncident.Month}/{claimItem.DateOfIncident.Day}/{claimItem.DateOfIncident.Year}\n" +
                    $"Date of Claim: {claimItem.DateOfClaim.Month}/{claimItem.DateOfClaim.Day}/{claimItem.DateOfClaim.Year}\n" +
                    $"Valid: {valid}\n"
                );

            Console.WriteLine("\n\nClaim successfully created.\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void ShowClaims()
        {
            Console.Clear();
            Queue<Claim> claimQueue = _repo.GetClaimQueue();

            if (claimQueue.Count == 0)
            {
                Console.WriteLine("No claims to show.");
            }

            foreach (Claim claimItem in claimQueue)
            {
                string valid;

                if (claimItem.IsValid)
                {
                    valid = "Yes";
                }
                else
                {
                    valid = "No";
                }

                Console.Write
                    (
                        $"\n\nClaim ID: {claimItem.ClaimID}\n" +
                        $"Claim Type: {claimItem.ClaimType}\n" +
                        $"Description: {claimItem.Description}\n" +
                        $"Claim Amount: {claimItem.ClaimAmount}\n" +
                        $"Date of Incident: {claimItem.DateOfIncident.Month}/{claimItem.DateOfIncident.Day}/{claimItem.DateOfIncident.Year}\n" +
                        $"Date of Claim: {claimItem.DateOfClaim.Month}/{claimItem.DateOfClaim.Day}/{claimItem.DateOfClaim.Year}\n" +
                        $"Valid: {valid}\n"
                    );
            }

            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void ManageClaims()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Queue<Claim> claimQueue = _repo.GetClaimQueue();

                if (claimQueue.Count > 0)
                {
                    Claim claimItem = claimQueue.Peek();

                    string valid;

                    if (claimItem.IsValid)
                    {
                        valid = "Yes";
                    }
                    else
                    {
                        valid = "No";
                    }
                    Console.Clear();

                    Console.Write
                    (
                        $"Claim ID: {claimItem.ClaimID}\n" +
                        $"Claim Type: {claimItem.ClaimType}\n" +
                        $"Description: {claimItem.Description}\n" +
                        $"Claim Amount: {claimItem.ClaimAmount}\n" +
                        $"Date of Incident: {claimItem.DateOfIncident.Month}/{claimItem.DateOfIncident.Day}/{claimItem.DateOfIncident.Year}\n" +
                        $"Date of Claim: {claimItem.DateOfClaim.Month}/{claimItem.DateOfClaim.Day}/{claimItem.DateOfClaim.Year}\n" +
                        $"Valid: {valid}\n"
                    );

                    Console.WriteLine("\n\nDo you want to deal with this claim now? (y/n)");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "yes" || input.ToLower() == "y")
                    {
                        claimQueue.Dequeue();

                        Console.Clear();
                        Console.WriteLine("Claim dealt with.");
                        Console.ReadKey();
                    }
                    else if (input.ToLower() == "no" || input.ToLower() == "n")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    keepRunning = false;
                }
            }

            Console.Clear();

            Console.WriteLine("No more claims to deal with.\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void SeedData()
        {
            DateTime claim1_IncidentDate = new DateTime(1997, 9, 11);
            DateTime claim1_ClaimDate = new DateTime(2011, 6, 23);

            DateTime claim2_IncidentDate = new DateTime(2015, 11, 2);
            DateTime claim2_ClaimDate = new DateTime(2015, 12, 2);

            DateTime claim3_IncidentDate = new DateTime(2017, 1, 5);
            DateTime claim3_ClaimDate = new DateTime(2017, 2, 2);

            Claim claim1 = new Claim(EClaimType.Car, "Car landed in a big toilet", 5300m, claim1_IncidentDate, claim1_ClaimDate);
            Claim claim2 = new Claim(EClaimType.Home, "House destroyed in flood", 500000m, claim2_IncidentDate, claim2_ClaimDate);
            Claim claim3 = new Claim(EClaimType.Theft, "Rare video game collection stolen", 150000m, claim3_IncidentDate, claim3_ClaimDate);

            _repo.CreateClaim(claim1);
            _repo.CreateClaim(claim2);
            _repo.CreateClaim(claim3);
        }
    }
}
