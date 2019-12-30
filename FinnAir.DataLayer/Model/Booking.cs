using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinnAir.DataLayer.Model
{
    public class Booking
    {
        [Key]
        [Required, MaxLength(6)]
        public string Id { get; set; }
        public ICollection<Passenger> Passenger { get; set; }
        public ICollection<BookingFlight> BookingFlight { get; set; }
    }
}
