using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.UI
{
    class ProgramUI
    {
        
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

        }


        private void ViewMenuItems()
        {
            throw new NotImplementedException();
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
