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
        public PurchaseDetails Post(PurchaseDetails purchase)
        {
            //return customer;
            if (purchase.ID == null || purchase.ID == 0)
                return _purchaseDAL.Create(purchase);
            else
                return _purchaseDAL.Delete((int)purchase.ID);
        }

        public PurchaseDetails Delete(int id)
        {
            return _purchaseDAL.Delete(id);
        }

        public List<PurchaseDetails> Read()
        {
            return _purchaseDAL.Read();
        }
    }
}
