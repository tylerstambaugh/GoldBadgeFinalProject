using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSix.Lib
{
    public interface Car
    {
         string Make { get; set; }
         string Model { get; set; }
         int Year { get; set; }
         double EfficiencyRating { get; set; }


    }

    public interface GasVehicle : Car
    {
         double engineDisplacement { get; set; }
         double MilesPerGallon { get; set; }

    }

    public interface ElectricVehicle : Car
    {
         double batterySize { get; set; }
         TimeSpan ChargeTime { get; set; }
         int RangeInMiles { get; set; }

    }

    public class Hybrid : GasVehicle, ElectricVehicle
    {

    }
}
