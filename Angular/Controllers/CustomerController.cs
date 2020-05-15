using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTO;
using Angular.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceWrapper customerServiceWrapper;
        private IConfiguration _config;

        public CustomerController(ICustomerServiceWrapper CustomerServiceWrapper, IConfiguration config)
        {
            customerServiceWrapper = CustomerServiceWrapper;
            _config = config;
        }
        // GET: api/Customer
        [HttpGet]
        [Authorize]
        public IActionResult GetCustomers()
        {
            //var user = HttpContext.User;
            try
            {
                return Ok(customerServiceWrapper.Get());
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public string GetCustomer(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public Customer PostCustomer([FromBody] Customer value)
        {
            var customer = customerServiceWrapper.Post(value);            
            return customer;
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void PutCustomer(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
        }

        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login([FromBody] UserModel login)
        {
            //return customerServiceWrapper.ValidateLogin(customer);
            login.Username = "johndoe";
            login.EmailAddress = "johndoe";
            login.Password = "def@123";

            if (login == null)
            {
                return BadRequest("Invalid client request");
            }

            if (login.Username == "johndoe" && login.Password == "def@123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44330",
                    audience: "https://localhost:44330",
                    claims: new List<Claim>() { 
                        new Claim("Username", login.Username),
                        new Claim("EmailAddress", login.EmailAddress)
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        //private string GenerateJSONWebToken(UserModel userInfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private UserModel AuthenticateUser(UserModel login)
        //{
        //    UserModel user = null;

        //    //Validate the User Credentials    
        //    //Demo Purpose, I have Passed HardCoded User Information    
        //    if (login.Username == "Jignesh")
        //    {
        //        user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
        //    }
        //    return user;
        //}
    }
}
