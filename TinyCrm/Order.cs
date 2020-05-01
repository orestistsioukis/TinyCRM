using System;
using System.Collections.Generic;

namespace TinyCrm
{
    public class Order
    {
        public string OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }

        public List<Product> Products = new List<Product>();

        public Order(string id, string address)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(address))
                throw new Exception("Id or delivery address was invalid");

            OrderId = id;
            DeliveryAddress = address;
        }
    }
}