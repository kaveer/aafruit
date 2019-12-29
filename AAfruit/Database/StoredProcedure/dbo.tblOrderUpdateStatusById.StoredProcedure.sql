USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblOrderUpdateStatusById]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblOrderUpdateStatusById]
	@orderId int,
	@orderType int 
AS
	BEGIN
		UPDATE dbo.Orders
		SET
		    dbo.Orders.OrderTypeId = @orderType -- int
		where dbo.Orders.OrderId = @orderId
	END
GO
