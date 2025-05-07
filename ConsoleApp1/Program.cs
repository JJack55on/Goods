using System;
using ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    { 
        if (File.Exists("///Users/evgenijzavalov/Downloads/Market.csv"))
        {
            var markets = new List<Market>();
            var fruits = new List<Fruits>();
            StreamReader streamReader = File.OpenText("///Users/evgenijzavalov/Downloads/Market.csv");
            streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                //Console.WriteLine("1. Добавить товар в магазин");
                //Console.WriteLine("2. Сколько продано товара");
                //Console.WriteLine("3. Показать выручку магазинов");
                //Console.WriteLine("4. Сохранить данные в файл");

                var marketStock = streamReader.ReadLine().Split(',');

                var apples = new Fruits
                {
                    FruitName = "Apple",
                    Price = int.Parse(marketStock[2]),
                    Sold = int.Parse(marketStock[5]),
                    Quantity = int.Parse(marketStock[4]),
                };

                var oranges = new Fruits
                {
                    FruitName = "Orange",
                    Price = int.Parse(marketStock[3]),
                    Sold = int.Parse(marketStock[7]),
                    Quantity = int.Parse(marketStock[6]),
                };

                markets.Add(
                    new Market
                    {
                        StoreName = marketStock[0],
                        StoreSize = int.Parse(marketStock[1]),
                        fruitsList = new List<Fruits> { apples, oranges }
                    });
                
            }
            
            streamReader.Close();

            while (true)
            {
                Console.WriteLine("\nМеню управления магазинами:");
                Console.WriteLine("1. Добавить товар в магазин");
                Console.WriteLine("2. Показать информацию о проданных товарах");
                Console.WriteLine("3. Показать выручку магазинов (по убыванию)");
                Console.WriteLine("4. Сохранить данные в файл");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddFruit();
                        break;
                    case "2":
                        ShowSoldProducts();
                        break;
                    case "3":
                        ShowRevenueByShops();
                        break;
                    case "4":
                        SaveToCsv();
                        break;
                }
            }

            //Console.WriteLine("1. Добавить товар в магазин");
            //if (int.TryParse(Console.ReadLine(), out int quantity))
            //{
            //    apple.Quantity += int.Parse(data6[5]); // добавление товара на склад
            //    Console.WriteLine("Товар добавлен");
            //}

            foreach (var names in markets)
            {
                Console.WriteLine($"{names.StoreName}, {names.StoreSize},");
            }

            foreach (var products in fruits)
            {
                Console.WriteLine($"{products.FruitName}, {products.Price}," +
                                  $"{products.Quantity}, {products.Sold},");
            }

            // var fileContent=string.Join('\n', markets);
            // File.WriteAllText("market2.csv", fileContent);
        }
    }
}