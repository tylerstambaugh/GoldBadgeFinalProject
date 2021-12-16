using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour.Lib
{
    public class Outing
    {

                            //        Here are the parts of an outing:
                            //Event Type:   Golf, Bowling, Amusement Park, Concert
                            //Number of people that attended
                            //Date
                            //Total cost per person for the event
                            //Total cost for the event

        //POCO class, defines properties of 'outing' object and has it's constructors
        public enum OutingType { Golf = 1, Bowling, Amusement_Park, Concert};
        public OutingType TypeOfOuting { get; set; }
        public int HeadCount { get; set; }
        public DateTime OutingDate { get; set; }

        public decimal CostPerPerson { get; set; }
        public decimal OutingTotalCost { get; set; }

        public Outing() { }

        public Outing(OutingType typeOfOuting, int numberOfPeople, DateTime outingDate, decimal costPerPerson, decimal costForOuting)
        {
            TypeOfOuting = typeOfOuting;
            HeadCount = numberOfPeople;
            OutingDate = outingDate;
            CostPerPerson = costPerPerson;
            OutingTotalCost = costForOuting;
        }
    }
}
