using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Market
    {
        public string StoreName { get; set; } // Название магазина

        public int StoreSize { get; set; } // Размер склада

        public List <Fruits> fruitsList { get; set; } = [];

        public void WriteName() 
        {
            Console.WriteLine($"{StoreName}");
        }
    }
}
