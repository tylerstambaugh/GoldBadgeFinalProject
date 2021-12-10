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
            _claimRepo.SeedData();
            RunApplication(); 
        }

        public void RunApplication()
        {
            bool runApplication = true;
            while (runApplication)
            {
                Console.Clear();
                Console.WriteLine("Kommodo Insurance Claims Application.");
                Menu();
                int userInput = Int16.Parse(Console.ReadLine());

                switch(userInput)
                {
                    case 1:
                        DisplayAllClaims();
                        break;
                    case 2:
                        HandleClaim();
                        break;
                    case 3:
                        EnterClaim();
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
            Console.Clear();
            Queue<Claim> claimsToDisplay = _claimRepo.GetAllClaims();

            foreach(Claim c in claimsToDisplay)
            {
                Console.WriteLine($"ClaimID: {c.ClaimID }");
            }
            Console.WriteLine("Please press any key to return to the main menu.");
            Console.ReadLine();
        }

        public void HandleClaim()
        {
            Claim claimToHandle = _claimRepo.GetNextClaim();
            Console.WriteLine($"ClaimID: {claimToHandle.ClaimID} \n" +
                $"Type: {claimToHandle.TypeOfClaim} \n" +
                $"Description: {claimToHandle.Description} \n" +
                $"Date Of Inncident: {claimToHandle.DateOfIncident}\n" +
                $"Date Of Claim: {claimToHandle.DateOfClaim} \n" +
                $"Is Valid: {claimToHandle.ClaimIsValid}");
            Console.WriteLine("Would you like to deal with this claim now? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            if(userInput == "y")
            {
                if(_claimRepo.HandleClaim())
                {
                    Console.WriteLine("The claim was handled. Please press any key to return to the menu.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Something went wrong attempting to dequeue the claim. Fix your code then try again.");
                    Console.ReadLine();
                }
            }
        }

        public void EnterClaim()
        {
            //if time alloes, add if else check to validate data.
            Console.WriteLine("Please enter the following fields.");
            Console.WriteLine("Claim ID:");
            int idOfClaim = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Claim Type: (1 = Car, 2 = Home, 3 = Theft");
            Claim.ClaimType typeOfClaim = (Claim.ClaimType)Int32.Parse(Console.ReadLine());
            Console.WriteLine("Description:");
            string descriptionOfClaim = Console.ReadLine();
            Console.WriteLine("Amount Claimed:");
            decimal amountOfClaim = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Date of Incident: (mm/dd/yyyy)");
            Console.ReadLine();
            DateTime dateOfIncident = DateTime.Now;
            Console.WriteLine("Date of Claim:");
            Console.ReadLine();
            DateTime dateOfClaim = DateTime.Now;
            bool isValid = _claimRepo.IsClaimValid(dateOfIncident, dateOfClaim);
            //check to see if the claim should be valid based on the dates and set the status appropriately when creating the claim.
            Claim claimToAdd = new Claim(idOfClaim, typeOfClaim, descriptionOfClaim, amountOfClaim, dateOfIncident, dateOfClaim, isValid);
            if (_claimRepo.CreateClaim(claimToAdd) == true)
            {
                Console.WriteLine("Wow. That actually worked. Please press any key to return to the menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error. The claim was not added successfully. Please press any key to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
