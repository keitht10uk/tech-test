USE [master]
GO

CREATE DATABASE [KeithTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KeithTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\KeithTest.mdf' , SIZE = 512000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KeithTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\KeithTest_log.ldf' , SIZE = 102400KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO


Use KeithTest
go

/****** Object:  Table [dbo].[Customer]    Script Date: 06/11/2018 17:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Name] [nvarchar](255) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Country] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 06/11/2018 17:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Customer] ([Name], [CustomerId], [DateOfBirth], [Country]) VALUES (N'Keith', 1, CAST(N'1966-10-20 00:00:00.000' AS DateTime), N'UK')
INSERT [dbo].[Customer] ([Name], [CustomerId], [DateOfBirth], [Country]) VALUES (N'Nicky', 2, CAST(N'1963-10-14 00:00:00.000' AS DateTime), N'FRANCE')
INSERT [dbo].[Order] ([OrderId], [CustomerId], [Amount], [VAT]) VALUES (0, 1, CAST(20.00 AS Decimal(18, 2)), CAST(0.20 AS Decimal(18, 2)))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [Amount], [VAT]) VALUES (1, 1, CAST(100.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [Amount], [VAT]) VALUES (2, 1, CAST(50.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Order] ([OrderId], [CustomerId], [Amount], [VAT]) VALUES (3, 2, CAST(300.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
