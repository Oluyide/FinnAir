using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinnAir.DataLayer.Model
{
    public class FinnAirContext : IdentityDbContext
    {
        public FinnAirContext(DbContextOptions<FinnAirContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<BookingFlight> BookingFlights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = "FIN123" },
                new Booking { Id = "FIN124" },
                new Booking { Id = "FIN125" },
                new Booking { Id = "FIN126" },
                new Booking { Id = "FIN127" },
                new Booking { Id = "FIN128" }
               );

            modelBuilder.Entity<Passenger>().HasData(
                new Passenger {Id =1, Firstname = "Gbenga", LastName = "Oluyide", Email = "gbengaoluyide@gmail.com", BookingId = "FIN123" },
                new Passenger {Id =2, Firstname = "Sade", LastName = "Oluyide", Email = "sadeoluyide@gmail.com", BookingId = "FIN124" },
                new Passenger {Id= 3, Firstname = "Gbade", LastName = "Oluyide", Email = "gbade@gmail.com", BookingId = "FIN125" },
                new Passenger {Id= 4, Firstname = "Bayo", LastName = "Oluyide", Email = "bayo@gmail.com", BookingId = "FIN126" },
                new Passenger {Id= 5, Firstname = "Biibire", LastName = "Oluyide", Email = "biibire@gmail.com", BookingId = "FIN127" },
                new Passenger {Id= 6, Firstname = "Omolara", LastName = "Oluyide", Email = "omolaraoluyide@gmail.com", BookingId = "FIN128" }
               );

            modelBuilder.Entity<Flight>().HasData(
               new Flight {Id = 1, FlightNumber = "FA2490", CarrierCode = "W12", DepartureAirport = "Stuttgart", DepartureAirportCode = "STU", ArrivalAirport = "Brussel", ArrivalAirportCode = "BRU", DepartureDate = DateTime.Parse("2019-12-12"), ArrivalDate = DateTime.Parse("2019-12-13") },
               new Flight {Id = 2, FlightNumber = "FA2490", CarrierCode = "A11", DepartureAirport = "Stuttgart", DepartureAirportCode = "STU", ArrivalAirport = "Brussel", ArrivalAirportCode = "BRU", DepartureDate = DateTime.Parse("2019-12-12"), ArrivalDate = DateTime.Parse("2019-12-13") },
               new Flight {Id = 3, FlightNumber = "FA2490", CarrierCode = "B13", DepartureAirport = "Stuttgart", DepartureAirportCode = "STU", ArrivalAirport = "Brussel", ArrivalAirportCode = "BRU", DepartureDate = DateTime.Parse("2019-12-12"), ArrivalDate = DateTime.Parse("2019-12-13") },
               new Flight {Id = 4,  FlightNumber = "FA2490", CarrierCode = "C15", DepartureAirport = "Stuttgart", DepartureAirportCode = "STU", ArrivalAirport = "Brussel", ArrivalAirportCode = "BRU", DepartureDate = DateTime.Parse("2019-12-12"), ArrivalDate = DateTime.Parse("2019-12-13") }
              );
            modelBuilder.Entity<BookingFlight>().HasData(
              new BookingFlight {Id =1, BookingId = "FIN123", FlightId = 1 },
              new BookingFlight {Id=2, BookingId = "FIN124", FlightId = 3 },
              new BookingFlight {Id=3, BookingId = "FIN124", FlightId = 2 },
              new BookingFlight {Id=4, BookingId = "FIN125", FlightId = 1 },
              new BookingFlight {Id=5, BookingId = "FIN125", FlightId = 4 }
             );
        }
    }
       


}
