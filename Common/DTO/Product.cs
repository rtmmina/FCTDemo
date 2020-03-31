using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class Product
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }        
    }
}
