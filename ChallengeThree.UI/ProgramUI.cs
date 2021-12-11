using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.UI
{
    class ProgramUI
    {
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

        private void DisplayAllBadges()
        {
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

        private void CreateBadge()
        {
            throw new NotImplementedException();
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
    }
}
