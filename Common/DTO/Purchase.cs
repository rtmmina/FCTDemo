using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class Purchase
    {
        public int? ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }
}
