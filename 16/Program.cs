using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;



namespace _16
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] table1 = Print1();
            string path2 = @"D:\Sveta\Задания\16\16\bin\Debug\Новая папка\Products.json";
            StreamWriter sw = new StreamWriter(path2, false);
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product()
                {
                    Code_product = uint.Parse(table1[i, 0]),
                    Name_product = table1[i, 1],
                    Price_product = float.Parse(table1[i, 2]),
                };
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                };
                string json = JsonSerializer.Serialize(product, options);
                Console.WriteLine(json);
                sw.WriteLine(json);
            }
            sw.Close();
            Console.ReadKey();
        }
        static string[,] Print1()
        {
            string[,] table1 = new string[5, 3];
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Введите код {0} товара: ", i + 1);
                table1[i, 0] = Console.ReadLine();
                Console.Write("Введите название {0} товара: ", i + 1);
                table1[i, 1] = Console.ReadLine();
                Console.Write("Введите цену {0} товара: ", i + 1);
                table1[i, 2] = Console.ReadLine();
                Console.WriteLine("\n");
            }
            return table1;
        }
    }
    public class Product
    {
        public uint Code_product { get; set; }
        public string Name_product { get; set; }
        public float Price_product { get; set; }
    }
}

