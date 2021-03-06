USE [AAfruits]
GO
/****** Object:  Table [dbo].[MeasurementType]    Script Date: 12/29/2019 1:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementType](
	[MeasurementTypeId] [int] NOT NULL,
	[Measurement] [varchar](100) NULL,
	[Note] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MeasurementTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
