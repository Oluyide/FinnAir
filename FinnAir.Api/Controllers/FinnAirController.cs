using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinnAir.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinnAir.Api.Controllers
{
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FinnAirController : ControllerBase
    {
        private readonly IFlightDetails _flightDetails;

        public FinnAirController(IFlightDetails flightDetails)
        {
            _flightDetails = flightDetails;
        }

        [HttpGet("api/v1/passengers")]
        public async Task<ActionResult> GetPassengers(string fightNumber, string departureDate)
        {
            var passengers = await _flightDetails.GetPassengers(fightNumber, DateTime.Parse(departureDate));
            
            return Ok(passengers);
        }
        [HttpGet("api/v1/passenger")]
        public async Task<ActionResult> GetPassengers(int passengerId)
        {
            var passenger =  await _flightDetails.GetPassengerById(passengerId);

            return Ok(passenger);
        }

    }
}