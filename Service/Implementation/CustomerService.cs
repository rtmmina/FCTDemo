using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using Service.Contract;
using DataAccess.Contract;

namespace Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDAL _customerDAL;

        public CustomerService(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public Customer Create(Customer customer)
        {
            //return customer;
            customer.Email = customer.Email.Trim();
            customer.Name = customer.Name.Trim();
            customer.Password = customer.Password.Trim();
            return _customerDAL.Create(customer);
        }

        public Customer Read(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Read()
        {
            return _customerDAL.Read();
        }

        public Customer ValidateCustomer(Customer customer)
        {
            return _customerDAL.ValidateCustomer(customer);
        }
    }
}
