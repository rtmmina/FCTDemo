using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace DataAccess.Contract
{
    public interface IProductDAL
    {
        Product Read(int ID);
        List<Product> Read();
        Product Create(Product product);
    }
}
