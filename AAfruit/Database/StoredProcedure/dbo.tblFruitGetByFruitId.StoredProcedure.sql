USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblFruitGetByFruitId]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblFruitGetByFruitId]
	@fruitId int
AS 
	BEGIN
		SELECT *
		FROM dbo.Fruit f
		WHERE f.FruitId = @fruitId AND f.FruitStatus = 1
END
GO
