USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblFruitRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblFruitRetrieve]
AS 
	BEGIN
	SELECT
		d.FruitId,
		d.FruitName
	FROM dbo.Fruit d
	where d.FruitStatus = 1
END

GO
