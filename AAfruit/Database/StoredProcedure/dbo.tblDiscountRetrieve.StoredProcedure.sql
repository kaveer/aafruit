USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblDiscountRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblDiscountRetrieve]
AS 
	BEGIN
	SELECT *
	FROM dbo.Discount d
END

GO
