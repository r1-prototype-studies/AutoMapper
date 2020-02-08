using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
   public  class Order
    {
        public string OrderNo { get; set; }
        public int NumberOfItems { get; set; }
        public int TotalAmount { get; set; }
        public Customer Customer { get; set; }
    }
}
