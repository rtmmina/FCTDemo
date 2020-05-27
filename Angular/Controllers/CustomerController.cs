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
        public IActionResult PostCustomer([FromBody] Customer value)
        {
            var customer = customerServiceWrapper.Post(value);            
            return Ok(customer);
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

        
    }
}
