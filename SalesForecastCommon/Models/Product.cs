using System;
using System.Data;

namespace SalesForecastCommon.Models
{
    public class Product
    {
        public string OrderId { get; set; }        // NVARCHAR (255) NULL
        public string ProductId { get; set; }      // NVARCHAR (50) NULL
        public string Category { get; set; }       // NVARCHAR (50) NULL
        public string SubCategory { get; set; }    // NVARCHAR (50) NULL
        public string ProductName { get; set; }    // NVARCHAR (255) NULL
        public double? Sales { get; set; }         // FLOAT (53) NULL
        public int? Quantity { get; set; }         // INT NULL
        public double? Discount { get; set; }      // FLOAT (53) NULL
        public double? Profit { get; set; }        // FLOAT (53) NULL

        public static Product FromDataRow(DataRow row)
        {
            return new Product
            {
                OrderId = GetField<string>(row, "OrderId"),
                ProductId = GetField<string>(row, "ProductId"),
                Category = GetField<string>(row, "Category"),
                SubCategory = GetField<string>(row, "SubCategory"),
                ProductName = GetField<string>(row, "ProductName"),
                Sales = GetField<double?>(row, "Sales"),
                Quantity = GetField<int?>(row, "Quantity"),
                Discount = GetField<double?>(row, "Discount"),
                Profit = GetField<double?>(row, "Profit")
            };
        }

        private static T GetField<T>(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
            {
                return row.Field<T>(columnName);
            }
            return default;
        }
    }

}
