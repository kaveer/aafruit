USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserupdate]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tblUserupdate]
	@userId int,
	@email varchar(100),
	@password varchar(100)
AS 
	BEGIN
		UPDATE dbo.tblUser
		SET
		    --UserId - this column value is auto-generated
		    dbo.tblUser.Email = @email, -- varchar
		    dbo.tblUser.UserPassword = @password -- varchar
		WHERE dbo.tblUser.UserId = @userId
	END

GO
