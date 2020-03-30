using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace Service.Contract
{
    public interface IProductService
    {
        Product Read(int ID);
        List<Product> Read();
        Product Create(Product product);
    }
}
