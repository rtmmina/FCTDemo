using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using DataAccess.Contract;

namespace DataAccess.Implementation
{
    public class CustomerDAL : ICustomerDAL
    {

        public Customer Create(Customer customer)
        {
            customer.Email += "New";
            customer.Name += "New";
            customer.Password += "New";

            return customer;
        }

        public Customer Read(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
