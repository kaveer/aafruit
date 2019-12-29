USE [AAfruits]
GO
SET IDENTITY_INSERT [dbo].[Fruit] ON 

INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (1, N'Apple', N'Mauritius apple', CAST(307.00 AS Decimal(7, 2)), 4, 1, CAST(5.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (2, N'Orange', N'Mauritius Orange', CAST(30.00 AS Decimal(7, 2)), 4, 1, CAST(10.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (3, N'Bananas', N'mauritius banana vacoas', CAST(80.00 AS Decimal(7, 2)), 2, 1, CAST(100.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (4, N'Pear', N'mauritius pear surat', CAST(100.00 AS Decimal(7, 2)), 4, 1, CAST(100.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (5, N'dragon fruit', N'dragon fruit', CAST(100.00 AS Decimal(7, 2)), 4, 1, CAST(100.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (7, N'grape', N'des', CAST(100.00 AS Decimal(7, 2)), 1, 1, CAST(10.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (8, N'tamarin', N'des', CAST(100.00 AS Decimal(7, 2)), 1, 1, CAST(5.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (9, N'pineapple', N'SURAT mauritius', CAST(200.00 AS Decimal(7, 2)), 4, 1, CAST(48.00 AS Decimal(7, 2)))
INSERT [dbo].[Fruit] ([FruitId], [FruitName], [Description], [Available], [MeasurementTypeId], [FruitStatus], [UnitPrice]) VALUES (12, N'lemon', N'SURAT', CAST(10000.00 AS Decimal(7, 2)), 4, 1, CAST(50.00 AS Decimal(7, 2)))
SET IDENTITY_INSERT [dbo].[Fruit] OFF
