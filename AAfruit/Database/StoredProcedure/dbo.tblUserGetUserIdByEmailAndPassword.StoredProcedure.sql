USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserGetUserIdByEmailAndPassword]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblUserGetUserIdByEmailAndPassword]
	@email varchar(100),
	@password varchar(100),
	@usertype int
AS
	BEGIN
		DECLARE @adminStaff int = 5

		IF(@usertype = @adminStaff)
			BEGIN
				SELECT 
					tu.UserId,
					tud.UserDetailsId
				FROM dbo.tblUser tu
				INNER JOIN dbo.tblUserDetails tud ON tu.UserId = tud.UserId 
					AND tu.Email = @email 
					AND tu.UserPassword = @password
					AND	tud.UserStatus = 1
			END 
		ELSE
			BEGIN
				SELECT 
					tu.UserId,
					tud.UserDetailsId
				FROM dbo.tblUser tu
				INNER JOIN dbo.tblUserDetails tud ON tu.UserId = tud.UserId 
					AND tu.Email = @email 
					AND tu.UserPassword = @password
					AND	tud.UserStatus = 1
				INNER JOIN dbo.tblUserType tut ON tud.UserTypeId = tut.UserTypeId
					AND tut.UserTypeId = @usertype
			END
	END
GO
