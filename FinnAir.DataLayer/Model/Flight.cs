using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinnAir.DataLayer.Model
{
    public class Flight
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string FlightNumber { get; set; }
        [Required, MaxLength(150)]
        public string CarrierCode { get; set; }
        [Required, MaxLength(150)]
        public string DepartureAirport { get; set; }
        [Required, MaxLength(3)]
        public string DepartureAirportCode { get; set; }
        [Required, MaxLength(150)]
        public string ArrivalAirport { get; set; }
        [Required, MaxLength(3)]
        public string ArrivalAirportCode { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        public ICollection<BookingFlight> BookingFlight { get; set; }
    }
}
