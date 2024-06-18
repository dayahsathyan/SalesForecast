using SalesForecastCommon.Models;
using System.Collections.Generic;
using System.IO;

namespace SalesForecastCommon.Utils
{
    public static class CsvExportService
    {
        public static void ExportToCsv(List<SalesIncrement> salesIncrements, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write headers
                writer.WriteLine("State,OriginalSales,IncrementedSales");

                // Write Data
                foreach (var salesIncrement in salesIncrements)
                {
                    writer.WriteLine($"{salesIncrement.State},{salesIncrement.OriginalSales},{salesIncrement.IncrementedSales}");
                }
            }
        }
    }
}
