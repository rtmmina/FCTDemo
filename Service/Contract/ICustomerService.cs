using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;

namespace Service.Contract
{
    public interface ICustomerService
    {
        Customer Read(int ID);
        Customer Create(Customer customer);
    }
}
