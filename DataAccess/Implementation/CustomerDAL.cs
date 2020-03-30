using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using DataAccess.Contract;
using DataAccess.Extensions;
using System.Linq;

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

        public List<Customer> Read()
        {
            var data = new List<Customer>();
            try
            {
                data = _context.Customers.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            return data;
        }
    }
}
