using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTSample.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            //if (user != null)
            //{
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            //}

            return response;
        }
        private UserModel Authenticate(LoginModel login)
        {
            var    user = new UserModel { Name = "Mario Rossi", Email = "mario.rossi@domain.com" };
            return user;
        }
        private string BuildToken(UserModel user)
        {


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new System.Security.Claims.Claim("Role","A");

            var testclaims = new List<System.Security.Claims.Claim>
            {
                new Claim("Roles", "B")
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], testclaims, expires: DateTime.Now.AddMinutes(30),signingCredentials: creds);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
