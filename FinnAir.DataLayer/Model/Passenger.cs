using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinnAir.DataLayer.Model
{
    public class Passenger
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(225)]
        public string Firstname { get; set; }
        [Required, MaxLength(225)]
        public string LastName { get; set; }
        [Required, MaxLength(225)]
        public string Email { get; set; }
        public string  BookingId { get; set; }
        public Booking Booking { get; set; }

    }
}
