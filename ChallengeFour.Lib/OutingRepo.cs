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
        private readonly List<Outing> _OutingRepo = new List<Outing>();


        //checks a couple conditions of the outing to be added to the list then adds it to the list.
        public bool CreateOuting(Outing o)
        {
            if (o != null)
            {
                _OutingRepo.Add(o);
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
            return _OutingRepo;
        }

        public decimal CalculateCostOfAllOutings()
        {
            decimal costOfAlloutings = 0.00m;
            return costOfAlloutings;
        }
    }
}
