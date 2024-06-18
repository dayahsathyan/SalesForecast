using SalesForecastCommon.Services;
using SalesForecastCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesForecastConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get user input for year
            Console.WriteLine("Enter the year to query sales data:");
            int year = int.Parse(Console.ReadLine());

            // Get sales data
            var salesData = ForecastingService.GetSalesData(year);
            double totalSales = salesData.Sum(saleData => saleData.TotalSales);
            Console.WriteLine($"\nTotal sales in year {year}: {totalSales}\n");

            Console.WriteLine("Enter percentage increment:");
            double percentage = double.Parse(Console.ReadLine());

            var salesIncrements = ForecastingService.ApplyIncrement(salesData, percentage);
            Console.WriteLine("{0,-20} {1,15} {2,20}", "State", "Original Sales", "Incremented Sales");
            foreach (var result in salesIncrements)
            {
                Console.WriteLine("{0,-20} {1,15} {2,20}", result.State, result.OriginalSales, result.IncrementedSales);
            }

            Console.WriteLine("\n\n{0,-20} {1,15} {2,20}", "State", "Original Sales", "Incremented Sales");

            // Optional: Apply individual percentages by state
            var percentagesByState = new Dictionary<string, double>
            {
                { "California", 10 },
                { "Texas", 15 },
                { "New York", 8 }
            };

            var incrementedDataByState = ForecastingService.ApplyIncrementByState(salesData, percentagesByState);

            foreach (var result in incrementedDataByState)
            {
                Console.WriteLine("{0,-20} {1,15} {2,20}", result.State, result.OriginalSales, result.IncrementedSales);
            }

            // Export to CSV
            string filePath = "forecast.csv";
            CsvExportService.ExportToCsv(salesIncrements, filePath);
            Console.WriteLine($"Forecast data exported to {filePath}");
        }
    }
}