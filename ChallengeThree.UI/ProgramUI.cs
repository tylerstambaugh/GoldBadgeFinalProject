using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeThree.Lib;

namespace ChallengeThree.UI
{
    class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            //Seed Data
            RunApplication();
        }

        //console interation with user:
        private void RunApplication()
        {
            bool runApplication = true;
            while(runApplication)
            {
                Menu();
                int userInput;
                if (!Int32.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Please make a valid selection. Press any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    switch (userInput)
                    {
                        case 1:
                            CreateBadge();
                            break;
                        case 2:
                            UpdateBadge();
                            break;
                        case 3:
                            DeleteAllDoorsOnBadge();
                            break;
                        case 4:
                            DisplayAllBadges();
                            break;
                        case 99:
                            runApplication = false;
                            break;
                        default:
                            Console.WriteLine("Your input was not recognized. Please try again.");
                            break;
                    }
                }
            }

        }

        //Just prints the menu, nothing else
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Komodo Insuarnce Badge Management System \n" +
                "Please select a function: \n" +
                "1. Create a Badge \n" +
                "2. Update Doors on Existing Badge \n" +
                "3. Delete All Doors From Existing Badge \n" +
                "4. Display List of All Badges With Door Access Details \n" +
                "99. Exit");
        }

        //collects inputs from user to build a new badge and then adds it to the repo. 
        private void CreateBadge()
        {
            Console.Clear();
            List<string> doors = new List<string>();
            bool keepAdding = true;
            Console.WriteLine("Please enter the badge number:");
            int badgeNumber;
            if (Int32.TryParse(Console.ReadLine(), out badgeNumber))
            {
                while (keepAdding)
                {
                    Console.WriteLine("To which door does the badge need access?");
                    string doorToAdd = Console.ReadLine();
                    doors.Add(doorToAdd);
                    Console.WriteLine("Add another door? (y/n)");
                    string addAnotherDoor = Console.ReadLine().ToLower();
                    if (addAnotherDoor == "y")
                    {
                        keepAdding = true; ;
                    }
                    else
                    {
                        keepAdding = false;
                    }
                }
                Badge badgeToAdd = new Badge(badgeNumber, doors);
                bool addedSuccessfully = _badgeRepo.CreateBadge(badgeToAdd);
                if (addedSuccessfully)
                {
                    Console.WriteLine("Badge added successfully. Press any key to return.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("That did not work. Check your inputs and try again. Perhaps that badge alredy exists.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Please enter a number (1, 2, 3, 42... for the Badge Number.");
                Console.ReadLine();
            }
        }

        //iterates through the dictionary of doors and prints out the badge number and the list of doors assigned to it.
        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _badgeRepo.GetAllBadges();
            Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", "Badge#", "Door Access"));
            PrintLine();
            foreach (var v in badges)
            {
                string stringOfDoors = GetStringOfDoors(v.Key);
                Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", $" {v.Key }", $"{stringOfDoors}"));
            }
            Console.WriteLine("Press and key to return.");
            Console.ReadKey();
        }

        private void DeleteAllDoorsOnBadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _badgeRepo.GetAllBadges();
            Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", "Badge#", "Door Access"));
            PrintLine();
            foreach (var v in badges)
            {
                string stringOfDoors = GetStringOfDoors(v.Key);
                Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", $" {v.Key }", $"{stringOfDoors}"));

            }
            Console.WriteLine();

            Console.WriteLine("Please enter the badge number for which you would like to remove all the doors:");
            int badgeNumber;
            if (!Int32.TryParse(Console.ReadLine(), out badgeNumber))
            {
                Console.WriteLine("Please try again with a valid number.");
                Console.ReadKey();
            }
            else if (!badges.ContainsKey(badgeNumber))
            {
                Console.WriteLine("That badge was not found. Please check your inputs and try again.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Are you sure you want to remove all doors from Badge Number {badgeNumber}? (y/n) ");
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "y")
                {
                    bool removedSuccessfully = _badgeRepo.RemoveAllDoorsFromBadge(badgeNumber);
                    if (removedSuccessfully)
                    {
                        Console.WriteLine($"All doors removed successfully. \n" +
                            $"Badge Number: {badgeNumber} has access to: {GetStringOfDoors(badgeNumber)} \n" +
                            $"Press any key to return to the menu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("There was a problem removing all doors from the badge. Please check your inputs and try again. Press any key to return to the menu.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Glad we checked. Press any key to return.");
                    Console.ReadKey();
                }
            }
        }


        //Allows user to add a door to an existing badge or remove a door from an existing badge. Calls out to two helper methods below.
        private void UpdateBadge()
        {
            bool keepUpdating = true;
            while (keepUpdating)
            {
                //clear the console and display the liist of existing badge and their door assignment.
                Console.Clear();
                Dictionary<int, List<string>> badges = _badgeRepo.GetAllBadges();
                Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", "Badge#", "Door Access"));
                PrintLine();
                foreach (var v in badges)
                {
                    string stringOfDoors = GetStringOfDoors(v.Key);
                    Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", $" {v.Key }", $"{stringOfDoors}"));

                }
                Console.WriteLine();

                Console.WriteLine("Please enter the badge ID for which you would like to update the list of doors: \n" +
                    "Enter 99 to return.");

                int userSelection;
                if (!Int32.TryParse(Console.ReadLine(), out userSelection))
                {
                    Console.WriteLine("Please enter a valid number. Press any key to try again.");
                    Console.ReadKey();
                }
                else if (userSelection == 99)
                {
                    keepUpdating = false;
                }
                else if (!badges.ContainsKey(userSelection))
                {
                    Console.WriteLine("That badge was not found. Press any key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine();
                    string stringOfDoors = GetStringOfDoors(userSelection);
                    Console.WriteLine($"BadgeID: {userSelection} has access to {stringOfDoors}");
                    Console.WriteLine();
                    Console.WriteLine("What would you like to do?\n" +
                        "1. Remove A Door \n" +
                        "2. Add A Door \n" +
                        "3. Return to Menu");
                    int badgeUpdateOption;
                    if(!Int32.TryParse(Console.ReadLine(), out badgeUpdateOption))
                    {
                        Console.WriteLine("Please enter a valid number. Press any key to try again.");
                        Console.ReadKey();
                    }
                    else if(badgeUpdateOption != 1 && badgeUpdateOption != 2 && badgeUpdateOption != 3)
                    {
                        Console.WriteLine("Please enter a valid selection (1, 2, or three). Press any key to try again.");
                        Console.ReadKey();
                    }
                    else if (badgeUpdateOption == 1)
                    {
                        if (badges[userSelection].Count == 0)
                        {
                            Console.WriteLine("There are no doors to remove. Please select a different badge. Press any key to try again.");
                            Console.ReadKey();
                        }
                        else 
                        { 
                        RemoveDoorFromBadge(userSelection);
                        }
                    }
                    else if (badgeUpdateOption == 2)
                    {
                        AddDoorToBadge(userSelection);
                    }
                    else if (badgeUpdateOption == 3)
                    {
                        keepUpdating = false;
                    }
                }
            }
        }
        // method to remove door from badge, broken out from UpdateBadge method above

        private void RemoveDoorFromBadge(int badgeNumber)
        {
            Console.WriteLine("Which door would you like to remove?");
            string doorToRemove = Console.ReadLine();
            if (_badgeRepo.RemoveDoorFromBadge(badgeNumber, doorToRemove))
            {
                Console.WriteLine($"Door removed successfully.\n" +
                    $"Badge ID {badgeNumber} has access to {GetStringOfDoors(badgeNumber)}\n" +
                    "Press any key to retrun.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something went not right. Please check your inputs and try again");
                Console.ReadKey();
            }
        }

        // method to add door to badge. Broken out from UpdateBadge method above.
        private void AddDoorToBadge(int badgeNumber)
        {
            Console.WriteLine("Which door would you like to add?");
            string doorToAdd = Console.ReadLine();
            if (_badgeRepo.AddDoorToBadge(badgeNumber, doorToAdd))
            {
                Console.WriteLine($"Door added successfully.\n" +
                    $"Badge ID {badgeNumber} has access to {GetStringOfDoors(badgeNumber)}\n" +
                    "Press any key to retrun.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something went not right. Please check your inputs and try again.");
                Console.ReadKey();
            }
        }

        //helper method to return the list of doors from a badge as a signle string.
        private string GetStringOfDoors(int badgeNumber)
        {
            string stringOfDoors = "" ;
            Dictionary<int, List<string>> badges = _badgeRepo.GetAllBadges();
            List<string> listOfDoors = badges[badgeNumber];
            if (listOfDoors.Count == 0)
            {
                stringOfDoors = "No doors assigned.";
            }
            else
            {
                foreach (string door in listOfDoors)
                {
                    stringOfDoors += door + " ";
                }
            }
            return stringOfDoors;
        }
     
        //helper method for display
        public static void PrintLine()
        {
            Console.WriteLine(new string('_', Console.WindowWidth));
        }


    }
}
