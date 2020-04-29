using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Customer
    {
        public DateTime Created { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Customer(string firstname, string lastname, string email , int age)
        {
            if (!IsAdult(age))
            {
                throw new Exception("You dont the proper age!");
            }else if (!IsValidEmail(email))
            {
                throw new Exception("Try entering a valid email please!");
            }else if (!IsValidName(firstname) || !IsValidName(lastname))
            {
                throw new Exception("Type a correct first and lastname");
            }else
            {
                Firstname = firstname;
                Lastname = lastname;
                Email = email;
                Created = DateTime.Now;
            }
        }

        public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            else  name = name.Trim();  
            return true;
        }
        public bool IsAdult(int age)
        {
            return age >= 18 && age < 100;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            email = email.Trim();

            int count = 0;
            foreach (char ch in email)
            {
                if (ch == '@') count++;
            }

            return count == 1 && (email.EndsWith(".com") || email.EndsWith(".gr"));
        }
    }
}
