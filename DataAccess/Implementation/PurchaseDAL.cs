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

        public Purchase Create(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();

            return purchase;
        }

        public Purchase Read(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> Read()
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

            return data;
        }
    }
}
