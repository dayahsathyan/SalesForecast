BULK INSERT [Returns]FROM 'SP_Coding_Exercise_Dataset_product(Products).csv' WITH (		FIRSTROW = 2		,FIELDTERMINATOR = ','		,ROWTERMINATOR = '\r'		)GOALTER TABLE Products ADD FOREIGN KEY (OrderId) REFERENCES Orders (OrderId);