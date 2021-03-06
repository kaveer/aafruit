USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblSockUpsert]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblSockUpsert]
	@stockid int,
	@userDetailsId int,
	@fruitId int,
	@status bit,
	@DeliveryDate datetime,
	@note varchar(250),
	@quantity decimal(7,2),
	@purchasePrice decimal(7,2)
AS 
	BEGIN
		if(@stockid = 0)
			BEGIN
				INSERT INTO dbo.Stock
				(
				    --StockId - this column value is auto-generated
				    UserDetailsId,
				    FruitId,
				    StockStatus,
				    Delivery,
				    Note,
				    Quantity,
					PurchasePrice
				)
				VALUES
				(
				    -- StockId - int
				    @userDetailsId, -- UserDetailsId - int
				    @fruitId, -- FruitId - int
				    @status, -- StockStatus - bit
				    @DeliveryDate, -- Delivery - datetime
				    @note, -- Note - varchar
				    @quantity, -- Quantity - decimal
					@purchasePrice
				)
			END
		ELSE
			BEGIN
				UPDATE dbo.Stock
				SET
				    --StockId - this column value is auto-generated
				    dbo.Stock.UserDetailsId = @userDetailsId, -- int
				    dbo.Stock.FruitId = @fruitId, -- int
				    dbo.Stock.StockStatus = @status, -- bit
				    dbo.Stock.Delivery = @DeliveryDate, -- datetime
				    dbo.Stock.Note = @note, -- varchar
				    dbo.Stock.Quantity = @quantity, -- decimal
					dbo.Stock.PurchasePrice = @purchasePrice -- decimal
				WHERE dbo.Stock.StockId = @stockid
			END
	END

GO
