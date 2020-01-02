using FinnAir.BusinessLogic.Domain;
using FinnAir.BusinessLogic.Interfaces;
using FinnAir.DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinnAir.BusinessLogic.Repository
{
    public  class FlightDetailsRepo : IFlightDetails
    {
        FinnAirContext context;
        private bool _disposed;
        public FlightDetailsRepo(FinnAirContext context)
        {
            this.context = context;
            _disposed = false;
        }

       public async  Task <List<PassengerModel>> GetPassengers(string flightNumber, DateTime departureTime)
        {
            var passengers =  await context.BookingFlights
                                     .Include(p => p.Booking)
                                     .Include(x => x.Flight)
                                     .Include(x => x.Booking.Passenger)
                                     .Where(x => x.Flight.FlightNumber == flightNumber && x.Flight.DepartureDate == departureTime)
                                     .SelectMany(x=>x.Booking.Passenger).Distinct().ToListAsync();

            var result = passengers.Select(p => new PassengerModel
            {
                PassengerId = p.Id,
                Firstname = p.Firstname,
                LastName = p.LastName,
                BookingId = p.BookingId
            }).ToList();
            return result;
        }

        public async Task<CreatePassengerModel> GetPassengerById(int passengerId)
        {
            var passsengerDetails = from p in context.Passengers.Where(x => x.Id == passengerId)
                                    select new CreatePassengerModel
                                    {
                                        PassengerId = p.Id,
                                        Firstname = p.Firstname,
                                        LastName = p.LastName,
                                        Email = p.Email,
                                        BookingId = p.BookingId,
                                        Flights = p.Booking.BookingFlight.Select(x => x.Flight).Select(flight => new FlightModel
                                        {
                                            FlightNumber = flight.CarrierCode + flight.FlightNumber,
                                            DepartureAirport = flight.DepartureAirport,
                                            ArrivalAirport = flight.ArrivalAirport,
                                            DepartureDate = flight.DepartureDate.ToString(),
                                            ArrivalDate = flight.ArrivalDate.ToString()
                                        }).ToList()
                                    };

            return await passsengerDetails.SingleOrDefaultAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                context.Dispose();
            }
            _disposed = true;
        }
    }
}
