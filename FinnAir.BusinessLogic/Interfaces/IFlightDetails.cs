using FinnAir.BusinessLogic.Domain;
using FinnAir.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinnAir.BusinessLogic.Interfaces
{
    public interface IFlightDetails : IDisposable
    {
        Task<List<PassengerModel>> GetPassengers(string flightNumber, DateTime departureTime);
        Task<CreatePassengerModel> GetPassengerById(int PassengerId);
    }

}
