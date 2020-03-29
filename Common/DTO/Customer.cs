using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class Customer
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
