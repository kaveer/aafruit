USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblOrderSave]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblOrderSave]
	@UserDetailsId int,
	@FruitId int,
	@RequestedDate datetime,
	@Deadline datetime,
	@Quantity decimal(7, 2),
	@TotalPrice decimal(7, 2),
	@HasDiscount bit,
	@DiscountValue varchar(100),
	@DiscountTotalPrice decimal(7, 2),
	@OrderTypeId int,
	@OrderStatus bit
AS
	BEGIN
	INSERT INTO dbo.Orders
	(
	    --OrderId - this column value is auto-generated
	    UserDetailsId,
	    FruitId,
	    RequestedDate,
	    Deadline,
	    Quantity,
	    TotalPrice,
	    HasDiscount,
	    DiscountValue,
	    DiscountTotalPrice,
	    OrderTypeId,
	    OrderStatus
	)
	VALUES
	(
	    -- OrderId - int
	    @UserDetailsId, -- UserDetailsId - int
	    @FruitId, -- FruitId - int
	    @RequestedDate, -- RequestedDate - datetime
	    @Deadline, -- Deadline - datetime
	    @Quantity, -- Quantity - decimal
	    @TotalPrice, -- TotalPrice - decimal
	    @HasDiscount, -- HasDiscount - bit
	    @DiscountValue, -- DiscountValue - varchar
	    @DiscountTotalPrice, -- DiscountTotalPrice - decimal
	    @OrderTypeId, -- OrderTypeId - int
	    @OrderStatus -- OrderStatus - bit
	)
END
GO
