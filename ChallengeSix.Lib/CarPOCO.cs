using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix.Lib
{

    //POCO has class objects and constructors. 
    public class Car
    {
        public  int VehicleID;
        public enum VehicleType {Gas, Electric, Hybrid};
        public int Id { get; set; }
        public VehicleType TypeOfVehicle { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double EfficiencyRating { get; set; }
    }

    public class GasVehicle : Car
    {
        protected double EngineDisplacement { get; set; }
        protected double MilesPerGallon { get; set; }

        public GasVehicle(string make, string model, int year, double rating, double displacement, double mpg)
        {
            VehicleID++;
            TypeOfVehicle = VehicleType.Gas;
            Make = make;
            Model = model;
            Year = year;
            EfficiencyRating = rating;
            EngineDisplacement = displacement;
            MilesPerGallon = mpg;
        }
    }

    public class ElectricVehicle : Car
    {
        protected double BatterySize { get; set; }
        protected TimeSpan ChargeTime { get; set; }
        protected int RangeInMiles { get; set; }

        public ElectricVehicle(string make, string model, int year, double rating, double batSize, TimeSpan chargeTime, int range)
        {
            VehicleID++;
            TypeOfVehicle = VehicleType.Electric;
            Make = make;
            Model = model;
            Year = year;
            EfficiencyRating = rating;
            BatterySize = batSize;
            ChargeTime = chargeTime;
            RangeInMiles = range;
        }
    }

    public class HybridVehicle : GasVehicle 
    {
        protected string FuelCell { get; set; }

        public HybridVehicle(string make, string model, int year, double rating, double displacement, double mpg, string fuelCell) : base(make, model, year, rating, displacement, mpg)
        {
            VehicleID++;
            TypeOfVehicle = VehicleType.Hybrid;
            Make = make;
            Model = model;
            Year = year;
            EfficiencyRating = rating;
            EngineDisplacement = displacement;
            MilesPerGallon = mpg;
            FuelCell = fuelCell;
        }
    }

}
