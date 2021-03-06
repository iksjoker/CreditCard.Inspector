USE [master]
GO
/****** Object:  Database [CreditCardInspector]    Script Date: 26.09.2018 5:38:36 ******/
CREATE DATABASE [CreditCardInspector]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CreditCardInspector', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CreditCardInspector.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CreditCardInspector_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CreditCardInspector_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CreditCardInspector] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreditCardInspector].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CreditCardInspector] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CreditCardInspector] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CreditCardInspector] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CreditCardInspector] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CreditCardInspector] SET ARITHABORT OFF 
GO
ALTER DATABASE [CreditCardInspector] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CreditCardInspector] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CreditCardInspector] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CreditCardInspector] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CreditCardInspector] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CreditCardInspector] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CreditCardInspector] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CreditCardInspector] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CreditCardInspector] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CreditCardInspector] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CreditCardInspector] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CreditCardInspector] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CreditCardInspector] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CreditCardInspector] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CreditCardInspector] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CreditCardInspector] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CreditCardInspector] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CreditCardInspector] SET RECOVERY FULL 
GO
ALTER DATABASE [CreditCardInspector] SET  MULTI_USER 
GO
ALTER DATABASE [CreditCardInspector] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CreditCardInspector] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CreditCardInspector] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CreditCardInspector] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CreditCardInspector] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CreditCardInspector]
GO
/****** Object:  Table [dbo].[CARD_INFO]    Script Date: 26.09.2018 5:38:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CARD_INFO](
	[UID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_CARD_INFO_UID]  DEFAULT (newid()),
	[CARD_TYPE] [varchar](50) NOT NULL,
	[CARD_NUMBER] [bigint] NOT NULL,
	[VALID_THRU] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CARD_INFO] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [CARD_NUMBER_INDEX]    Script Date: 26.09.2018 5:38:36 ******/
CREATE NONCLUSTERED INDEX [CARD_NUMBER_INDEX] ON [dbo].[CARD_INFO]
(
	[CARD_NUMBER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [CARD_TYPE_INDEX]    Script Date: 26.09.2018 5:38:36 ******/
CREATE NONCLUSTERED INDEX [CARD_TYPE_INDEX] ON [dbo].[CARD_INFO]
(
	[CARD_TYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [VALID_THRU_INDEX]    Script Date: 26.09.2018 5:38:36 ******/
CREATE NONCLUSTERED INDEX [VALID_THRU_INDEX] ON [dbo].[CARD_INFO]
(
	[VALID_THRU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[checkIfCreditCardExists]    Script Date: 26.09.2018 5:38:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[checkIfCreditCardExists]
@CardNumber bigint
AS
BEGIN
    
    SET NOCOUNT ON;

    SELECT TOP 1 * FROM CARD_INFO WHERE CARD_NUMBER=@CardNumber
END

RETURN
GO
USE [master]
GO
ALTER DATABASE [CreditCardInspector] SET  READ_WRITE 
GO

INSERT INTO [CARD_INFO] (CARD_TYPE,CARD_NUMBER,VALID_THRU) VALUES ('VISA', 4563856219217000, '102018')
INSERT INTO [CARD_INFO] (CARD_TYPE,CARD_NUMBER,VALID_THRU) VALUES ('MasterCard', 5211874562849900, '012019')
INSERT INTO [CARD_INFO] (CARD_TYPE,CARD_NUMBER,VALID_THRU) VALUES ('Amex', 321895532647961, '102019')
INSERT INTO [CARD_INFO] (CARD_TYPE,CARD_NUMBER,VALID_THRU) VALUES ('JCB', 3128456123087742, '102020')