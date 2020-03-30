﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTO;
using Angular.Contracts;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceWrapper customerServiceWrapper;

        public CustomerController(ICustomerServiceWrapper CustomerServiceWrapper)
        {
            customerServiceWrapper = CustomerServiceWrapper;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                return customerServiceWrapper.Get();
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
    }
}