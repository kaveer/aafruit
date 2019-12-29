USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserDetailsRetrieveByUserType]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblUserDetailsRetrieveByUserType]
	@userType int
AS 
	BEGIN
		SELECT *
		FROM dbo.tblUserDetails tud
		WHERE tud.UserTypeId = @userType
	END

GO
