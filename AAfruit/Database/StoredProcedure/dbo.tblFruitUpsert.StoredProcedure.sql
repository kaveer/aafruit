USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblFruitUpsert]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[tblFruitUpsert]
	@fruitId int,
	@name varchar(100),
	@des varchar(100),
	@measurement int,
	@quantity decimal(7,2),
	@unitPrice decimal(7,2),
	@stat bit
AS
	BEGIN
		IF(@fruitId = 0)
			BEGIN
				INSERT INTO dbo.Fruit
				(
				    --FruitId - this column value is auto-generated
				    FruitName,
				    [Description],
				    Available,
				    MeasurementTypeId,
				    FruitStatus,
				    UnitPrice
				)
				VALUES
				(
				    -- FruitId - int
				    @name, -- FruitName - varchar
				    @des, -- Description - varchar
				    @quantity, -- Available - decimal
				    @measurement, -- MeasurementTypeId - int
				    @stat, -- FruitStatus - bit
				    @unitPrice -- UnitPrice - decimal
				)

				SELECT *
				FROM dbo.Fruit f
				WHERE f.FruitId = scope_identity()
			END
		ELSE
			BEGIN
				UPDATE dbo.Fruit
				SET
				    --FruitId - this column value is auto-generated
				    dbo.Fruit.FruitName = @name, -- varchar
				    dbo.Fruit.[Description] = @des, -- varchar
				    dbo.Fruit.Available = @quantity, -- decimal
				    dbo.Fruit.MeasurementTypeId = @measurement, -- int
				    dbo.Fruit.FruitStatus = @stat, -- bit
				    dbo.Fruit.UnitPrice = @unitPrice -- decimal
				WHERE dbo.Fruit.FruitId = @fruitId

				SELECT *
				FROM dbo.Fruit f
				WHERE f.FruitId = @fruitId
			END
	END
GO
