USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserDelete]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblUserDelete]
	@userId int
AS 
	BEGIN
		DELETE FROM dbo.tblUser
		WHERE dbo.tblUser.UserId = @userId
	END

GO
