using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace _16_
{
    class Program
    {
        static void Main(string[] args)
        {
            string path2 = @"D:\Sveta\Задания\16\16\bin\Debug\Новая папка\Products.json";
            Product product = new Product();
            int str = 0;
            int max = 0;
            string name = null;
            foreach (var line in File.ReadLines(path2))
            {
                product = JsonSerializer.Deserialize<Product>(line);               
                int price = (int)product.Price_product;
                Console.WriteLine(product.Code_product);
                Console.WriteLine(product.Name_product);
                Console.WriteLine(product.Price_product);
                Console.WriteLine();
                if (price > max)
                {
                    max = price;
                    name = product.Name_product;
                    str++;
                }               
            }           
            Console.WriteLine("\n{0} дороже всего - цена {1} ", name, max);
            Console.ReadKey();
        }
    }
    public class Product
    {
        public uint Code_product { get; set; }
        public string Name_product { get; set; }
        public float Price_product { get; set; }
    }
}