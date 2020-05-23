using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using DataAccess.Contract;
using DataAccess.Extensions;
using System.Linq;

namespace DataAccess.Implementation
{
    public class PurchaseDAL : IPurchaseDAL
    {
        private readonly FCTContext _context;

        public PurchaseDAL(FCTContext context)
        {
            _context = context;
        }

        public PurchaseDetails Create(PurchaseDetails purchaseDetails)
        {
            var productId = _context.Products.FirstOrDefault(a => a.Name == purchaseDetails.ProductName).ID;
            var userId = _context.Customers.FirstOrDefault(a => a.Email == purchaseDetails.Email).ID;
            var purchase = new Purchase()
            {
                ProductID = (int)productId,
                UserID = (int)userId
            };
            _context.Purchases.Add(purchase);
            _context.SaveChanges();

            return purchaseDetails;
        }

        public PurchaseDetails Delete(int id)
        {
            Purchase result = new Purchase()
            {
                ID = id
            };
            try
            {
                var rec = _context.Purchases.FirstOrDefault(a => a.ID == id);
                _context.Purchases.Remove(rec);
                _context.SaveChanges();
                result.ID = 0;
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to delete purchase record with Id {id}");
            }
            return new PurchaseDetails()
            {
                ID =0
            };
        }

        public PurchaseDetails Read(int ID)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseDetails> Read()
        {
            var data = new List<Purchase>();
            try
            {
                data = _context.Purchases.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            var rData = new List<PurchaseDetails>();
            foreach(var rec in data)
            {
                var purchaseDetail = new PurchaseDetails()
                {
                    ID = rec.ID,
                    Email = _context.Customers.FirstOrDefault(a => rec.UserID == a.ID).Email,
                    ProductName = _context.Products.FirstOrDefault(a => rec.ProductID == a.ID).Name
                };
                rData.Add(purchaseDetail);
            }
            return rData;
        }
    }
}
