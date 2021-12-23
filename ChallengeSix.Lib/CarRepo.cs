using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix.Lib
{
    class CarRepo
    {
        //CRUD operations on local list of cars.

        //local list of cars to do business logic with
        private readonly List<Car> _CarRepo = new List<Car>();

        //creat (add) a car to the list
        public bool AddCarToList(Car c)
        {
            if (c != null)
            {
                _CarRepo.Add(c);
                return true;
            }
            else
            {
                return false;
            }

        }

        //update a car on the list

        public bool UpdateCar(int carId)
        {
            foreach (Car c in _CarRepo)
            {
                if (c.Id == carId)
                {
                    //update the car details.
                    return true;

                }

                else
                {
                    return false;
                }
                
            }
            return false;
        }

        //read out cars from the list

        //delete cars from the list

        // helper methods
    }
}
