USE [AAfruits]
GO
/****** Object:  Table [dbo].[tblUserDetails]    Script Date: 12/29/2019 1:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserDetails](
	[UserDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[UserTypeId] [int] NULL,
	[Name] [varchar](100) NULL,
	[Surname] [varchar](100) NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Tel] [varchar](100) NULL,
	[Web] [varchar](100) NULL,
	[Note] [varchar](100) NULL,
	[Company] [varchar](100) NULL,
	[BRN] [varchar](100) NULL,
	[CountryId] [int] NULL,
	[Mobile] [varchar](100) NULL,
	[UserStatus] [bit] NULL,
	[Fax] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblUserDetails] ADD  DEFAULT ((1)) FOR [UserStatus]
GO
