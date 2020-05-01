﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }

        public List<Order> Orders = new List<Order>();

        public Product(string productId, string name)
        {
            ProductId = productId;
            Name = name;
        }
    }
}