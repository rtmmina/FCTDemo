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
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        // GET: api/Purchase
        [HttpGet]
        public IActionResult GetPurchases()
        {
            return Ok(_purchaseService.Read());
        }

        // GET: api/Purchase/5
        [HttpGet("{id}", Name = "Get")]
        public string GetPurchase(int id)
        {
            return "value";
        }

        // POST: api/Purchase
        [HttpPost]
        public IActionResult PostPurchase([FromBody] PurchaseDetails value)
        {
            return Ok(_purchaseService.Post(value));
        }

        // PUT: api/Purchase/5
        [HttpPut("{id}")]
        public void PutPurchase(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        [Route("DeletePurchase")]
        [HttpPost]
        public IActionResult DeletePurchase(PurchaseDetails obj)
        {
            return Ok(_purchaseService.Delete(obj.ID ?? 0));
        }
    }
}
