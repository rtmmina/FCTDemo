using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using DataAccess.Contract;
using DataAccess.Extensions;

namespace DataAccess.Implementation
{
    public class CustomerDAL : ICustomerDAL
    {
        private readonly FCTContext _context;

        public CustomerDAL(FCTContext context)
        {
            _context = context;
        }
        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer Read(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
