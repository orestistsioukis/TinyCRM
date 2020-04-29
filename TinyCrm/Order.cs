using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TinyCrm
{
    class Order
    {
        public string OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; private set; }
    }
}
