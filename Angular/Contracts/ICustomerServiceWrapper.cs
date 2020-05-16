using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DTO;

namespace Angular.Contracts
{
    public interface ICustomerServiceWrapper
    {
        List<Customer> Get();
        Customer Post(Customer customer);
        Login ValidateLogin(Login customer);
    }
}
