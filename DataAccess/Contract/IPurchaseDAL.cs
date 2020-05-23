using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace DataAccess.Contract
{
    public interface IPurchaseDAL
    {
        PurchaseDetails Read(int ID);
        List<PurchaseDetails> Read();
        PurchaseDetails Create(PurchaseDetails purchase);
        PurchaseDetails Delete(int id);

    }
}
