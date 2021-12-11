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
        
        //seeds data and starts the application
        public void Run()
        {
            _claimRepo.SeedData();
            RunApplication(); 
        }

        //calls menu and takes user input, uses a switch case to determine which function to perform based on intup. 
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

        //Just a method to print out a menu, nothing else.
        public void Menu()
        {
            
            Console.WriteLine("Please enter the number of the operation you would like to perform:\n" +
                "1. See All Claims \n" +
                "2. Take Care Of Next Claim \n" +
                "3. Enter A New Claim\n" +
                "4. Exit.");
        }

        //foreach through queue of claims and write out their details.
        public void DisplayAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimsToDisplay = _claimRepo.GetAllClaims();
            Console.WriteLine("ClaimID \t Type \t Description \t Amount \t Date of Incident \t Date Of Claim \t Is Valid");
            if (claimsToDisplay.Count > 0)
            {
                foreach (Claim c in claimsToDisplay)
                {
                    Console.WriteLine($"{c.ClaimID } \t \t {c.TypeOfClaim} \t {c.Description} \t {c.ClaimAmount} \t {c.DateOfIncident.ToString("MM/dd/yyyy")} \t \t {c.DateOfClaim.ToString("MM/dd/yyyy")} \t {c.ClaimIsValid} ");
                }
            }
            else
            {
                Console.WriteLine("There are no claims to display.");
            }
            Console.WriteLine("Please press any key to return to the main menu.");
            Console.ReadLine();
        }

        //display next claim in queue and allow user to dequeue it
        public void HandleClaim()
        {
            Console.Clear();
            Claim claimToHandle = _claimRepo.GetNextClaim();
            if (claimToHandle != null)
            {
                Console.WriteLine($"ClaimID: {claimToHandle.ClaimID} \n" +
                    $"Type: {claimToHandle.TypeOfClaim} \n" +
                    $"Description: {claimToHandle.Description} \n" +
                    $"Date Of Inncident: {claimToHandle.DateOfIncident}\n" +
                    $"Date Of Claim: {claimToHandle.DateOfClaim} \n" +
                    $"Is Valid: {claimToHandle.ClaimIsValid}");
                Console.WriteLine("Would you like to deal with this claim now? (y/n)");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "y")
                {
                    if (_claimRepo.HandleClaim())
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
            else
            {
                Console.WriteLine("There are no claims to handle at the moment. Press any key to return.");
                Console.ReadLine();
            }
        }

        //prompt user to enter claim info, create claim object, add object to repo.
        public void EnterClaim()
        {
            
            //if time allows, add if else check to validate data.
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
            string dateOfIncidentString = Console.ReadLine();
            DateTime dateOfIncident = _claimRepo.ReturnDate(dateOfIncidentString);
            Console.WriteLine("Date of Claim: (mm/dd/yyyy");
            string dateOfClaimString = Console.ReadLine();
            DateTime dateOfClaim = _claimRepo.ReturnDate(dateOfClaimString);
            //check to see if the claim should be valid based on the dates and set the status appropriately before creating the claim.
            bool isValid = _claimRepo.IsClaimValid(dateOfIncident, dateOfClaim);
            
            Claim claimToAdd = new Claim(idOfClaim, typeOfClaim, descriptionOfClaim, amountOfClaim, dateOfIncident, dateOfClaim, isValid);
            if (_claimRepo.CreateClaim(claimToAdd) == true)
            {
                Console.WriteLine("Wow. That actually worked. Please press any key to return to the menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error. The claim was not added successfully. Probably something to do with the dates, there isn't really any error handling around those.  Please press any key to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
