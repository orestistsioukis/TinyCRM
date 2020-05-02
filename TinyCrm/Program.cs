using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] productsFromFile;

            try
            {
                productsFromFile = File.ReadAllLines("products.csv");
            }
            catch (Exception)
            {
                return;
            }

            if (productsFromFile.Length == 0)
            {
                return;
            }

            var productsList = new List<Product>();

            for (var i = 0; i < productsFromFile.Length; i++)
            {
                var values = productsFromFile[i].Split(';');
                var productId = values[0];

                //foreach (var p in productsArray) {
                //    if (p != null && p.ProductId.Equals(values[0])) {
                //        isDuplicate = true;
                //    }
                //}
                var l = productsList
                        .Where(product => product.ProductId.Equals(productId))
                        .Any();

                if (l)
                {
                    continue;
                }

                var product = new Product()
                {
                    ProductId = values[0],
                    Name = values[1],
                    Description = values[2],
                    Price = GetRandomPrice()
                };

                productsList.Add(product);
            }
            foreach (var p in productsList)
            {
                if (p != null)
                {
                    Console.WriteLine($"{p.ProductId} {p.Name} {p.Price}");

                }
            }

            // Assignment 2
            var customer1 = new Customer("123456789");
            var customer2 = new Customer("923456781");

            customer1.TotalGross = customer1.Orders.First().TotalAmount;
            customer2.TotalGross = customer2.Orders.First().TotalAmount;

            var productsSold = new List<Product>();
            productsSold.AddRange(customer1.Orders.First().Products);
            productsSold.AddRange(customer2.Orders.First().Products);

           

        }
        public static decimal GetRandomPrice()
        {
            var random = new Random();
            var randomNumber = random.NextDouble() * 100;
            var roundedNumber = Math.Round(randomNumber, 2);

            return (decimal)roundedNumber;
        }

        public static List<Product> GetRandomProduct(this List<Product> selectedPro, List<Program> prodList)
        {
            for (int i = 0; i < 10; i++)
            {
                var rnd = new Random();
                var rndProd = rnd.Next(0, prodList.Count);

                selectedPro.Add(prodList[rndProd]);
            }

            return selectedPro;
        }
    }
}