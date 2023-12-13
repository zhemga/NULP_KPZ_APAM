using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using APAM_API.Data;
using APAM_API.Models.Auth;
using APAM_API.Models.Identity_Users;
using APAM_API.Models.IdentityUsers;
using APAM_API.Helpers;

namespace APAM_API.Auth.Controllers
{
    public class AuthController : ApiController
    {
        private UserManager<IdentityUser> userManager;

        public AuthController()
        {
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new APAM_APIContext()));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = null;

            if (model.Role == nameof(AutoPartSupplier))
            {
                result = await userManager.CreateAsync(new AutoPartSupplier { UserName = model.UserName }, model.Password);
            }
            else if (model.Role == nameof(Customer))
            {
                result = await userManager.CreateAsync(new Customer { UserName = model.UserName }, model.Password);
            }
            else if (model.Role == nameof(Seller))
            {
                result = await userManager.CreateAsync(new Seller { UserName = model.UserName }, model.Password);
            }

            if (result != null && result.Succeeded)
            {
                // Assign the user to the specified role
                if (!string.IsNullOrEmpty(model.Role) && userManager.SupportsUserRole)
                {
                    var user = await userManager.FindAsync(model.UserName, model.Password);
                    await userManager.AddToRoleAsync(user.Id, model.Role);

                    var token = JwtHelper.GenerateToken(user);
                    return Ok(new { Token = token });
                }
            }

            return BadRequest("Registration failed: " + string.Join(", ", result.Errors));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/Login")]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = JwtHelper.GenerateToken(user);
                return Ok(new { Token = token });
            }

            return BadRequest("Invalid username or password.");
        }

    }
}
