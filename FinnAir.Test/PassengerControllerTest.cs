using FinnAir.Api;
using FinnAir.BusinessLogic.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FinnAir.Test
{
    public class PassengerControllerTest : IntegrationTest
    {
        [Fact]
        public async Task GetAll_Passengers_In_A_Flight()
        {
            //Arrange
            await AuthenticateAsync();

            var request = TestClient.BaseAddress + GetPassengersUrl + "?flightNumber=FA2490&&departureDate=2019-12-12";

            //Act
            var response = await TestClient.GetAsync(request);

            //Assert
            (await response.Content.ReadAsStringAsync()).Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAll_Passengers_In_A_Flight_WithInvalid_FlightNumber()
        {
            //Arrange
            await AuthenticateAsync();

            var request = TestClient.BaseAddress + GetPassengersUrl + "?flightNumber=00000&&departureDate=2019-12-12";

            //Act
            var response = await TestClient.GetAsync(request);


            //Assert
            (await response.Content.ReadAsStringAsync()).Should().Equals("[]");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAll_Passengers_In_A_Flight_A_Case_Of_Missing_FlightNumber()
        {
            //Arrange
            await AuthenticateAsync();

            var request = TestClient.BaseAddress + GetPassengersUrl + "?flightNumber=&&departureDate=2019-12-12";

            //Act
            var response = await TestClient.GetAsync(request);

          
            //Assert
            (await response.Content.ReadAsStringAsync()).Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Get_Passenger_Flights_With_PassengerId()
        {
            //Arrange
            await AuthenticateAsync();
            int passegerId = 1;
            var request = TestClient.BaseAddress + GetPassengersUrl +"/"+passegerId.ToString();

            //Act
            var response = await TestClient.GetAsync(request);


            //Assert
            (await response.Content.ReadAsStringAsync()).Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Passenger_Flights_With_PassengerId_With_Wrong_PassengerId()
        {
            //Arrange
            await AuthenticateAsync();
            int passegerId = 89;
            var request = TestClient.BaseAddress + GetPassengersUrl + "/" + passegerId.ToString();

            //Act
            var response = await TestClient.GetAsync(request);

            //Assert
            (await response.Content.ReadAsStringAsync()).Should().Equals("Wrong Passenger Id");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


    }


}
