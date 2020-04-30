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
               // adding random prices{not correct}
                AddPriceValue(product);

                product.Add(newProduct);
            }

            foreach (var prod  in product)
            {
                Console.WriteLine($"{prod.ProductId} : {prod.ProductName} : {prod.Description} : {prod.Price}");
            }
        }

        public static void AddPriceValue(List<Product> products)
        {
            Random random = new Random();
            foreach (Product item in products)
            {
                item.Price = Convert.ToDecimal(Math.Round((random.NextDouble()) * 10, 2));
            }
        }

    }
    
}
