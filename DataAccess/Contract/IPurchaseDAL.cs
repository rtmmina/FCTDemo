using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace DataAccess.Contract
{
    public interface IPurchaseDAL
    {
        Purchase Read(int ID);
        List<Purchase> Read();
        Purchase Create(Purchase purchase);
    }
}
