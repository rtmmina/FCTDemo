using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace Service.Contract
{
    public interface IPurchaseService
    {
        List<PurchaseDetails> Read();
        PurchaseDetails Post(PurchaseDetails purchase);
        PurchaseDetails Delete(int id);
    }
}
