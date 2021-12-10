using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwo.Lib;

namespace ChallengeTwo.UI
{
    class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        public void Run()
        {
            //SeedData?
            RunApplication(); 
        }

        public void RunApplication()
        {
            bool runApplication = true;
            while (runApplication)
            {
                Console.WriteLine("This is Challenge #2, Claims.");
                Menu();
                int userInput = Int16.Parse(Console.ReadLine());

                switch(userInput)
                {
                    case 1:
                        break;
                    case 2:
                        DisplayAllClaims();
                        break;
                    case 3:
                        break;
                    case 4:
                        runApplication = false;
                        break;
                    default:
                        Console.WriteLine("I'm not sure what you mean. Please try again.");
                        break;
                }

            }
            
        }

        public void Menu()
        {
            //Just a method to print out a menu, nothing else.
            Console.WriteLine("Please enter the number of the operation you would like to perform:\n" +
                "1. See All Claims \n" +
                "2. Take Care Of Next Claim \n" +
                "3. Enter A New Claim\n" +
                "4. Exit.");

        }

        public void DisplayAllClaims()
        {
            Queue<Claim> claimsToDisplay = _claimRepo.GetAllClaims();

            foreach(Claim c in claimsToDisplay)
            {
                Console.WriteLine($"ClaimID: {c.ClaimID }");
            }
            Console.WriteLine("Please press any key to return to the main menu.");
            Console.ReadLine();
        }
    }
}
