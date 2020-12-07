using System;
using System.Collections.Generic;
namespace Parser
{
    class Program
    {
        private static void Main()
        {
            using (ApplicationContext db = new ApplicationContext()) {
                try
                {
                    var avitoParser = new AvitoParser();

                    var productsTask = avitoParser.ParseHomePageProducts();

                    var products = productsTask.Result;

                    ShowProductList(products);

                    db.products.Add(products[0]);

                    db.SaveChanges();
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

            }

            Console.ReadLine();
        }

        private static void ShowProductList(ICollection<AvitoProduct> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.GetDataString());
            }
            Console.WriteLine($"Результатов: {products.Count}");
        }
    }
}