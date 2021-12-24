using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Задание_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Папка\\Products.json";
            if (!File.Exists(path))
                File.Create(path);
            Product[] products = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Введите код, название и цену товара:");
                products[i] = new Product()
                {
                    ProductCode = Convert.ToInt32(Console.ReadLine()),
                    ProductName = Convert.ToString(Console.ReadLine()),
                    ProductPrice = Convert.ToDouble(Console.ReadLine())
                };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(jsonString);
            }
            Console.ReadKey();
        }
    }
    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
