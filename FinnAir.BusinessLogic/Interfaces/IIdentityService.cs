using AutoMapper.Configuration;
using FinnAir.BusinessLogic.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinnAir.BusinessLogic.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password, string secret);
        Task<AuthenticationResult> LoginAsync(string email, string password, string secret);
    }
}
