USE [BMS]
GO
/****** Object:  Table [dbo].[Tbl_Account]    Script Date: 6/9/2024 3:02:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [varchar](50) NOT NULL,
	[CustomerNo] [varchar](50) NOT NULL,
	[AccountType] [varchar](50) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Customer]    Script Date: 6/9/2024 3:02:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Address] [text] NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[CustomerNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Account] ON 

INSERT [dbo].[Tbl_Account] ([AccountId], [AccountNo], [CustomerNo], [AccountType], [Balance], [Password]) VALUES (2, N'CHE5261', N'STR7985', N'Checking', CAST(80000.00 AS Decimal(18, 2)), N'string')
INSERT [dbo].[Tbl_Account] ([AccountId], [AccountNo], [CustomerNo], [AccountType], [Balance], [Password]) VALUES (3, N'SAV3940', N'REC8936', N'Saving', CAST(3.00 AS Decimal(18, 2)), N's7r!nGoow')
INSERT [dbo].[Tbl_Account] ([AccountId], [AccountNo], [CustomerNo], [AccountType], [Balance], [Password]) VALUES (4, N'ACC7891', N'STR7985', N'Saving', CAST(70000.00 AS Decimal(18, 2)), N'7e$7!Ng0k')
SET IDENTITY_INSERT [dbo].[Tbl_Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Customer] ON 

INSERT [dbo].[Tbl_Customer] ([CustomerId], [Name], [Email], [Address], [PhoneNumber], [CustomerNo]) VALUES (1, N'string updated', N'string@gmail.com', N'string', N'string', N'STR7985')
INSERT [dbo].[Tbl_Customer] ([CustomerId], [Name], [Email], [Address], [PhoneNumber], [CustomerNo]) VALUES (2, N'Record test', N'string', N'string', N'string', N'REC8936')
SET IDENTITY_INSERT [dbo].[Tbl_Customer] OFF
GO
ALTER TABLE [dbo].[Tbl_Account]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Account_Tbl_Customer] FOREIGN KEY([CustomerNo])
REFERENCES [dbo].[Tbl_Customer] ([CustomerNo])
GO
ALTER TABLE [dbo].[Tbl_Account] CHECK CONSTRAINT [FK_Tbl_Account_Tbl_Customer]
GO
