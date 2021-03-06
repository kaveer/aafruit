USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblOrderRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblOrderRetrieve]
	@isStaff bit,
	@userDetailsId int,
	@orderType int
AS 
	BEGIN
		IF(@isStaff = 1)
			BEGIN
				SELECT *
				FROM dbo.Orders o
				INNER JOIN dbo.tblUserDetails tud ON tud.UserDetailsId = o.UserDetailsId
				INNER JOIN dbo.Fruit f ON f.FruitId = o.FruitId
				WHERE 
					o.OrderTypeId = @orderType
					AND o.OrderStatus = 1
				ORDER BY o.Deadline ASC
			END
		ELSE
			BEGIN
				SELECT *
				FROM dbo.Orders o
				INNER JOIN dbo.tblUserDetails tud ON tud.UserDetailsId = o.UserDetailsId
				INNER JOIN dbo.Fruit f ON f.FruitId = o.FruitId
				WHERE 
					o.OrderTypeId = @orderType
					AND o.OrderStatus = 1
					AND o.UserDetailsId = @userDetailsId
				ORDER BY o.Deadline ASC
			END
	END

GO
