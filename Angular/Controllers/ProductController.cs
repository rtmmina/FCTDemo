﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.DTO;
using Angular.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceWrapper productServiceWrapper;

        public ProductController(IProductServiceWrapper ProductServiceWrapper)
        {
            productServiceWrapper = ProductServiceWrapper;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var data = productServiceWrapper.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public string GetProduct(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult PostProduct([FromBody] Product value)
        {
            var product = productServiceWrapper.Post(value);
            return Ok(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void PutProduct(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
        }
    }
}
