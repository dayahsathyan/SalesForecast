CREATE TABLE [dbo].[Orders] (
    [OrderId]      NVARCHAR (255) NOT NULL,
    [OrderDate]    DATE           NULL,
    [ShipDate]     DATE           NULL,
    [ShipMode]     NVARCHAR (50)  NULL,
    [CustomerId]   NVARCHAR (50)  NULL,
    [CustomerName] NVARCHAR (255) NULL,
    [Segment]      NVARCHAR (50)  NULL,
    [Country]      NVARCHAR (50)  NULL,
    [City]         NVARCHAR (50)  NULL,
    [State]        NVARCHAR (50)  NULL,
    [PostalCode]   NVARCHAR (10)  NULL,
    [Region]       NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC)
);

