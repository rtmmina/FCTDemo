using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using Service.Contract;
using DataAccess.Contract;
using System.Security.Cryptography;

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
            customer.Password = ComputeSha256Hash(customer.Password);
            return _customerDAL.ValidateCustomer(customer);
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
