using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using Service.Contract;
using DataAccess.Contract;

namespace Service.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseDAL _purchaseDAL;

        public PurchaseService(IPurchaseDAL purchaseDAL)
        {
            _purchaseDAL = purchaseDAL;
        }
        public Purchase Create(Purchase purchase)
        {
            //return customer;
            return _purchaseDAL.Create(purchase);
        }

        public List<Purchase> Read()
        {
            return _purchaseDAL.Read();
        }
    }
}
