USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblOrderDelete]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblOrderDelete]
	@userDertailsId int
AS 
	BEGIN
		DELETE FROM dbo.Orders
		WHERE dbo.Orders.UserDetailsId = @userDertailsId
	END

GO
