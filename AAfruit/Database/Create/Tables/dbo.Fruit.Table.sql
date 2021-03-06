USE [AAfruits]
GO
/****** Object:  Table [dbo].[Fruit]    Script Date: 12/29/2019 1:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fruit](
	[FruitId] [int] IDENTITY(1,1) NOT NULL,
	[FruitName] [varchar](100) NULL,
	[Description] [varchar](200) NULL,
	[Available] [decimal](7, 2) NULL,
	[MeasurementTypeId] [int] NULL,
	[FruitStatus] [bit] NULL,
	[UnitPrice] [decimal](7, 2) NULL,
 CONSTRAINT [PK__Fruit__F33DDB0D3469F69A] PRIMARY KEY CLUSTERED 
(
	[FruitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
