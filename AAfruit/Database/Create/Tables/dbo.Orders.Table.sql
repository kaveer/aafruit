USE [AAfruits]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/29/2019 1:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserDetailsId] [int] NULL,
	[FruitId] [int] NULL,
	[RequestedDate] [datetime] NULL,
	[Deadline] [datetime] NULL,
	[Quantity] [decimal](7, 2) NULL,
	[TotalPrice] [decimal](7, 2) NULL,
	[HasDiscount] [bit] NULL,
	[DiscountValue] [varchar](100) NULL,
	[DiscountTotalPrice] [decimal](7, 2) NULL,
	[OrderTypeId] [int] NULL,
	[OrderStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
