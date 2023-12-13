using System;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APAM_API.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace APAM_API.Helpers
{


    public class JwtHelper
    {

        public static string GenerateToken(IdentityUser user)
        {
            var SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUE");

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new APAM_APIContext()));
            foreach (var role in user.Roles)
            {
                var foundRole = roleManager.FindById(role.RoleId);

                if (foundRole != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, foundRole.Name));
                }
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(issuer, 
                  issuer,
                  claims,
                  expires: DateTime.Now.AddDays(1),
                  signingCredentials: credentials);

            return tokenHandler.WriteToken(token);
        }
    }

}