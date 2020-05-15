using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTO;
using Service.Contract;
using System.Net;

namespace Api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerService.Read();
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public string GetCustomer(int id)
        {
            return $"you requested id = {id}";
        }

        // POST: api/Customer
        [HttpPost]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.NotFound)]
        public Customer PostCustomer([FromBody] Customer request)
        {            
            return _customerService.Create(request);
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

        [Route("ValidateCustomer")]
        public Customer ValidateCustomer(Customer customer)
        {
            return _customerService.ValidateCustomer(customer);
        }
    }
}
