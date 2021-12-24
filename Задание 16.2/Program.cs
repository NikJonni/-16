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
            string jsonString = File.ReadAllText(path);
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            double max = products[0].ProductPrice;
            string expensive = products[0].ProductName;
            for (int i = 1; i < 5; i++)
            {
                if (products[i].ProductPrice > max)
                {
                    max = products[i].ProductPrice;
                    expensive = products[i].ProductName;
                }
            }
            Console.WriteLine("Самый дорогой товар: {0}", expensive);
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
