using System;
using System.Collections.Generic;
using System.Data;

namespace SalesForecastCommon.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public List<Product> Products { get; set; }

        public static Order FromDataRow(DataRow row)
        {
            return new Order
            {
                OrderId = GetField<string>(row, "OrderId"),
                OrderDate = GetField<DateTime?>(row, "OrderDate"),
                ShipDate = GetField<DateTime?>(row, "ShipDate"),
                ShipMode = GetField<string>(row, "ShipMode"),
                CustomerId = GetField<string>(row, "CustomerId"),
                CustomerName = GetField<string>(row, "CustomerName"),
                Segment = GetField<string>(row, "Segment"),
                Country = GetField<string>(row, "Country"),
                City = GetField<string>(row, "City"),
                State = GetField<string>(row, "State"),
                PostalCode = GetField<string>(row, "PostalCode"),
                Region = GetField<string>(row, "Region"),
                Products = new List<Product>()
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
