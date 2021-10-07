using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Classes
{
    public enum EEventType
    {
        Golf,
        Bowling,
        AmusementPark,
        Concert
    }

    public class Outing
    {
        public Outing() { }

        public Outing(EEventType eventType, int attendees, DateTime date, decimal customerCost, decimal eventCost)
        {
            EventType = eventType;
            Attendees = attendees;
            Date = date;
            CustomerCost = customerCost;
            EventCost = eventCost;
        }

        public EEventType EventType { get; set; }

        public int Attendees { get; set; }

        public DateTime Date { get; set; }

        public decimal CustomerCost { get; set; }

        public decimal EventCost { get; set; }
    }
}
