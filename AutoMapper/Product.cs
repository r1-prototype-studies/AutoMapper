﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string OptionalName { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}
