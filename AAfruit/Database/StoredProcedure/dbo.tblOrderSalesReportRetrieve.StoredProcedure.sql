USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblOrderSalesReportRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblOrderSalesReportRetrieve]
	@isSearch bit,
	@from datetime,
	@to datetime
AS
	BEGIN
		IF(@isSearch = 1)
			BEGIN
				SELECT 
					tud.Company, 
					CONVERT(date, o.RequestedDate) RequestedDate, 
					CONVERT(date, o.Deadline) Deadline, 
					o.Quantity, 
					o.TotalPrice, 
					o.DiscountValue, 
					o.DiscountTotalPrice, 
					ot.OrderTypeId,
					f.FruitName
				FROM dbo.Orders o
				INNER JOIN dbo.OrderType ot ON o.OrderTypeId = ot.OrderTypeId
				INNER JOIN dbo.tblUserDetails tud ON o.UserDetailsId = tud.UserDetailsId
				INNER JOIN dbo.Fruit f ON o.FruitId = f.FruitId
				WHERE
					CONVERT(date,o.RequestedDate) BETWEEN CONVERT(date,@from) AND CONVERT(date,@to) 
					AND o.OrderTypeId NOT IN (1) 
			END
		ELSE
			BEGIN
				SELECT 
					tud.Company, 
					CONVERT(date, o.RequestedDate) RequestedDate, 
					CONVERT(date, o.Deadline) Deadline, 
					o.Quantity, 
					o.TotalPrice, 
					o.DiscountValue, 
					o.DiscountTotalPrice, 
					ot.OrderTypeId,
					f.FruitName
				FROM dbo.Orders o
				INNER JOIN dbo.OrderType ot ON o.OrderTypeId = ot.OrderTypeId
				INNER JOIN dbo.tblUserDetails tud ON o.UserDetailsId = tud.UserDetailsId
				INNER JOIN dbo.Fruit f ON o.FruitId = f.FruitId
				WHERE o.OrderTypeId NOT IN (1)
			END		
	END
GO
