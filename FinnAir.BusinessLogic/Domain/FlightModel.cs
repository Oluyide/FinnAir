using System;
using System.Collections.Generic;
using System.Text;

namespace FinnAir.BusinessLogic.Domain
{
    public class FlightModel
    {

        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
       
    }
}
