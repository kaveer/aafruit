USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserDetailsDelete]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblUserDetailsDelete]
	@userDertailsId int
AS 
	BEGIN
		DELETE FROM dbo.tblUserDetails
		WHERE dbo.tblUserDetails.UserDetailsId = @userDertailsId
	END

GO
