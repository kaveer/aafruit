USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserDetailsRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblUserDetailsRetrieve]
	@userDetailsId int
AS 
	BEGIN
		SELECT *
		FROM dbo.tblUser tu
		INNER JOIN dbo.tblUserDetails tud ON tud.UserId = tu.UserId
		WHERE tud.UserDetailsId = @userDetailsId
	END

GO
