using System;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var dpnevmatikos = new Customer("123456789");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
    
}
