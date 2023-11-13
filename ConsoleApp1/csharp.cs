using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GardenToolsInventory
{
    class GardenTool
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }

        public GardenTool(string name, double price, int stock, string brand, Category category)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Brand = brand;
            Category = category;
        }
    }

    enum Category
    {
        GardenTools,
        OutdoorTools
    }

    class Program
    {
        static void Main()
        {
            List<GardenTool> gardenTools = new List<GardenTool>
            {
                new GardenTool("Лопата", 10, 5, "Fiskars", Category.GardenTools),
                new GardenTool("Грабли", 7, 3, "Gardena", Category.GardenTools),
                new GardenTool("Секатор", 20, 2, "BOSCH", Category.GardenTools),
                new GardenTool("Совок", 4, 6, "Grinda", Category.GardenTools)
            };

            Console.WriteLine("Инвентарная ведомость садовых принадлежностей:");
            foreach (var tool in gardenTools)
            {
                Console.WriteLine($"{tool.Name} - {tool.Price:C2} - {tool.Stock} - {tool.Brand} - {tool.Category}");
            }

            Console.WriteLine("\nИнструменты бренда BOSCH, отсортированные по цене:");

            var boschTools = gardenTools.Where(x => x.Brand == "BOSCH").OrderBy(x => x.Price);

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var item in boschTools)
                {
                    writer.WriteLine($"{item.Name} - {item.Price:C2} - {item.Stock} - {item.Brand} - {item.Category}");
                }
            }

            Console.WriteLine("Информация записана в файл 'output.txt'.");
        }
    }
}
