using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace Service.Contract
{
    public interface IPurchaseService
    {
        List<Purchase> Read();
        Purchase Create(Purchase purchase);
    }
}
