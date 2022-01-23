using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AnimalShelter.WebApp.Common
{
    public class JWTGenerator
    {
        public static string GenerateJSONWebToken()
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("y5&LCz#,p9kk!8B/"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("Name", "AnimalShelterWorker"),
                new Claim(JwtRegisteredClaimNames.Email, "")
            };

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
