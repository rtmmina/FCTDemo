using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using DataAccess.Contract;
using DataAccess.Extensions;
using System.Linq;

namespace DataAccess.Implementation
{
    public class ProductDAL : IProductDAL
    {
        private readonly FCTContext _context;

        public ProductDAL(FCTContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            var productInDB = _context.Products.FirstOrDefault(a => a.Name.Trim().ToUpper() == product.Name.Trim().ToUpper());
            if(productInDB == null)
            {
                _context.Products.Add(product);
            }
            else
            {
                if(
                    product.Description.ToUpper() != productInDB.Description.ToUpper()
                    ||
                    product.Price != productInDB.Price
                    )
                {
                    productInDB.Description = product.Description;
                    productInDB.Price = product.Price;
                    _context.Update(productInDB);
                }
            }
            _context.SaveChanges();

            return product;
        }

        public Product Read(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Product> Read()
        {
            var data = new List<Product>();
            try
            {
                data = _context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return data;
        }
    }
}
