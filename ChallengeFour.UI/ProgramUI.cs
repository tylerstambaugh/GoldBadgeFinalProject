using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour.UI
{
    public class ProgramUI
    {
        public void Run()
        {
            RunApplication();
        }

        public void RunApplication()
        {
            Console.WriteLine("Challenge 4: Company Outings \n");

            Console.ReadLine();
            bool runApplication = true;
            while(runApplication)
            {
                DisplayMenu();
                int userSelection;
                if(!Int32.TryParse(Console.ReadLine(), out userSelection))
                {
                    Console.WriteLine("Please enter a valid number. Press any key to return.");
                    Console.ReadKey();
                }
                else if (userSelection != 1 || userSelection != 2 || userSelection != 3 || userSelection != 4)
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


        private void AddOuting()
        {
            
            {
                Console.Clear();
                Console.WriteLine("Create an outing: \n");
                Console.WriteLine("What is the event type? \n" +
                    "1. Golf \n" +
                    "2. Bowling \n" +
                    "3. Amusement Park \n" +
                    "4. Concert");
                int eventTypeInt;
                if (!Int32.TryParse(Console.ReadLine(), out eventTypeInt))
                {
                    Console.WriteLine("Please enter a valid number. Press any key to try again.");
                    Console.ReadKey();
                    return;
                }
                else if (!(eventTypeInt <= 4) && !(eventTypeInt >= 1))
                {
                    Console.WriteLine("Please enter a valid number. Press any key to try again.");
                    Console.ReadKey();
                    return;
                }
            }

        }

        private void DisplayAllOutings()
        {
            throw new NotImplementedException();
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
