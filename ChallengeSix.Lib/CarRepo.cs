using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix.Lib
{
    public class CarRepo
    {
        //CRUD operations on local list of cars.

        //local list of cars to do business logic with
       
        
        private readonly List<Car> _carRepo = new List<Car>();


        //creat (add) a car to the list

        public bool AddVehicleToList(Car c)
        {
            if (c != null)
            {
                _carRepo.Add(c);
                return true;
            }
            else
            {
                return false;
            }

        }


        //update a car on the list



        //read out cars from the list

        public List<Car> GetAllCars()
        {
            return _carRepo;
        }
        //delete cars from the list

        // helper methods
    }
}
