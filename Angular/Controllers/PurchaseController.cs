using System;
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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseServiceWrapper purchaseServiceWrapper;

        public PurchaseController(IPurchaseServiceWrapper PurchaseServiceWrapper)
        {
            purchaseServiceWrapper = PurchaseServiceWrapper;
        }

        // GET: api/Purchase
        [HttpGet]
        public IEnumerable<PurchaseDetails> GetPurchases()
        {
            return purchaseServiceWrapper.Get();
        }

        // GET: api/Purchase/5
        [HttpGet("{id}", Name = "GetPurchase")]
        public string GetPurchase(int id)
        {
            return "value";
        }

        // POST: api/Purchase
        [HttpPost]
        public PurchaseDetails PostPurchase([FromBody] PurchaseDetails value)
        {
            //if (value.ID == null || value.ID == 0)
                return purchaseServiceWrapper.Post(value);
            //else
            //{
            //    var isDelete = purchaseServiceWrapper.Delete((int)value.ID);
            //    return value;//should not be returning the same value, but just for the moment.
            //}
                
        }

        // PUT: api/Purchase/5
        [HttpPut("{id}")]
        public void PutPurchase(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [Route("DeletePurchase")]
        public PurchaseDetails DeletePurchase([FromBody] PurchaseDetails value)
        {
            return purchaseServiceWrapper.Delete(value);
        }
    }
}
