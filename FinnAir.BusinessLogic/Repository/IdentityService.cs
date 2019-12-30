using FinnAir.BusinessLogic.Domain;
using FinnAir.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace FinnAir.BusinessLogic.Repository
{
    public class IdentityService : IIdentityService
    {
        public readonly UserManager<IdentityUser> _userManager;

        public IdentityService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password, string secret)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email Address already exists" }
                };
            }
            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email,
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);
            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }
            return GenerateAuthenticationRResult(newUser, secret);
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password, string secret)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" }
                };
            }
            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if(!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Username or Password incorrect" }
                };
            }
            return GenerateAuthenticationRResult(user, secret);
            
        }

        private AuthenticationResult GenerateAuthenticationRResult(IdentityUser newUser, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
            
        }



    }
}
