USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblCountryRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblCountryRetrieve]
AS
	BEGIN
		SELECT 
			tc.CountryId, 
			tc.Country
		FROM dbo.tblCountry tc
	END

GO
