USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblUserDetailsUpdate]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[tblUserDetailsUpdate]
	@userDetailsId int,
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

	@company varchar(100),
	@brn varchar(100),
	@note varchar(100),

	@web varchar(100),
	@fax varchar(100)
AS 
	BEGIN
		UPDATE dbo.tblUserDetails
		SET
		    --UserDetailsId - this column value is auto-generated
		    dbo.tblUserDetails.UserId = @userId, -- int
		    dbo.tblUserDetails.UserTypeId = @userTypeId, -- int
		    dbo.tblUserDetails.[Name] = @name, -- varchar
		    dbo.tblUserDetails.Surname = @surnmae, -- varchar
		    dbo.tblUserDetails.[Address] = @address, -- varchar
		    dbo.tblUserDetails.Email = @email, -- varchar
		    dbo.tblUserDetails.Tel = @fix, -- varchar
		    dbo.tblUserDetails.Web = @web, -- varchar
		    dbo.tblUserDetails.Note = @note, -- varchar
		    dbo.tblUserDetails.Company = @company, -- varchar
		    dbo.tblUserDetails.BRN = @brn, -- varchar
		    dbo.tblUserDetails.CountryId = @countryId, -- int
		    dbo.tblUserDetails.Mobile = @mobile, -- varchar
		    dbo.tblUserDetails.UserStatus = @status, -- bit
		    dbo.tblUserDetails.Fax = @fax -- varchar
		WHERE dbo.tblUserDetails.UserDetailsId = @userDetailsId
	END

GO
