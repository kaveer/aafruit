USE [AAfruits]
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([DiscountId], [DiscountValue], [PriceRange], [PriceRangeMax]) VALUES (1, 5, CAST(1000.00 AS Decimal(7, 2)), CAST(1999.00 AS Decimal(7, 2)))
INSERT [dbo].[Discount] ([DiscountId], [DiscountValue], [PriceRange], [PriceRangeMax]) VALUES (2, 10, CAST(2000.00 AS Decimal(7, 2)), CAST(2999.00 AS Decimal(7, 2)))
INSERT [dbo].[Discount] ([DiscountId], [DiscountValue], [PriceRange], [PriceRangeMax]) VALUES (3, 15, CAST(4000.00 AS Decimal(7, 2)), CAST(4999.00 AS Decimal(7, 2)))
SET IDENTITY_INSERT [dbo].[Discount] OFF
