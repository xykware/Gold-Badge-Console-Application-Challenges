using _01_Cafe_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class ProgramUI
    {
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            Console.Title = "Komodo Cafe - Menu Manager";
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
                        "1. Add a new item to the menu\n" +
                        "2. Show a list of current menu items\n" +
                        "3. Delete items from the menu\n" +
                        "0. Exit\n" +
                        "\nEnter the number of your selection:"
                    );
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        ShowMenuItems();
                        break;
                    case "3":
                        DeleteMenuItems();
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

        private void AddMenuItem()
        {
            Console.Clear();
            Menu menuItem = new Menu();

            Console.WriteLine("(type 'exit' or '0' to cancel)\n");

            Console.WriteLine("Enter a meal name:");
            menuItem.Name = Console.ReadLine();

            if (menuItem.Name == "0" || menuItem.Name == "exit")
            {
                return;
            }

            Console.WriteLine("\nEnter a description:");
            menuItem.Description = Console.ReadLine();

            if (menuItem.Description == "0" || menuItem.Name == "exit")
            {
                return;
            }

            Console.WriteLine("\nEnter a price:");
            string price = Console.ReadLine();

            if (price == "0" || price == "exit")
            {
                return;
            }

            menuItem.Price = Convert.ToDecimal(price);

            Console.Clear();

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("\nEnter an ingredient (type 'done' or '0' when finished):");
                string ingredient = Console.ReadLine();

                switch (ingredient)
                {
                    case "done":
                        keepRunning = false;
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        menuItem._ingredients.Add(ingredient);
                        break;
                }
            }

            _repo.CreateMenuItem(menuItem);

            Console.Clear();
            Console.WriteLine
                (
                    "Created menu item:\n" +
                    $"{menuItem.Number}. {menuItem.Name}\n\n" +
                    $"Press enter to continue..."
                );
            Console.ReadLine();
        }

        private void ShowMenuItems()
        {
            Console.Clear();
            List<Menu> menuList = _repo.GetMenuItemList();

            foreach (Menu menuItem in menuList)
            {
                Console.Write
                    (
                        $"\n\nMeal Number: {menuItem.Number}\n" +
                        $"Meal Name: {menuItem.Name}\n" +
                        $"Description: {menuItem.Description}\n" +
                        $"Price: {menuItem.Price}\n" +
                        $"Ingredients: "
                    );
                foreach (string ingredient in menuItem._ingredients)
                {
                    Console.Write($"{ingredient}, ");
                }
            }

            Console.WriteLine("\n\nPress enter to continue...");
            Console.ReadLine();
        }

        private void DeleteMenuItems()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                List<Menu> menuList = _repo.GetMenuItemList();

                foreach (Menu item in menuList)
                {
                    Console.WriteLine($"{item.Number}. {item.Name}");
                }

                Console.WriteLine("0. Cancel\nEnter the number of the item you want to delete:");
                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    return;
                }

                Menu menuItem = _repo.GetMenuItemOfNumber(Convert.ToInt32(choice));

                if (menuItem != null)
                {
                    bool success = _repo.DeleteMenuItem(menuItem);

                    if (success)
                    {
                        Console.Clear();
                        Console.WriteLine
                            (
                                "Deleted menu item:\n" +
                                $"{menuItem.Number}. {menuItem.Name}\n\n" +
                                "Press enter to continue..."
                            );
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine
                            (
                                "Failed to delete menu item:\n" +
                                $"{menuItem.Number}. {menuItem.Name}\n\n" +
                                "Press enter to continue..."
                            );
                    }

                    keepRunning = false;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a valid item number...");
                }

                Console.ReadLine();
            }
        }

        private void SeedData()
        {
            List<string> pretzelPizzaIngredients = new List<string> { "Pepperoni", "Cheddar Cheese", "Cheese Sauce", "Pretzel Crust", "Salt" };
            Menu pretzelPizza = new Menu("Alucard's Salty Pretzel Pizza", "Cheesy pretzel goodness!", pretzelPizzaIngredients, 8.99m);

            List<string> chiliPizzaIngredients = new List<string> { "Pepperoni", "Cheddar Cheese", "Chili Sauce", "Crust" };
            Menu chiliPizza = new Menu("Dracula's Chili Pizza", "Pizza with chili sauce", chiliPizzaIngredients, 7.99m);

            List<string> chiliPretzelPizzaIngredients = new List<string> { "Pepperoni", "Cheddar Cheese", "Chili Sauce", "Pretzel Crust", "Salt" };
            Menu chiliPretzelPizza = new Menu("Frankenstein's Pizza Monster", "Pretzel pizza with chili sauce", chiliPretzelPizzaIngredients, 10.99m);

            _repo.CreateMenuItem(pretzelPizza);
            _repo.CreateMenuItem(chiliPizza);
            _repo.CreateMenuItem(chiliPretzelPizza);
        }
    }
}
