using System;
using System.Collections.Generic;
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
                if(!Int32.TryParse(Console.ReadLine(), out userSelection))
                {
                    Console.WriteLine("Please enter a valid number. Press any key to return.");
                    Console.ReadKey();
                }
                else if (userSelection != 1 && userSelection != 2 && userSelection != 3 && userSelection != 4)
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
            if (!Int32.TryParse(Console.ReadLine(), out outingTypeInt))
            {
                Console.WriteLine("Please enter a valid number. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            else if (!(outingTypeInt <= 4) || !(outingTypeInt >= 1))
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
            //DateTime thisDate1 = new DateTime(2011, 6, 10);
            Console.WriteLine("What was/is the date of the outing? (mm/dd/yyyy)");
            string dateAsString = Console.ReadLine();
            DateTime dateOfOuting = _outingRepo.ReturnDateFromString(dateAsString);

            //collect cost per person
            Console.WriteLine("What was the cost per person? xxxx.xx");
            decimal costPerPerson;
            if(!Decimal.TryParse(Console.ReadLine(), out costPerPerson))
            {
                Console.WriteLine("Please enter a valid number. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            // collect total cost for event
            Console.WriteLine("What was the total cost of the outing? xxxx.xx");
            decimal costOfOuting;
            if (!Decimal.TryParse(Console.ReadLine(), out costOfOuting))
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
            }
            else
            {
                Console.WriteLine("The outing was not added. Please check your inputs and try again.");
                Console.ReadKey();
            }
        }

        
        private void DisplayAllOutings()
        {
            List<Outing> listOfOutings = _outingRepo.GetAllOutings();
            Console.WriteLine(String.Format("|{0, -15}|{1, -18}|{2, -15}|{3, -18}|{4, -15}", "Outing Type", "Number Of People", "Outing Date", "Cost Per Person", "Cost Of Event"));
            foreach (Outing outing in listOfOutings)
            {
                Console.WriteLine(String.Format("|{0, -15}|{1, -18}|{2, -15}|{3, -15}|{4, -15}",$"{outing.TypeOfOuting}", $"{outing.HeadCount}", $"{outing.OutingDate}", $"{outing.CostPerPerson}", $"{outing.OutingTotalCost}"));
            }
            Console.WriteLine("Press any key to return.");
            Console.ReadKey();
        }

        private void OutingReporting()
        {
            throw new NotImplementedException();
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

       
    }
}
