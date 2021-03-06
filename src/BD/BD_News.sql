USE [master]
GO
/****** Object:  Database [News]    Script Date: 04.12.2018 15:53:17 ******/
CREATE DATABASE [News]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'News', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\News.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'News_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\News_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [News] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [News].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [News] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [News] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [News] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [News] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [News] SET ARITHABORT OFF 
GO
ALTER DATABASE [News] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [News] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [News] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [News] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [News] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [News] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [News] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [News] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [News] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [News] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [News] SET  DISABLE_BROKER 
GO
ALTER DATABASE [News] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [News] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [News] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [News] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [News] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [News] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [News] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [News] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [News] SET  MULTI_USER 
GO
ALTER DATABASE [News] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [News] SET DB_CHAINING OFF 
GO
ALTER DATABASE [News] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [News] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [News]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 04.12.2018 15:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IdCategories] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[IdCategories] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CategoryOfNews]    Script Date: 04.12.2018 15:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryOfNews](
	[IdRecord] [int] IDENTITY(1,1) NOT NULL,
	[IdNews] [int] NOT NULL,
	[IdCategory] [int] NOT NULL,
 CONSTRAINT [PK_CategoryOfNews] PRIMARY KEY CLUSTERED 
(
	[IdRecord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 04.12.2018 15:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id_news] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[Date] [date] NOT NULL,
	[TextContent] [nvarchar](max) NOT NULL,
	[RefIdRest] [int] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id_news] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phones]    Script Date: 04.12.2018 15:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phones](
	[Id_phone] [int] IDENTITY(1,1) NOT NULL,
	[PublicPhone] [nvarchar](15) NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[Id_phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Restorans]    Script Date: 04.12.2018 15:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restorans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude_wgs84] [float] NULL,
	[Longitude_wgs84] [float] NULL,
	[Name] [nvarchar](50) NULL,
	[Adress] [nvarchar](70) NULL,
	[AdmArea] [nchar](50) NULL,
	[District] [nchar](30) NULL,
	[SeatsCount] [int] NULL,
	[IdPhone] [int] NOT NULL,
 CONSTRAINT [PK_Restorans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([IdCategories], [CatName]) VALUES (0, N'Roflan')
INSERT [dbo].[Category] ([IdCategories], [CatName]) VALUES (2, N'Roflan2')
INSERT [dbo].[Category] ([IdCategories], [CatName]) VALUES (3, N'Roflan3')
INSERT [dbo].[Category] ([IdCategories], [CatName]) VALUES (4, N'Актуально сейчас')
INSERT [dbo].[Category] ([IdCategories], [CatName]) VALUES (5, N'Актуально всегда')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[CategoryOfNews] ON 

INSERT [dbo].[CategoryOfNews] ([IdRecord], [IdNews], [IdCategory]) VALUES (1, 1, 0)
INSERT [dbo].[CategoryOfNews] ([IdRecord], [IdNews], [IdCategory]) VALUES (2, 2, 0)
INSERT [dbo].[CategoryOfNews] ([IdRecord], [IdNews], [IdCategory]) VALUES (3, 3, 0)
INSERT [dbo].[CategoryOfNews] ([IdRecord], [IdNews], [IdCategory]) VALUES (4, 4, 0)
INSERT [dbo].[CategoryOfNews] ([IdRecord], [IdNews], [IdCategory]) VALUES (6, 1, 2)
INSERT [dbo].[CategoryOfNews] ([IdRecord], [IdNews], [IdCategory]) VALUES (7, 6, 4)
INSERT [dbo].[CategoryOfNews] ([IdRecord], [IdNews], [IdCategory]) VALUES (8, 6, 5)
SET IDENTITY_INSERT [dbo].[CategoryOfNews] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id_news], [Title], [Date], [TextContent], [RefIdRest]) VALUES (1, N'Your dig is very big', CAST(0xDF3E0B00 AS Date), N'Fat mam', NULL)
INSERT [dbo].[News] ([Id_news], [Title], [Date], [TextContent], [RefIdRest]) VALUES (2, N'Your dig is very Bbig', CAST(0xDF3E0B00 AS Date), N'Fat mam', NULL)
INSERT [dbo].[News] ([Id_news], [Title], [Date], [TextContent], [RefIdRest]) VALUES (3, N'Your dig is very bigG', CAST(0xDF3E0B00 AS Date), N'Fat mam', NULL)
INSERT [dbo].[News] ([Id_news], [Title], [Date], [TextContent], [RefIdRest]) VALUES (4, N'Your dig is very Bbig', CAST(0xFE3E0B00 AS Date), N'Fat mam', NULL)
INSERT [dbo].[News] ([Id_news], [Title], [Date], [TextContent], [RefIdRest]) VALUES (5, N'Your dig is very bigG', CAST(0xD53E0B00 AS Date), N'Fat mam', NULL)
INSERT [dbo].[News] ([Id_news], [Title], [Date], [TextContent], [RefIdRest]) VALUES (6, N'Новая новость', CAST(0x063F0B00 AS Date), N'Очень интересное описание новости', NULL)
INSERT [dbo].[News] ([Id_news], [Title], [Date], [TextContent], [RefIdRest]) VALUES (10, N'Новая Новость', CAST(0x063F0B00 AS Date), N'Очень интересное описание новости', NULL)
SET IDENTITY_INSERT [dbo].[News] OFF
ALTER TABLE [dbo].[CategoryOfNews]  WITH CHECK ADD  CONSTRAINT [FK_CategoryOfNews_Category] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Category] ([IdCategories])
GO
ALTER TABLE [dbo].[CategoryOfNews] CHECK CONSTRAINT [FK_CategoryOfNews_Category]
GO
ALTER TABLE [dbo].[CategoryOfNews]  WITH CHECK ADD  CONSTRAINT [FK_CategoryOfNews_News] FOREIGN KEY([IdNews])
REFERENCES [dbo].[News] ([Id_news])
GO
ALTER TABLE [dbo].[CategoryOfNews] CHECK CONSTRAINT [FK_CategoryOfNews_News]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Restorans] FOREIGN KEY([RefIdRest])
REFERENCES [dbo].[Restorans] ([Id])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Restorans]
GO
ALTER TABLE [dbo].[Restorans]  WITH CHECK ADD  CONSTRAINT [FK_Restorans_Phones] FOREIGN KEY([IdPhone])
REFERENCES [dbo].[Phones] ([Id_phone])
GO
ALTER TABLE [dbo].[Restorans] CHECK CONSTRAINT [FK_Restorans_Phones]
GO
USE [master]
GO
ALTER DATABASE [News] SET  READ_WRITE 
GO
