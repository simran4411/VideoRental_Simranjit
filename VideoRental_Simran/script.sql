USE [master]
GO
/****** Object:  Database [SimranDatabase]    Script Date: 24/02/2020 3:56:19 pm ******/
CREATE DATABASE [SimranDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimranDatabase_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SimranDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SimranDatabase_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SimranDatabase.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SimranDatabase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimranDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimranDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimranDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimranDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimranDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimranDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimranDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimranDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimranDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimranDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimranDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimranDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimranDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimranDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimranDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimranDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SimranDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimranDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimranDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimranDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimranDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimranDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SimranDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimranDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SimranDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [SimranDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimranDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimranDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimranDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SimranDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SimranDatabase', N'ON'
GO
ALTER DATABASE [SimranDatabase] SET QUERY_STORE = OFF
GO
USE [SimranDatabase]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 24/02/2020 3:56:20 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
	[Phone] [varchar](50) NULL,
	[City] [varchar](50) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 24/02/2020 3:56:20 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Ratting] [varchar](50) NULL,
	[Year] [int] NULL,
	[Copies] [int] NULL,
	[Genre] [varchar](50) NULL,
	[Cost] [int] NULL,
 CONSTRAINT [PK_Movie1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rental]    Script Date: 24/02/2020 3:56:20 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rental](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NULL,
	[ClientID] [int] NULL,
	[IssueDate] [varchar](50) NULL,
	[ReturnDate] [varchar](50) NULL,
 CONSTRAINT [PK_Rental1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([id], [Name], [Age], [Phone], [City]) VALUES (1, N'test', 26, N'97654445675', N'auckland')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Movie] ON 

INSERT [dbo].[Movie] ([id], [Name], [Ratting], [Year], [Copies], [Genre], [Cost]) VALUES (1, N'qw', N'2.3', 2019, 2, N'qw', 5)
SET IDENTITY_INSERT [dbo].[Movie] OFF
SET IDENTITY_INSERT [dbo].[Rental] ON 

INSERT [dbo].[Rental] ([id], [MovieID], [ClientID], [IssueDate], [ReturnDate]) VALUES (1, 1, 1, N'12/02/2020', N'12/02/2020')
SET IDENTITY_INSERT [dbo].[Rental] OFF
USE [master]
GO
ALTER DATABASE [SimranDatabase] SET  READ_WRITE 
GO
