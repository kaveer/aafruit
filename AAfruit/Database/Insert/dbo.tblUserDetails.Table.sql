USE [AAfruits]
GO
SET IDENTITY_INSERT [dbo].[tblUserDetails] ON 

INSERT [dbo].[tblUserDetails] ([UserDetailsId], [UserId], [UserTypeId], [Name], [Surname], [Address], [Email], [Tel], [Web], [Note], [Company], [BRN], [CountryId], [Mobile], [UserStatus], [Fax]) VALUES (1, 1, 1, N'name', N'surname', N'address', N'company@company', N'5236851333', N'web', N'notebgh', N'companygfi', N'brnhio', 2, N'532684111', 1, N'52316854')
INSERT [dbo].[tblUserDetails] ([UserDetailsId], [UserId], [UserTypeId], [Name], [Surname], [Address], [Email], [Tel], [Web], [Note], [Company], [BRN], [CountryId], [Mobile], [UserStatus], [Fax]) VALUES (2, 2, 2, N'test name', N'test surname', N'test address', N'test email', N'52368513', N'web', N'note', N'company', N'brn', 1, N'5326841', 1, N'52316854')
INSERT [dbo].[tblUserDetails] ([UserDetailsId], [UserId], [UserTypeId], [Name], [Surname], [Address], [Email], [Tel], [Web], [Note], [Company], [BRN], [CountryId], [Mobile], [UserStatus], [Fax]) VALUES (3, 3, 3, N'names', N'surnames', N'addresss', N'sdf@customers', N'5235964s', N'', N'notes', N'companys', N'brns', 3, N'5689632s', 1, N'')
SET IDENTITY_INSERT [dbo].[tblUserDetails] OFF
