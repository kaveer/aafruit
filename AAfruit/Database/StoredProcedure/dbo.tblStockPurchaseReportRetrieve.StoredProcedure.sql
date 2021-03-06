USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblStockPurchaseReportRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[tblStockPurchaseReportRetrieve]
	@isSearch bit,
	@from datetime,
	@to datetime
AS
	BEGIN
		IF(@isSearch = 1)
			BEGIN
				SELECT 
					tud.Name, 
					tud.Surname, 
					tud.Company, 
					s.StockStatus, 
					CONVERT(date,s.Delivery) AS delivery, 
					s.Quantity, 
					s.PurchasePrice,
					f.FruitName
				FROM dbo.Stock s
				INNER JOIN dbo.tblUserDetails tud ON s.UserDetailsId = tud.UserDetailsId
				INNER JOIN dbo.Fruit f ON s.FruitId = f.FruitId
				WHERE CONVERT(date,s.Delivery) BETWEEN CONVERT(date,@from) AND CONVERT(date,@to) 
			END
		ELSE
			BEGIN
				SELECT 
					tud.Name, 
					tud.Surname, 
					tud.Company, 
					s.StockStatus, 
					CONVERT(date,s.Delivery) AS delivery, 
					s.Quantity, 
					s.PurchasePrice,
					f.FruitName
				FROM dbo.Stock s
				INNER JOIN dbo.tblUserDetails tud ON s.UserDetailsId = tud.UserDetailsId
				INNER JOIN dbo.Fruit f ON s.FruitId = f.FruitId
			END		
	END
GO
