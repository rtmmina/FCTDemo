using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using Service.Contract;
using DataAccess.Contract;

namespace Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public Product Create(Product product)
        {
            product.Name = product.Name.Trim();

            return _productDAL.Create(product);
        }

        public Product Read(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Product> Read()
        {
            return _productDAL.Read();
        }
    }
}
