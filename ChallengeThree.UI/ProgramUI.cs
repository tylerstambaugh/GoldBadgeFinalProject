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
        private void CreateBadge()
        {
            Console.Clear();
            List<string> doors = new List<string>();
            bool keepAdding = true;
            //Console.WriteLine("Please enter the badge name:");
            //string badgeName = Console.ReadLine();
            Console.WriteLine("Please enter the badge number:");
            int badgeNumber = Int32.Parse(Console.ReadLine());
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
                Console.WriteLine("That did not work. Please try harder. Press any key to return.");
                Console.ReadKey();
            }
            
           
        }

        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _badgeRepo.GetAllBadges();
            Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", "Badge#", "Door Access"));
            PrintLine();
            foreach (var v in badges)
            {
                string stringOfDoors = "";
                List<string> listOfDoors = v.Value;
                foreach(string s in listOfDoors)
                {
                    stringOfDoors += s + ", ";
                }
                Console.WriteLine(String.Format("|{0, -15}|{1, -15}|", $" {v.Key }", $"{stringOfDoors}"));

            }
            Console.WriteLine("Press and key to return.");
            Console.ReadKey();
            
        }

        private void DeleteAllDoorsOnBadge()
        {
            throw new NotImplementedException();
        }

        private void UpdateBadge()
        {
            bool keepUpdating = true;
            while (keepUpdating)
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

                Console.WriteLine("Please enter the badge ID for which you would like to update the list of doors:");
                int userSelection;
                if (!Int32.TryParse(Console.ReadLine(), out userSelection))
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                }
                else if (!badges.ContainsKey(userSelection))
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                }
                else
                {
                    string stringOfDoors = GetStringOfDoors(userSelection);
                    Console.WriteLine($"BadgeID: {userSelection} has access to {stringOfDoors}");
                    Console.WriteLine("What would you like to do?\n" +
                        "1. Remove A Door \n" +
                        "2. Add A Door \n" +
                        "3. Return to Menu");
                    int badgeUpdateOption;
                    if(!Int32.TryParse(Console.ReadLine(), out badgeUpdateOption))
                    {
                        Console.WriteLine("Please enter a valid number.");
                        Console.ReadKey();
                    }
                    else if(badgeUpdateOption != 1 && badgeUpdateOption != 2 && badgeUpdateOption != 3)
                    {
                        Console.WriteLine("Please enter a valid selection.");
                        Console.ReadKey();
                    }
                    else if (badgeUpdateOption == 1)
                    {
                        //call some other update method, this is getting really long.
                    }
                    else if (badgeUpdateOption == 2)
                    {
                        // call some other method, this is getting really long too.
                    }
                    else if (badgeUpdateOption == 3)
                    {
                        keepUpdating = false;
                    }
                }
            }
        }


        //helper method for display
        public static void PrintLine()
        {
            Console.WriteLine(new string('_', Console.WindowWidth));
        }

        // method to remove door from badge, broken out from UpdateBadge method above

        public void RemoveDoorFromBadge()
        {

        }

        public string GetStringOfDoors(int badgeNumber)
        {
            string stringOfDoors = "";
            Dictionary<int, List<string>> badges = _badgeRepo.GetAllBadges();
            List<string> listOfDoors = badges[badgeNumber];
            foreach (string door in listOfDoors)
            {
                stringOfDoors += door + " ";
            }
            return stringOfDoors;
        }
     


    }
}
