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
            var customerInDB = _context.Customers.FirstOrDefault(a => a.Email.Trim().ToUpper() == customer.Email.Trim().ToUpper());
            if(customerInDB == null)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                if(
                    customer.Name.ToUpper() != customerInDB.Name.ToUpper()
                    ||
                    customer.Password != customerInDB.Password
                    )
                {
                    customerInDB.Name = customer.Name;
                    customerInDB.Password = customer.Password;
                    _context.Update(customerInDB);
                }
            }

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

        public Customer ValidateCustomer(Customer customer)
        {
            var customerInDB = _context.Customers.FirstOrDefault(a => a.Email.ToUpper() == customer.Email.ToUpper() && a.Password == customer.Password);
            if (customerInDB?.ID > 0)
            {
                return customerInDB;
            }
            else
            {
                return customer;
            }            
        }
    }
}
