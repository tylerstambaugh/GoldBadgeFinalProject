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
        private readonly BadgeRepo _badgeRepo = new Lib.BadgeRepo();
        public void Run()
        {
            //Seed Data
            RunApplication();
        }

        //console interation with user:
        public void RunApplication()
        {
            bool runApplication = true;
            while(runApplication)
            {
                Menu();
                int userInput = Int32.Parse(Console.ReadLine());
                switch(userInput)
                {
                    case 1:
                        CreateBadge();
                        break;
                    case 2:
                        UpdateDoorsOnBadge();
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

        //Just prints the menu, nothing else
        public void Menu()
        {
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
                if(addAnotherDoor == "n")
                {
                    keepAdding = false;
                    break;
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
            
            throw new NotImplementedException();
        }

        private void DisplayAllBadges()
        {
            Console.Clear();
            throw new NotImplementedException();
        }

        private void DeleteAllDoorsOnBadge()
        {
            throw new NotImplementedException();
        }

        private void UpdateDoorsOnBadge()
        {
            throw new NotImplementedException();
        }

     


    }
}
