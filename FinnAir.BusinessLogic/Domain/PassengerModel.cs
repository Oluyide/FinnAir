using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinnAir.BusinessLogic.Domain
{
    public class PassengerModel
    {   
        public int PassengerId { get; set; }
       
        public string Firstname { get; set; }
     
        public string LastName { get; set; }
        
        public string BookingId { get; set; }
    }

    public class CreatePassengerModel : PassengerModel
    {
        public string Email { get; set; }

        public List<FlightModel> Flights { get; set; }
    }
    
}
