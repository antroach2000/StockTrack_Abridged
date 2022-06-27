USE [master]
GO
/****** Object:  Database [StockLiveV1]    Script Date: 27/06/2022 16:24:21 ******/
CREATE DATABASE [StockLiveV1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StockLiveV1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\StockLiveV1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StockLiveV1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\StockLiveV1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StockLiveV1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StockLiveV1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StockLiveV1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StockLiveV1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StockLiveV1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StockLiveV1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StockLiveV1] SET ARITHABORT OFF 
GO
ALTER DATABASE [StockLiveV1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StockLiveV1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StockLiveV1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StockLiveV1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StockLiveV1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StockLiveV1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StockLiveV1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StockLiveV1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StockLiveV1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StockLiveV1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StockLiveV1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StockLiveV1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StockLiveV1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StockLiveV1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StockLiveV1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StockLiveV1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StockLiveV1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StockLiveV1] SET RECOVERY FULL 
GO
ALTER DATABASE [StockLiveV1] SET  MULTI_USER 
GO
ALTER DATABASE [StockLiveV1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StockLiveV1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StockLiveV1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StockLiveV1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StockLiveV1] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StockLiveV1', N'ON'
GO
ALTER DATABASE [StockLiveV1] SET QUERY_STORE = OFF
GO
USE [StockLiveV1]
GO
/****** Object:  Table [dbo].[IndustryGroup]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndustryGroup](
	[IndustryGroupId] [int] IDENTITY(1,1) NOT NULL,
	[IndustryDescription] [varchar](100) NOT NULL,
 CONSTRAINT [PK_IndustryGroup] PRIMARY KEY CLUSTERED 
(
	[IndustryGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portfolio]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portfolio](
	[PortfolioId] [uniqueidentifier] NOT NULL,
	[StockExchangeId] [int] NOT NULL,
	[UserId] [varchar](64) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IndustryGroupId] [int] NULL,
 CONSTRAINT [PK_Portfolio_1] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockExchange]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockExchange](
	[StockExchangeId] [int] NOT NULL,
	[ExchangeName] [varchar](64) NOT NULL,
	[ExchangeType] [int] NULL,
	[Country] [varchar](64) NULL,
	[CountryCurrency] [varchar](25) NULL,
	[CountryCurrencySymbol] [varchar](10) NULL,
	[Description] [varchar](64) NULL,
	[CountryFlagPath] [varchar](128) NOT NULL,
	[CompanyLogoPath] [varchar](128) NOT NULL,
	[ExchangeSymbol] [varchar](25) NULL,
	[ExchangeLogo] [varchar](128) NULL,
	[ExchangeLongDescription] [varchar](max) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_StockExchange] PRIMARY KEY CLUSTERED 
(
	[StockExchangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[IndustryGroup] ON 
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (1, N'Automobiles & Components')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (2, N'Banks')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (3, N'Capital Goods')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (4, N'Commercial & Professional Services')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (5, N'Consumer Discretionary')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (6, N'Consumer Durables & Apparel')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (7, N'Consumer Services')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (8, N'Consumer Staples')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (9, N'Crypto')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (10, N'Diversified Financials')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (11, N'Energy')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (12, N'Financials')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (13, N'Food & Staples Retailing')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (14, N'Food, Beverage & Tobacco')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (15, N'Health Care')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (16, N'Health Care Equipment & Services')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (17, N'Household & Personal Products')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (18, N'Industrials')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (19, N'Information Technology')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (20, N'Insurance')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (21, N'Materials')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (22, N'Media & Entertainment')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (23, N'Pharmaceuticals, Biotechnology & Life Sciences')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (24, N'Real Estate')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (25, N'Retailing')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (26, N'Semiconductors & Semiconductor Equipment')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (27, N'Software & Services')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (28, N'Technology Hardware & Equipment')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (29, N'Telecommunication Services')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (30, N'Transportation')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (31, N'Unknown')
GO
INSERT [dbo].[IndustryGroup] ([IndustryGroupId], [IndustryDescription]) VALUES (32, N'Utilities')
GO
SET IDENTITY_INSERT [dbo].[IndustryGroup] OFF
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (10000, N'ASX', 1, N'AUSTRALIA', N'AUD', N'A$', N'All Ordinaries', N'/flags/australia', N'/CompanyLogo/australia', N'^AORD', N'/StockExchangeLogo/asx-143x58.png', N'Australian Securities Exchange', 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (10001, N'ASX 200', 1, N'AUSTRALIA', N'AUD', N'A$', N'All Ordinaries 200', N'/flags/australia', N'/CompanyLogo/australia', NULL, N'/StockExchangeLogo/australia', N'All Ordinaries 200', 0)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (10002, N'S&P 500', 1, N'USA', N'USD', N'$', N'Dow Jones Industrial', N'/flags/unitedstates', N'/CompanyLogo/unitedstates', N'^DJI', N'/StockExchangeLogo/dowjones-125x125.png', N'Standard and Poor', 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (10003, N'FTSE 100', 1, N'UK', N'GBP', N'£', N'Financial Times', N'/flags/unitedkingdom', N'/CompanyLogo/unitedkingdom', N'^FTSE', N'/StockExchangeLogo/FTSE-250x58.png', N'Financial Times', 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (10004, N'NASDAQ', 1, N'USA', N'USD', N'$', N'Nasdaq', N'/flags/unitedstates', N'/CompanyLogo/unitedstates', N'^IXIC', N'/StockExchangeLogo/Nasdaq-logo-189x100.png', N'National Association of Securities Dealers', 0)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (10005, N'NIKKEI 225', 1, N'JAPAN', N'JPY', N'¥', N'Nikkei 225', N'/flags/japan', N'/CompanyLogo/japan', N'^N225', N'/StockExchangeLogo/japan-133x100.png', N'Japanese stock market index', 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (10006, N'Crypto200', 1, N'USA', N'USD', N'$', N'Crypto currency', N'/flags/unitedstates', N'/CompanyLogo/cryptocurrency', N'^CMC200', N'/StockExchangeLogo/Nasdaq-logo-189x100.png', N'', 0)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (20000, N'Crypto Currency', 2, N'USA', N'USD', N'$', N'blockchain-based', N'/flags/cryptocurrency', N'/CompanyLogo/cryptocurrency', N'^CMC200', N'/StockExchangeLogo/Nasdaq-logo-189x100.png', NULL, 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (20001, N'Gold', 10, N'UK', N'USD', N'$', N'Gold futures', N'/flags/gold', N'/CompanyLogo/gold', N'GC=F', N'', N'', 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (20002, N'Exchange Rate', 3, N'EUR', N'EUR', N'€', N'Australia Euro Exchange', N'/flags/europe', N'/CompanyLogo/exchangerate/audeur', N'AUDEUR=X', N'', N'', 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (20003, N'Exchange Rate', 3, N'GBP', N'GBP', N'£', N'Australia Pound Exchange', N'/flags/unitedkingdom', N'/CompanyLogo/exchangerate/audgbp', N'AUDGBP=X', NULL, NULL, 1)
GO
INSERT [dbo].[StockExchange] ([StockExchangeId], [ExchangeName], [ExchangeType], [Country], [CountryCurrency], [CountryCurrencySymbol], [Description], [CountryFlagPath], [CompanyLogoPath], [ExchangeSymbol], [ExchangeLogo], [ExchangeLongDescription], [Active]) VALUES (20007, N'Exchange Rate', 3, N'USD', N'USD', N'$', N'Australia US Dollar Exchange', N'/flags/unitedstates', N'/CompanyLogo/exchangerate/audus', N'AUDUSD=X', NULL, NULL, 1)
GO
/****** Object:  StoredProcedure [dbo].[GetIndustryDescription]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetIndustryDescription]
@IndustryGroupId int
AS
BEGIN
	SELECT IndustryGroupId
		  ,IndustryDescription
	FROM IndustryGroup
	WHERE IndustryGroupId = @IndustryGroupId
END
GO
/****** Object:  StoredProcedure [dbo].[GetIndustryGroup]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetIndustryGroup]
AS
BEGIN
	SELECT IndustryGroupId
		  ,IndustryDescription
	FROM IndustryGroup
END
GO
/****** Object:  StoredProcedure [dbo].[GetPortfolio]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetPortfolio]
@PortfolioId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT PortfolioId, po.StockExchangeId,IndustryGroupId, UserId, se.CountryFlagPath, se.CountryCurrencySymbol, se.Country, Name
	FROM  Portfolio po
	INNER JOIN StockExchange se on se.StockExchangeId = po.StockExchangeId
	WHERE PortfolioId = @PortfolioId
END
GO
/****** Object:  StoredProcedure [dbo].[InsertPortfolio]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPortfolio]
@PortfolioId UNIQUEIDENTIFIER,
@UserId varchar(64),
@Name varchar(50),
@StockExchangeId int,
@IndustryGroupId int
AS
BEGIN
	INSERT INTO Portfolio(PortfolioId, StockExchangeId, UserId, IndustryGroupId, Name)
	VALUES(@PortfolioId, @StockExchangeId, @UserId, @IndustryGroupId, @Name)
END
GO
/****** Object:  StoredProcedure [dbo].[PortfolioExists]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PortfolioExists]
@PortfolioId UNIQUEIDENTIFIER

AS
BEGIN
	SELECT COUNT(*)
	FROM  Portfolio 
	WHERE PortfolioId = @PortfolioId
END
GO
/****** Object:  StoredProcedure [dbo].[RemovePortfolio]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[RemovePortfolio]
@PortfolioId UNIQUEIDENTIFIER
AS
BEGIN
	DELETE	Portfolio
	WHERE	PortfolioId = @PortfolioId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePortfolio]    Script Date: 27/06/2022 16:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdatePortfolio]
@PortfolioId UNIQUEIDENTIFIER,
@Name varchar(50),
@StockExchangeId int,
@IndustryGroupId int
AS
BEGIN
	UPDATE 	Portfolio
	SET		Name = @Name,
			IndustryGroupId = @IndustryGroupId,
			StockExchangeId = @StockExchangeId

	WHERE	PortfolioId = @PortfolioId	

END
GO
USE [master]
GO
ALTER DATABASE [StockLiveV1] SET  READ_WRITE 
GO
