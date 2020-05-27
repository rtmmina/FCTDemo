using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Angular.Contracts;
using System.Text;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthorizatonController : ControllerBase
    {
        private readonly ICustomerServiceWrapper customerServiceWrapper;
        private IConfiguration _config;

        public JwtAuthorizatonController(ICustomerServiceWrapper CustomerServiceWrapper, IConfiguration config)
        {
            customerServiceWrapper = CustomerServiceWrapper;
            _config = config;
        }

        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login([FromBody] Login login)
        {        
            var result = customerServiceWrapper.ValidateLogin(login);
         
            if (result == null)
            {
                return BadRequest("Invalid client request");
            }

            if (result.ID != null && result.ID > 1)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44330",
                    audience: "https://localhost:44330",
                    claims: new List<Claim>() {
                        new Claim("EmailAddress", login.Email)
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                login.ID = result.ID;
                login.Name = result.Name;
                login.Email = login.Email;
                login.Token = tokenString;
                return Ok(login);
            }
            else
            {
                return Ok(login);
            }
        }

    }
}


