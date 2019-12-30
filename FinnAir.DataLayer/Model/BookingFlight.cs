using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinnAir.DataLayer.Model
{
    public class BookingFlight
    {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       public string BookingId { get; set; }
       public Booking Booking { get; set; }
       public int FlightId { get; set; }
       public Flight Flight { get; set; }
    }
}
