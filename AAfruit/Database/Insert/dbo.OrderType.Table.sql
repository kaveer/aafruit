USE [AAfruits]
GO
INSERT [dbo].[OrderType] ([OrderTypeId], [OrderStatus], [Description]) VALUES (1, N'Pending', N'')
INSERT [dbo].[OrderType] ([OrderTypeId], [OrderStatus], [Description]) VALUES (2, N'Processing', N'')
INSERT [dbo].[OrderType] ([OrderTypeId], [OrderStatus], [Description]) VALUES (3, N'AwaitPayment', N'')
INSERT [dbo].[OrderType] ([OrderTypeId], [OrderStatus], [Description]) VALUES (4, N'ReadyForDelivery', N'')
INSERT [dbo].[OrderType] ([OrderTypeId], [OrderStatus], [Description]) VALUES (5, N'Delivered', N'')
INSERT [dbo].[OrderType] ([OrderTypeId], [OrderStatus], [Description]) VALUES (6, N'Returned', NULL)
INSERT [dbo].[OrderType] ([OrderTypeId], [OrderStatus], [Description]) VALUES (7, N'Hold', NULL)
