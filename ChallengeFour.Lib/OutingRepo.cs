using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour.Lib
{

                    //    Here's what they'd like:
                    //Display a list of all outings.
                    //Add individual outings to a list(don't need to worry about delete yet)
                    //Calculations:
                    //They'd like to see a display for the combined cost for all outings.
                    //They'd like to see a display of outing costs by type.
                    //For example, all bowling outings for the year were $2000.00. All Concert outings cost $5000.00.

    //CRUD methods/ service layer / business logic for the application.
    public class OutingRepo
    {
        private readonly List<Outing> _outingRepo = new List<Outing>();


        //checks a couple conditions of the outing to be added to the list then adds it to the list.
        public bool CreateOuting(Outing o)
        {
            if (o != null)
            {
                _outingRepo.Add(o);
                return true;
            }
            else
            {
                return false;
            }
        }

        //returns the list of outings for the UI to handle.
        public List<Outing> GetAllOutings()
        {
            return _outingRepo;
        }


        //returns the sum of OutingTotalCost in _outingRepo
        public decimal CalculateCostOfAllOutings()
        {
            decimal costOfAllOutings = 0.00m;
            if (_outingRepo.Count == 0)
            {
                costOfAllOutings = 0.00m;
            }
            else
            {
                foreach (Outing outing in _outingRepo)
                {
                    costOfAllOutings += outing.OutingTotalCost;
                }
            }
            return costOfAllOutings;
        }


        //takes in an OutingType and sums the cost of each outiing of that type. 
        //I put in a check to see if there were any outings of that type, but haven't done anything with it. I supposed I can handle if the total cost is zero on the UI side to display something user friendly.
        public decimal CalculateCostOfAllOutingsOfType(Outing.OutingType typeOfOuting)
        {
            int countOfOutingsOfType = 0;
            decimal costOfAlloutingsOfType = 0.00m;

            foreach (Outing outing in _outingRepo)
            {
                if(outing.TypeOfOuting == typeOfOuting)
                {
                    costOfAlloutingsOfType += outing.OutingTotalCost;
                    countOfOutingsOfType++;
                }
            }
            if (countOfOutingsOfType == 0)
            {
                costOfAlloutingsOfType = 0.00m;
            }

            return costOfAlloutingsOfType;
        }
       
        //returns a DateTime from a string in the proper mm/dd/yyyy format
        // no longer needed after figuring out DateTime.TryParseExact(). 
        public DateTime ReturnDateFromString(string stringDate)
        {
            int year = Int32.Parse(stringDate.Substring(6, 4));
            int month = Int32.Parse(stringDate.Substring(0, 2));
            int day = Int32.Parse(stringDate.Substring(3, 2));

            return new DateTime(year, month, day);
        }
    }
}
