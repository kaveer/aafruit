USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserDetailsSave]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblUserDetailsSave]
	@userId int,
	@userTypeId int,
	@status bit,

	@name varchar(100),
	@surnmae varchar(100),
	@address varchar(100),
	@countryId int,
	@email varchar(100),
	@fix varchar(100),
	@mobile varchar(100),
	@web varchar(100) = 'EMPTY',
	@fax varchar(100) = 'EMPTY',

	@company varchar(100),
	@brn varchar(100),
	@note varchar(100)
AS 
	BEGIN
		INSERT INTO dbo.tblUserDetails
		(
		    --UserDetailsId - this column value is auto-generated
		    UserId,
		    UserTypeId,
		    [Name],
		    Surname,
		    [Address],
		    Email,
		    Tel,
		    Web,
		    Note,
		    Company,
		    BRN,
		    CountryId,
		    Mobile,
		    UserStatus,
		    Fax
		)
		VALUES
		(
		    -- UserDetailsId - int
		    @userId, -- UserId - int
		    @userTypeId, -- UserTypeId - int
		    @name, -- Name - varchar
		    @surnmae, -- Surname - varchar
		    @address, -- Address - varchar
		    @email, -- Email - varchar
		    @fix, -- Tel - varchar
		    @web, -- Web - varchar
		    @note, -- Note - varchar
		    @company, -- Company - varchar
		    @brn, -- BRN - varchar
		    @countryId, -- CountryId - int
		    @mobile, -- Mobile - varchar
		    @status, -- UserStatus - bit
		    @fax -- Fax - varchar
		)

		SELECT * 
		FROM dbo.tblUserDetails tud
		WHERE tud.UserDetailsId = scope_identity()
	END

GO
