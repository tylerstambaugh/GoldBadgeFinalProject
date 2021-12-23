using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix.Lib
{
    public abstract class Car
    {
        public int Id { get; set; }
        protected string Make { get; set; }
        protected string Model { get; set; }
        protected int Year { get; set; }
        protected double EfficiencyRating { get; set; }


    }

    public class GasVehicle : Car
    {
        protected double engineDisplacement { get; set; }
        protected double MilesPerGallon { get; set; }

    }

    public class ElectricVehicle : Car
    {
        protected double batterySize { get; set; }
        protected TimeSpan ChargeTime { get; set; }
        protected int RangeInMiles { get; set; }

    }

    public class Hybrid : GasVehicle 
    {
        protected string FuelCell { get; set; }
    }

}
