using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeOne.Lib;

namespace ChallengeOne.UI
{
    class ProgramUI
    {
        private readonly MenuRepo _menuRepo = new MenuRepo();
        
        public void Run()
        {
            // call any seed data methods if necessary here.
            RunApplication();
        }

        public void RunApplication()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.Clear();
                PrintMenu();
                if(!Int32.TryParse(Console.ReadLine(), out int userInput) || (userInput < 1 || userInput > 5))
                {
                    Console.WriteLine("Please enter a valid number. \n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                    
                }

                switch (userInput)
                {
                    case 1:
                        AddMenuItem();
                        break;
                    case 2:
                        ViewMenuItems();
                        break;
                    case 3:
                        DeleteMenuItem();
                        break;
                    case 4:
                        UpdateMenuItem();
                        break;
                    case 5:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("I'm a computer. You're a computer too. Nice to meet you.");
                        break;
                }
            }
        }

        private void AddMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Add Menu Item Subsystem AM1 \n" +
                "Please enter the new meal number:");
            if(!Int32.TryParse(Console.ReadLine(), out int mealNumber))
            {
                Console.WriteLine("Please enter a valid number. \n" +
                    "Press any key to try again.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Please enter the meal name:");
            string mealName = Console.ReadLine();
            Console.WriteLine("Please enter the meal description:");
            string mealDescription = Console.ReadLine();

            List<string> mealIngredients = new List<string>();
            Console.WriteLine("Please enter the meal ingredients. Press '*' to move on.");
            bool addingIngredients = true;
            while (addingIngredients)
            {
                string ingredient = Console.ReadLine();
                if (ingredient.ToString() == "*")
                {
                    addingIngredients = false;
                }
                else
                {
                    mealIngredients.Add(ingredient);
                }
            }

            Console.WriteLine("Please enter the meal price:");
            if(!Decimal.TryParse(Console.ReadLine(), out Decimal price))
            {
                Console.WriteLine("That is not a valid price. Press any ket to try again.");
            }

            MenuItem itemToAdd = new MenuItem(mealNumber, mealName, mealDescription, mealIngredients, price);
            bool wasAdded = _menuRepo.addItemToMenu(itemToAdd);
            if (wasAdded)
            {
                Console.WriteLine("Cool, I think that worked. Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Uncool, the code needs fixed.");
                Console.ReadKey();
            }
        }


        private void ViewMenuItems()
        {
            List<MenuItem> itemsToDisplay = _menuRepo.GetMenuItems();

            foreach (MenuItem mi in itemsToDisplay)
            {
                Console.WriteLine($"{itemsToDisplay.Count}");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
        private void DeleteMenuItem()
        {
            throw new NotImplementedException();
        }

        private void UpdateMenuItem()
        {
            throw new NotImplementedException();
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Komodo Menuing System V.0.1 \n" +
                "Please select an option: \n" +
                "1. Create Menu Item \n" +
                "2. View Menu Items \n" +
                "3. Delete Menu Item \n" +
                "4. Update Menu Item \n" +
                "5. Exit");
            
        }
    }
}
