USE [AAfruits]
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 

INSERT [dbo].[tblUser] ([UserId], [Email], [UserPassword]) VALUES (1, N'admin@admin', N'admin')
INSERT [dbo].[tblUser] ([UserId], [Email], [UserPassword]) VALUES (2, N'staff@staff', N'staff')
INSERT [dbo].[tblUser] ([UserId], [Email], [UserPassword]) VALUES (3, N'customer@customer', N'customer')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
