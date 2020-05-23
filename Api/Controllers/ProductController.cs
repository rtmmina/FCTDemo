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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.Read());
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public string GetProduct(int id)
        {
            return $"you requested id = {id}";
        }

        // POST: api/Product
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        public IActionResult PostProduct([FromBody] Product request)
        {
            return Ok(_productService.Create(request));
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
