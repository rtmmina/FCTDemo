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
        public IEnumerable<Purchase> GetPurchases()
        {
            return _purchaseService.Read();
        }

        // GET: api/Purchase/5
        [HttpGet("{id}", Name = "Get")]
        public string GetPurchase(int id)
        {
            return "value";
        }

        // POST: api/Purchase
        [HttpPost]
        public Purchase PostPurchase([FromBody] Purchase value)
        {
            return _purchaseService.Create(value);
        }

        // PUT: api/Purchase/5
        [HttpPut("{id}")]
        public void PutPurchase(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeletePurchase(int id)
        {
        }
    }
}
