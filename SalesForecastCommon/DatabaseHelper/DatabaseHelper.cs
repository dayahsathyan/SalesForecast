using SalesForecastCommon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SalesForecastCommon.DatabaseHelper
{
    public class DatabaseHelper
    {
        private static string connectionString = "Server=LAPTOP-EQTN9BP6\\SAMURAI; Database=TestDaya; Trusted_Connection=True;";

        public static List<SalesData> GetSalesData(int year)
        {
            List<SalesData> salesData = new List<SalesData>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT State, SUM(Sales) AS TotalSales
                FROM Products p
                INNER JOIN Orders o ON o.orderid = p.orderid
                LEFT JOIN Returns r ON o.orderid = r.orderid
                WHERE YEAR(OrderDate) = @Year
                    AND r.orderid IS NULL
                GROUP BY State";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", year);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    salesData.Add(new SalesData
                    {
                        State = reader["State"].ToString(),
                        TotalSales = Convert.ToDouble(reader["TotalSales"])
                    });
                }
            }
            return salesData;
        }
    }
}
