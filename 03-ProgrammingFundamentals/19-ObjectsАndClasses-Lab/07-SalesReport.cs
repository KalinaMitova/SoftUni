using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SalesReport
{
    class Program
    {
        class Sale
        {
            public string Town { get; set; }
            public string Product { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }

        class TotalSalesByTown
        {
            public string Town { get; set; }
            public decimal TotalPrice { get; set; }
        }
        static void Main(string[] args)
        {
            var sales = ReadSales();

            var totalSalesByTown = CalcTotalSales(sales);

            foreach (var sale in totalSalesByTown)
            {
                Console.WriteLine($"{sale.Town} -> {sale.TotalPrice:F2}");
            }
        }

        private static List<TotalSalesByTown> CalcTotalSales(List<Sale> sales)
        {
            var totalSalesByTown = new SortedDictionary<string, decimal>();
            var totalSalesList = new List<TotalSalesByTown>();

            foreach (var sale in sales)
            {
                var town = sale.Town;
                if (!totalSalesByTown.ContainsKey(town))
                {
                    totalSalesByTown[town] = 0;
                }
                totalSalesByTown[town] += sale.Quantity * sale.Price;
            }

            foreach (var sale in totalSalesByTown)
            {
                totalSalesList.Add(new TotalSalesByTown
                {
                    Town = sale.Key,
                    TotalPrice = sale.Value
                });
            }

            return totalSalesList;
        }

        private static List<Sale> ReadSales()
        {
            var count = int.Parse(Console.ReadLine());
            var sales = new List<Sale>();

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine().Split();
                
                sales.Add(new Sale
                {
                    Town = line[0],
                    Product = line[1],
                    Price = decimal.Parse(line[2]),
                    Quantity = decimal.Parse(line[3])
                });
            }

            return sales;
        }
    }
}
