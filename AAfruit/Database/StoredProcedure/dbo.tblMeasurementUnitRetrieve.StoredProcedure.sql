USE [AAfruits]
GO
/****** Object:  StoredProcedure [dbo].[tblMeasurementUnitRetrieve]    Script Date: 12/29/2019 1:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblMeasurementUnitRetrieve]
AS
	BEGIN
		SELECT *
		FROM dbo.MeasurementType mt
	END

GO
