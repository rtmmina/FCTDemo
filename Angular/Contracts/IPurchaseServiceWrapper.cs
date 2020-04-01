using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DTO;

namespace Angular.Contracts
{
    public interface IPurchaseServiceWrapper
    {
        List<PurchaseDetails> Get();
        PurchaseDetails Post(PurchaseDetails purchase);
        bool Delete(int id);
    }
}
