using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FinnAir.Api.Contracts;
using FinnAir.BusinessLogic.Domain;
using FinnAir.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinnAir.Api.Controllers
{
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IFlightDetailsService _flightDetails;
        private readonly ILogger _logger;
        public PassengersController(IFlightDetailsService flightDetails, ILogger<PassengersController> logger)
        {
            _flightDetails = flightDetails;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetPassengers(string flightNumber, string departureDate)
        {

            if (string.IsNullOrEmpty(flightNumber) || string.IsNullOrEmpty(departureDate))
            {
                string ErrorMessage = "Flight number cannot be empty and Departure Time must be in this format 'yyyy - MMM - dd'";
                _logger.LogInformation(ErrorMessage);
                return BadRequest(new FailResponse
                {
                    Errors = new[] { ErrorMessage },
                });
            }
            var passengers = await _flightDetails
                .GetPassengers(flightNumber, DateTime.Parse(departureDate));

                return Ok(passengers);
        }

        [HttpGet("{passengerId}")]
        public async Task<ActionResult> GetPassengerById(int passengerId)
        {
            var passenger = await _flightDetails.GetPassengerById(passengerId);
            if (passenger == null)
            {
                string ErrorMessage = "Wrong Passenger Id";
                _logger.LogInformation(ErrorMessage);
                return BadRequest(ErrorMessage);

            }
            return Ok(passenger);
        }

    }
}