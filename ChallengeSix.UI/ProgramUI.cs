using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeSix.Lib;

namespace ChallengeSix.UI
{
    class ProgramUI
    {
       
        private readonly CarRepo carRepo = new CarRepo();
        public void Run()
        {
            RunApplication();
        }

        public void RunApplication()
        {
            bool runApplication = true;

            while (runApplication)
            {
                Console.Clear();
                PrintMainMenu();
                if(!Int32.TryParse(Console.ReadLine(), out int userInput) || (userInput != 1 && userInput != 2 && userInput != 3 && userInput != 4 && userInput != 99))
                {
                    Console.WriteLine("Please enter a valid number. Press any key to return.");
                    Console.ReadKey();
                }
                else
                {
                    switch (userInput)
                    {
                        case 1:
                            AddVehicle();
                            break;
                        case 2:
                            ViewVehicles();
                            break;
                        case 3:
                            UpdateVehicle();
                            break;
                        case 4:
                            DeleteVehicle();
                            break;
                        case 99:
                            runApplication = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void AddVehicle()
        {
            Console.Clear();
            Console.WriteLine("Add Vehicle Sub-Routine AV1");
            Console.WriteLine("Please select the vehicle type: \n" +
                "1: Gas Vehicle \n" +
                "2: Electric Vehicle \n" +
                "3: Hybrid Vehicle");
            if(!Int32.TryParse(Console.ReadLine(), out int vehicleType) || (vehicleType < 1 || vehicleType > 3))
            {
                Console.WriteLine("Please enter a valid number. Press any key to return.");
                Console.ReadKey();
            }
            Console.WriteLine("Please enter the vehicle make:");
            string vehicleMake = Console.ReadLine();
            Console.WriteLine("Please enter the vehicle model:");
            string vehicleModel = Console.ReadLine();
            Console.WriteLine("Please enter the vehicle year (yyyy):");
            if(!Int32.TryParse(Console.ReadLine(), out int vehicleYear))
            {
                Console.WriteLine("Please enter a valid year. Press any key to return.");
                Console.ReadKey();
            }
            Console.WriteLine("Please enter the vehicle efficiency rating: (0 <= xxx.xx <= 100)");
            if(!Double.TryParse(Console.ReadLine(), out double efficiencyRating))
            {
                Console.WriteLine("Please enter a valid efficiency rating (0.00 - 100.00). Press any key to return.");
                Console.ReadKey();
            }
            if (vehicleType == 1)
            {
                //AddGasVehicle();
            }
            else if (vehicleType == 2)
            {
               // AddElectricVehicle();
            }
            else if (vehicleType == 3)
            {
                //AddHybridVehicle();
            }

        }

        


        public void ViewVehicles()
        {
            Console.Clear();
            Console.WriteLine("View Vehicle Sub-Routine VV1");

            List<Car> vehicles = carRepo.GetAllCars();
            foreach(Car c in vehicles)
            {
                Console.WriteLine(c.GetType());
                    
            }
            Console.ReadKey();
        }

        public void UpdateVehicle()
        {
            Console.Clear();
            Console.WriteLine("Update Vehicle Sub-Routine UV1");
            Console.ReadKey();
        }

        public void DeleteVehicle()
        {
            Console.Clear();
            Console.WriteLine("Delete Vehicle Sub-Routine DV1");
            Console.ReadKey();
        }
        public void PrintMainMenu()
        {
            Console.WriteLine("Vehicle Management Computer Application - Main Menu: \n" +
                "1. Add a Vehicle \n" +
                "2. Display Vehicle Information \n" +
                "3. Update a Vehicle \n" +
                "4. Delete a Vehicle \n" +
                "99. Exit");
        }
    }
}
    