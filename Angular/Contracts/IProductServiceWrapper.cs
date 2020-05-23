using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DTO;

namespace Angular.Contracts
{
    public interface IProductServiceWrapper
    {
        List<Product> Get();
        Product Post(Product product);
    }
}
