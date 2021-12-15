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
        public enum EventType { Golf = 1, Bowling, Amusement_Park, Concert};
        public EventType TypeOfEvent { get; set; }
        public int HeadCount { get; set; }
        public DateTime EventDate { get; set; }

        public decimal CostPerPerson { get; set; }
        public decimal EventTotalCost { get; set; }

        public Outing() { }

        public Outing(EventType typeOfEvent, int numberOfPeople, DateTime eventDate, decimal costPerPerson, decimal costForEvent)
        {
            TypeOfEvent = typeOfEvent;
            HeadCount = numberOfPeople;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
            EventTotalCost = costForEvent;
        }
    }
}
