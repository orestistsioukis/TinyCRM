using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make a customer

            try
            {
                var dpnevmatikos = new Customer("Johnny", "Walker", "walker@net.com", 18);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            // manipulate the csv file

            string filePath = @"C:\Users\tsoiondell\devel\TinyCRM\TinyCrm\testFile.csv";

            List<Product> product = new List<Product>();
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries =  line.Split(';');

                Product newProduct = new Product();

                newProduct.ProductId = entries[0];
                newProduct.ProductName = entries[1];
                newProduct.Description = entries[2];

                product.Add(newProduct);
            }

            
        }
       

        public static double Price()
        {
            var price = RDouble() * RInt() * 10;
            return price;
        }
        public static double RDouble()
        {
            Random random = new Random();
            var value = random.NextDouble();
            return value;
        }
        public static int RInt()
        {
            Random random = new Random();
            var value = random.Next(1,10);
            return value;
        }

    }
    
}
