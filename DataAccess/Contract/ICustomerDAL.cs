using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace DataAccess.Contract
{
    public interface ICustomerDAL
    {
        Customer Read(int ID);
        List<Customer> Read();
        Customer Create(Customer customer);
    }
}
