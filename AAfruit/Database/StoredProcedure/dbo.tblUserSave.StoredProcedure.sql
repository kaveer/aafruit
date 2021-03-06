USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserSave]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblUserSave]
	@email varchar(100),
	@password varchar(100)
AS 
	BEGIN
		INSERT INTO dbo.tblUser
		(
		    --UserId - this column value is auto-generated
		    Email,
		    UserPassword
		)
		VALUES
		(
		    -- UserId - int
		    @email, -- Email - varchar
		    @password -- UserPassword - varchar
		)

		SELECT *
		FROM dbo.tblUser tu
		WHERE tu.UserId = scope_identity()
	END

GO
