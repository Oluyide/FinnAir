
using FinnAir.Api;
using FinnAir.Api.Contracts;
using FinnAir.Api.Contracts.Request;
using FinnAir.DataLayer.Model;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FinnAir.Test
{
   public  class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        protected const string LoginUrl = "/Identity/Login";
        protected const string GetPassengersUrl = "Passengers";
        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
            TestClient.BaseAddress = new Uri("https://localhost:44368");
       
        }

        public async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        private async Task<string> GetJwtAsync()
        {
            var response =  await TestClient.PostAsJsonAsync(LoginUrl, new UserRegistrationRequest
            {
                Email ="test@integration.com",
                Password= "SomePass@1234"
            });

            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();
            return registrationResponse.Token;
        }
    }
}
