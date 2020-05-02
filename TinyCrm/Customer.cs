using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCrm
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; private set; }
        public string Phone { get; set; }
        public decimal TotalGross { get;  set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }

        public List<Order> Orders = new List<Order>();

        public Customer(string vatNumber)
        {
            if (!IsValidVatNumber(vatNumber))
            {
                throw new Exception("Invalid VatNumber");
            }
            VatNumber = vatNumber;
            Created = DateTime.Now;
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            email = email.Trim();

            if (email.Contains("@") && (email.EndsWith(".com") || (email.EndsWith(".gr"))))
            {
                var count = email.Count(x => x == '@');

                return count == 1;
            }
            return false;
        }
        public bool IsValidVatNumber(string vatNumber)
        {
            return
                !string.IsNullOrWhiteSpace(vatNumber) &&
                vatNumber.Length == 9;
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }
    }
}