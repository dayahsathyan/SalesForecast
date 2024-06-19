# SalesForecast Project

## Introduction
The SalesForecast project is designed to analyze and predict sales data. It includes components for data storage, data access, and a console application for interacting with the data.

## Project Structure
The solution is divided into several projects:
1. **SalesForecastCommon**: Contains common classes and database helper methods.
2. **SalesForecastConsoleApp**: A console application for querying and displaying sales data.
3. **SalesForecastDB**: Contains SQL scripts and database schema definitions.

## SalesForecastCommon
### Models
- **Order.cs**: Represents an order.
- **Product.cs**: Represents a product.
- **SalesData.cs**: Represents sales data, including state and total sales.
- **SalesIncrement.cs**: Represents sales increment data for forecasting purposes.

### DatabaseHelper
- **DatabaseHelper.cs**: Provides methods to interact with the database, including:
  - `GetSalesData(int year)`: Retrieves sales data for a specific year.

## SalesForecastConsoleApp
### Program.cs
The main entry point of the console application. It uses `DatabaseHelper` to fetch and display sales data.

## SalesForecastDB
### Tables
- **Orders.sql**: Script to create the Orders table.
- **Products.sql**: Script to create the Products table.
- **Returns.sql**: Script to create the Returns table.

### Scripts
- **BulkInsertOrders.sql**: Script for bulk inserting orders.
- **BulkInsertProducts.sql**: Script for bulk inserting products.
- **BulkInsertReturns.sql**: Script for bulk inserting returns.

## How to Run
1. Ensure you have SQL Server installed and running.
2. Execute the SQL scripts in `SalesForecastDB` to set up the database schema and insert sample data.
3. Build the solution using Visual Studio.
4. Run `SalesForecastConsoleApp` to query and display sales data.

## Usage
The console application allows users to:
1. Query sales data for a specific year.
2. Apply a percentage increment to simulate sales increase for the next year.
3. Download forecasted data to a CSV file.

## Conclusion
This project provides a comprehensive solution for analyzing and forecasting sales data using a console application. The database helper methods and models make it easy to interact with and manipulate sales data.
