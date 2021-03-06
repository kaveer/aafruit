USE [AAfruits]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 12/29/2019 1:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[UserDetailsId] [int] NULL,
	[FruitId] [int] NULL,
	[StockStatus] [bit] NULL,
	[Delivery] [datetime] NULL,
	[Note] [varchar](250) NULL,
	[Quantity] [decimal](7, 2) NULL,
	[PurchasePrice] [decimal](7, 2) NULL,
 CONSTRAINT [PK__Stock__2C83A9C2926110AF] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
