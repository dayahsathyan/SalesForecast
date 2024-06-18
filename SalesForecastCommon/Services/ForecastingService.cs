using SalesForecastCommon.Models;
using System.Collections.Generic;

namespace SalesForecastCommon.Services
{
    public static class ForecastingService
    {
        public static List<SalesData> GetSalesData(int year)
        {
            return DatabaseHelper.DatabaseHelper.GetSalesData(year);
        }

        public static List<SalesIncrement> ApplyIncrement(List<SalesData> salesData, double percentage)
        {
            List<SalesIncrement> salesIncrements = new List<SalesIncrement>();

            foreach (var data in salesData)
            {
                double incrementedSales = data.TotalSales + (data.TotalSales * percentage / 100);
                salesIncrements.Add(new SalesIncrement
                {
                    State = data.State,
                    OriginalSales = data.TotalSales,
                    IncrementedSales = incrementedSales
                });
            }

            return salesIncrements;
        }

        public static List<SalesIncrement> ApplyIncrementByState(List<SalesData> salesData, Dictionary<string, double> statePercentages)
        {
            List<SalesIncrement> salesIncrements = new List<SalesIncrement>();

            foreach (var data in salesData)
            {
                double incrementPercentage = 0;
                if (statePercentages.ContainsKey(data.State))
                {
                    incrementPercentage = statePercentages[data.State];
                }

                if (incrementPercentage != 0)
                {
                    double incrementedSales = data.TotalSales + (data.TotalSales * incrementPercentage / 100);
                    salesIncrements.Add(new SalesIncrement
                    {
                        State = data.State,
                        OriginalSales = data.TotalSales,
                        IncrementedSales = incrementedSales
                    });
                }
            }

            return salesIncrements;
        }
    }
}
