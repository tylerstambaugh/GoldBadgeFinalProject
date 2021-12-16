using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeFour.Lib;
using static ChallengeFour.Lib.Outing;

namespace ChallengeFour.UI
{
    public class ProgramUI
    {
        private readonly OutingRepo _outingRepo = new OutingRepo();
        public void Run()
        {
            RunApplication();
        }

        //displays the main menu and runs the method associated with the users selection.
        public void RunApplication()
        {
            Console.WriteLine("Challenge 4: Company Outings \n");
            bool runApplication = true;
            while(runApplication)
            {
                Console.Clear();
                DisplayMenu();
                int userSelection;
                if((!Int32.TryParse(Console.ReadLine(), out userSelection)) || (userSelection != 1 && userSelection != 2 && userSelection != 3 && userSelection != 4))
                {
                    Console.WriteLine("Please enter a valid number. Press any key to return.");
                    Console.ReadKey();
                }
                else
                {
                    switch(userSelection)
                    {
                        case 1:
                            DisplayAllOutings();
                                break;
                        case 2:
                            AddOuting();
                                break;
                        case 3:
                            OutingReporting();
                                break;
                        case 4:
                            runApplication = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        //runs through collecting the data from the user to create an outing. Will return the user to the main menu if they do not enter valid inputs. 
        private void AddOuting()
        {
            
            Console.Clear();
            Console.WriteLine("Create an outing: \n");

            //collect the outing type
            Console.WriteLine("What is the outing type? \n" +
                "1. Golf \n" +
                "2. Bowling \n" +
                "3. Amusement Park \n" +
                "4. Concert");
            int outingTypeInt;
            if ((!Int32.TryParse(Console.ReadLine(), out outingTypeInt)) || (!(outingTypeInt <= 4) || !(outingTypeInt >= 1)))
            {
                Console.WriteLine("Please enter a valid number. Press any key to try again.");
                Console.ReadKey();
                return;
            }
                
            OutingType typeOfOuting = (OutingType)outingTypeInt;
            //collect number of people that attended the outing
            Console.WriteLine("How many folks attended the outing?");
            int numPeople;
            if (!Int32.TryParse(Console.ReadLine(), out numPeople))
            {
                Console.WriteLine("Please enter a valid number. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            //collect the date of the outing
            Console.WriteLine("What was/is the date of the outing? (mm/dd/yyyy)");
            string dateAsString = Console.ReadLine();
            if (!DateTime.TryParseExact(dateAsString, "MM/dd/yyyy", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateOfOuting))
            {
                Console.WriteLine("Please enter a valid mm/dd/yyyy date. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            //collect cost per person
            Console.WriteLine("What was the cost per person? xxxx.xx");
            //decimal costPerPerson;
            if (!Decimal.TryParse(Console.ReadLine(), out decimal costPerPerson))
            {
                Console.WriteLine("Please enter a valid number. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            // collect total cost for event
            //Collecting these separately instead of calculating (number of people * cost per person) based on real world experience. A team outing may include a fixed cost and then a price per person in addition. It was considered, that is my point I suppose.
            Console.WriteLine("What was the total cost of the outing? xxxx.xx");
            // decimal costOfOuting;
            if (!Decimal.TryParse(Console.ReadLine(), out decimal costOfOuting))
            {
                Console.WriteLine("Please enter a valid number. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            //create the outing object
            Outing outingToAdd = new Outing(typeOfOuting, numPeople, dateOfOuting, costPerPerson, costOfOuting);
            if (_outingRepo.CreateOuting(outingToAdd))
            {
                Console.WriteLine("Outing created with successs. Press any key to return to the menu.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("The outing was not added. Please check your inputs and try again.");                   
                Console.ReadKey();
                return;
            }
        }

        //gets the list of outings from the repo and iterates through them printing out their details.
        private void DisplayAllOutings()
        {
            List<Outing> listOfOutings = _outingRepo.GetAllOutings();
            if (listOfOutings.Count == 0)
            {
                Console.WriteLine("There are no outings to display. Press any key to return.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(String.Format("|{0, -15}|{1, -18}|{2, -15}|{3, -18}|{4, -15}", "Outing Type", "Number Of People", "Outing Date", "Cost Per Person", "Cost Of Event"));
                printLine();
                foreach (Outing outing in listOfOutings)
                {
                    Console.WriteLine(String.Format("|{0, -15}|{1, -18}|{2, -15}|{3, -18}|{4, -15}", $"{outing.TypeOfOuting}", $"{outing.HeadCount}", $"{outing.OutingDate.ToString(string.Format("MM/dd/yyyy"))}", $"${outing.CostPerPerson}", $"${outing.OutingTotalCost}"));
                }
                Console.WriteLine("Press any key to return.");
                Console.ReadKey();
            }
        }

        //outing reporting menu and user selection
        private void OutingReporting()
        {
            bool keepDoing = true;
            while (keepDoing)
            {
                Console.Clear();
                Console.WriteLine("Outing Reporting Subsystem - Menu Giedi Prime\n" +
                    "Please select an option:\n" +
                    "1. Get Cost of All Outings \n" +
                    "2. Get Cost of All Outings of a Type \n" +
                    "3. Return to main menu");

                if((!Int32.TryParse(Console.ReadLine(), out int userSelection)) || (userSelection != 1 && userSelection != 2 && userSelection != 3))
                {
                    Console.WriteLine("Please enter a valid selection. Press any key to return.");
                    Console.ReadKey();
                    
                }
                else if (userSelection == 1)
                {
                    GetCostOfAllOutings();
                }
                else if (userSelection == 2)
                {
                    GetCostOfOutingsOfType();
                }
                else if (userSelection == 3)
                {
                    keepDoing = false;
                }
                else
                {
                    Console.WriteLine("I'm not sure what happened. You shouldn't have gotten here. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }


        //method broken out from the cost reporting menu above.
        private void GetCostOfAllOutings()
        {
            printLine();
            Console.WriteLine();
            Console.WriteLine($"The cost of all outings is ${_outingRepo.CalculateCostOfAllOutings()}. \n" +
                $"Press any key to return.");
            Console.ReadKey();
        }

        //method broken out from the cost reporting menu above.
        private void GetCostOfOutingsOfType()
        {
            printLine();
            Console.WriteLine();
            Console.WriteLine("For which outing type would you like to know the total cost of all outings of that type? \n" +
                "1. Golf \n" +
                "2. Bowling \n" +
                "3. Amusement Park \n" +
                "4. Concert");
            int outingTypeInt;
            if ((!Int32.TryParse(Console.ReadLine(), out outingTypeInt)) && ((outingTypeInt <= 4) && (outingTypeInt >= 1)))
            {
                Console.WriteLine("Please enter a valid number. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            OutingType typeOfOuting = (OutingType)outingTypeInt;
            Console.WriteLine($"The total cost for all {typeOfOuting} outings is {_outingRepo.CalculateCostOfAllOutingsOfType(typeOfOuting)} \n" +
                $"Press any key to return.");
            Console.ReadKey();
        }


        //just prints the menu, nothing else.
        public void DisplayMenu()
        {
            Console.WriteLine("Please select an Outing option: \n" +
                "1. Display list of all outings. \n" +
                "2. Add an Outing to the list. \n" +
                "3. Cost Reporting. \n" +
                "99. Exit");
        }


        //just prints a line for helping break out info on the display.
        public void printLine()
        {
            Console.WriteLine(new string('_', Console.WindowWidth));
        }
    }
}
