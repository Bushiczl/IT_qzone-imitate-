USE [master]
GO
/****** Object:  Database [qzone]    Script Date: 2017/12/9 20:47:22 ******/
CREATE DATABASE [qzone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'qzone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\qzone.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'qzone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\qzone_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [qzone] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [qzone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [qzone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [qzone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [qzone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [qzone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [qzone] SET ARITHABORT OFF 
GO
ALTER DATABASE [qzone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [qzone] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [qzone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [qzone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [qzone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [qzone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [qzone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [qzone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [qzone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [qzone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [qzone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [qzone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [qzone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [qzone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [qzone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [qzone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [qzone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [qzone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [qzone] SET RECOVERY FULL 
GO
ALTER DATABASE [qzone] SET  MULTI_USER 
GO
ALTER DATABASE [qzone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [qzone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [qzone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [qzone] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'qzone', N'ON'
GO
USE [qzone]
GO
/****** Object:  Table [dbo].[bit]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [bit] NOT NULL,
 CONSTRAINT [PK_bit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[data]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tableId] [int] NOT NULL,
	[style] [int] NOT NULL,
 CONSTRAINT [PK_data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[int]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[int](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [int] NOT NULL,
 CONSTRAINT [PK_int] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[lines]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lines](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstId] [int] NOT NULL,
	[secondId] [int] NOT NULL,
	[style] [int] NULL,
 CONSTRAINT [PK_lines] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nchar10]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nchar10](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [nchar](10) NOT NULL,
 CONSTRAINT [PK_nchar10] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nchar30]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nchar30](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [nchar](30) NOT NULL,
 CONSTRAINT [PK_nchar20] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ncharMAX]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ncharMAX](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ncharMAX] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[smalldatatime]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[smalldatatime](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_smalldatetime] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[style]    Script Date: 2017/12/9 20:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[style](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[styleName] [nchar](30) NOT NULL,
	[tableName] [nchar](30) NULL,
 CONSTRAINT [PK_style] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bit] ON 

INSERT [dbo].[bit] ([id], [data]) VALUES (2, 1)
SET IDENTITY_INSERT [dbo].[bit] OFF
SET IDENTITY_INSERT [dbo].[data] ON 

INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1, 1, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (2, 2, 2)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (3, 3, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (4, 4, 2)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (5, 5, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (6, 6, 2)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (7, 7, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (8, 8, 2)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (9, 11, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (10, 12, 2)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (11, 13, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (12, 14, 2)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (13, 15, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (14, 16, 2)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1009, 1009, 4)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1010, 2, 5)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1011, 1, 6)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1012, 1, 7)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1013, 2, 8)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1014, 1, 9)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1029, 1023, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1030, 1024, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1036, 1030, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1037, 1031, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1042, 1036, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1043, 1037, 11)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1044, 3, 12)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1045, 1038, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1049, 1041, 11)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1050, 5, 12)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1051, 1042, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1081, 20, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1082, 9, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1083, 21, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1084, 10, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1085, 22, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1086, 11, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1087, 23, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1088, 12, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1089, 24, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1090, 13, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1091, 25, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1092, 14, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1093, 15, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1094, 26, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1095, 16, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1096, 27, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1097, 17, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1098, 28, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1099, 18, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1100, 29, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1111, 35, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1112, 24, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1119, 39, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1120, 28, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1129, 44, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1130, 33, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1135, 47, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1136, 36, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1137, 48, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1138, 37, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1139, 38, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1140, 49, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1141, 39, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1142, 50, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1143, 40, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1144, 51, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1145, 41, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1146, 52, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1147, 1043, 11)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1148, 53, 12)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1149, 1044, 11)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1150, 54, 12)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1151, 1045, 11)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1152, 55, 12)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1153, 1046, 11)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1154, 56, 12)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1155, 57, 22)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1156, 42, 23)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1161, 60, 22)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1162, 45, 23)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1165, 62, 22)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1166, 47, 23)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1167, 63, 22)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1168, 48, 23)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1169, 64, 22)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1170, 49, 23)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1173, 66, 24)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1174, 51, 25)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1175, 67, 24)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1176, 52, 25)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1177, 68, 22)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1178, 53, 23)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1179, 69, 24)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1180, 54, 25)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1181, 1047, 26)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1182, 1048, 27)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1183, 1049, 1)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1184, 1050, 2)
GO
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1185, 1051, 26)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1186, 70, 15)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1187, 55, 16)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1188, 56, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1189, 71, 21)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1190, 1052, 11)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1191, 72, 12)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1192, 73, 22)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1193, 57, 23)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1194, 1053, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1195, 1054, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1196, 74, 24)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1197, 58, 25)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1198, 1055, 27)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1199, 1056, 14)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1200, 59, 20)
INSERT [dbo].[data] ([id], [tableId], [style]) VALUES (1201, 75, 21)
SET IDENTITY_INSERT [dbo].[data] OFF
SET IDENTITY_INSERT [dbo].[int] ON 

INSERT [dbo].[int] ([id], [data]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[int] OFF
SET IDENTITY_INSERT [dbo].[lines] ON 

INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1, 1, 2, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (2, 3, 4, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (3, 5, 6, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (4, 7, 8, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (5, 9, 10, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (6, 11, 12, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (7, 13, 14, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1005, 1, 1009, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1006, 1, 1010, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1007, 1, 1011, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1008, 1, 1012, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1009, 1, 1013, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1010, 1, 1014, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1025, 1, 1029, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1026, 1, 1030, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1032, 1, 1036, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1033, 1, 1037, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1038, 1, 1042, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1044, 1, 1049, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1045, 1049, 1050, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1046, 1, 1051, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1059, 1, 3, 19)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1060, 3, 1, 19)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1095, 1, 1081, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1096, 1081, 1082, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1097, 1, 1083, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1098, 1083, 1084, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1099, 1, 1085, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1100, 1085, 1086, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1101, 3, 1087, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1102, 1087, 1088, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1103, 3, 1089, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1104, 1089, 1090, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1105, 1, 1091, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1106, 1091, 1092, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1107, 1094, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1108, 1094, 1093, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1109, 1091, 1094, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1110, 1094, 1091, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1111, 1096, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1112, 1096, 1095, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1113, 1089, 1096, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1114, 1096, 1089, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1115, 1098, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1116, 1098, 1097, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1117, 1087, 1098, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1118, 1098, 1087, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1119, 1100, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1120, 1100, 1099, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1121, 1085, 1100, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1122, 1100, 1085, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1139, 1, 1111, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1140, 1111, 1112, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1147, 1, 1119, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1148, 1119, 1120, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1157, 1, 1129, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1158, 1129, 1130, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1163, 1, 1135, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1164, 1135, 1136, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1165, 3, 1137, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1166, 1137, 1138, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1167, 1140, 3, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1168, 1140, 1139, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1169, 1129, 1140, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1170, 1140, 1129, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1171, 1142, 3, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1172, 1142, 1141, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1173, 1135, 1142, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1174, 1142, 1135, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1175, 1144, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1176, 1144, 1143, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1177, 1129, 1144, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1178, 1144, 1129, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1179, 1146, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1180, 1146, 1145, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1181, 1135, 1146, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1182, 1146, 1135, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1183, 1, 1147, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1184, 1147, 1148, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1185, 1, 1149, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1186, 1149, 1150, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1187, 1, 1151, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1188, 1151, 1152, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1189, 1, 1153, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1190, 1153, 1154, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1191, 1155, 1156, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1192, 1151, 1155, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1193, 1155, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1200, 1161, 1162, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1201, 1049, 1161, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1202, 1161, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1206, 1165, 1166, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1207, 1049, 1165, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1208, 1165, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1209, 1167, 1168, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1210, 1149, 1167, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1211, 1167, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1212, 1169, 1170, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1213, 1151, 1169, 10)
GO
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1214, 1169, 1, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1217, 1, 1173, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1218, 1173, 1174, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1219, 1, 1175, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1220, 1175, 1176, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1221, 1177, 1178, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1222, 1151, 1177, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1223, 1177, 3, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1224, 3, 1179, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1225, 1179, 1180, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1226, 1, 1181, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1227, 1, 1182, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1228, 1183, 1184, 3)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1229, 1183, 1185, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1230, 1183, 1, 19)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1231, 1, 1183, 19)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1232, 1183, 1186, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1233, 1186, 1187, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1234, 1189, 1183, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1235, 1189, 1188, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1236, 1135, 1189, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1237, 1189, 1135, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1238, 1183, 1190, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1239, 1190, 1191, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1240, 1192, 1193, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1241, 1190, 1192, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1242, 1192, 1183, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1243, 1183, 1194, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1244, 1183, 1195, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1245, 1183, 1196, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1246, 1196, 1197, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1247, 1183, 1198, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1248, 1183, 1199, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1249, 1201, 1183, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1250, 1201, 1200, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1251, 1186, 1201, 10)
INSERT [dbo].[lines] ([id], [firstId], [secondId], [style]) VALUES (1252, 1201, 1186, 10)
SET IDENTITY_INSERT [dbo].[lines] OFF
SET IDENTITY_INSERT [dbo].[nchar10] ON 

INSERT [dbo].[nchar10] ([id], [data]) VALUES (1, N'1212-12-13')
INSERT [dbo].[nchar10] ([id], [data]) VALUES (2, N'heiheihei ')
SET IDENTITY_INSERT [dbo].[nchar10] OFF
SET IDENTITY_INSERT [dbo].[nchar30] ON 

INSERT [dbo].[nchar30] ([id], [data]) VALUES (1, N'123                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (2, N'-1623739142                   ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (3, N'234                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (4, N'123                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (5, N'567                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (6, N'789                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (7, N'789                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (8, N'234                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (11, N'abc                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (12, N'abc                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (13, N'asd                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (14, N'123                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (15, N'sdf                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (16, N'123                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1009, N'script                        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1023, N'636472418999129294.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1024, N'636472419032928086.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1030, N'636472419569879458.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1031, N'636472419765799973.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1036, N'636472424260541062.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1037, N'234                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1038, N'636473230174739649.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1041, N'hhh                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1042, N'636475470566465712.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1043, N'13                            ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1044, N'如果                            ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1045, N'label是万能的！                    ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1046, N'aaa   bb      s               ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1047, N'1045932460@qq.com             ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1048, N'Hxp1hCR7h1rz86gqPnuup3SfGuW4r4')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1049, N'test                          ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1050, N'-354185609                    ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1051, N'1045932460@qq.com             ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1052, N'OMG                           ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1053, N'636481835469183896.png        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1054, N'636481835874472307.jpg        ')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1055, N'bP5DPCiegavNXfdkt7uoGf5HgnK58C')
INSERT [dbo].[nchar30] ([id], [data]) VALUES (1056, N'636483276367242368.png        ')
SET IDENTITY_INSERT [dbo].[nchar30] OFF
SET IDENTITY_INSERT [dbo].[ncharMAX] ON 

INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (1, N'额额蛤')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (3, N'')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (5, N'<p>uuukuku<span style="font-family: arial, helvetica, sans-serif;">u,ku,k,k<strong>ukiukuik</strong></span></p>')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (20, N'sfddfbdb')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (21, N'fbbfgb')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (22, N'aaaa    sdvv')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (23, N'lalalalal')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (24, N'houhouhouhou')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (25, N'emmm')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (26, N'123 :deep')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (27, N'123 :dark')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (28, N'123 :sometimes')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (29, N'123 :too too')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (35, N'啊啊啊datetime存到数据库里显示不出秒啊啊啊精度最高一分钟啊啊啊')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (39, N'盲人dota')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (44, N'楼上手撕树套树')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (47, N'楼下闭眼网络流')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (48, N'好友的动态你不能删↗')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (49, N'234 :来试试&lt;script&gt; heiheihei')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (50, N'234 :再试试引号')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (51, N'123 :你知不知道chrome有个神奇的功能？&#60;[数据删除]&#62;')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (52, N'123 :不不不引号这个真的会炸')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (53, N'<p><strong>666 666</strong></p>')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (54, N'<p>啊</p>')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (55, N'<p><span style="text-decoration: underline;">但是受到分数的<span style="text-decoration: underline; font-family: &quot;arial black&quot;, &quot;avant garde&quot;;">大递四方速递分数的<span style="text-decoration: underline; font-family: 微软雅黑, &quot;Microsoft YaHei&quot;;">啥的是山东师范<span style="text-decoration: underline; font-family: 微软雅黑, &quot;Microsoft YaHei&quot;; font-size: 24px;">多少分多少分都是<span style="text-decoration: underline; font-size: 24px; font-family: impact, chicago;">水电费飞啊<strong>都是</strong></span></span></span></span></span><br/></p>')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (56, N'<p>aaavv v v v v asacacasc&nbsp; &nbsp;ascsacsacsa&nbsp; &nbsp;vdsvds</p>')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (57, N'123:123')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (60, N'123:asdsad')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (62, N'123:vc cv vc ')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (63, N'123:gggg')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (64, N'123:aaaa')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (66, N'123                           ：哈哈哈哈我终于做好啦')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (67, N'234                           ：呵呵呵呵恭喜你啊')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (68, N'234:对的，是万能的')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (69, N'123                           ：asdsad')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (70, N'庆祝我终于完成了90%（因为还有一堆麻烦的功能），心态快崩了')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (71, N'test :好友的好友不是我的好友')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (72, N'<p>这个地方的尖括号怎么防</p>')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (73, N'test:我的天')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (74, N'test                          ：发顺丰多少分多少分东方闪电')
INSERT [dbo].[ncharMAX] ([id], [data]) VALUES (75, N'test :今天星期五，心拔凉拔凉的')
SET IDENTITY_INSERT [dbo].[ncharMAX] OFF
SET IDENTITY_INSERT [dbo].[smalldatatime] ON 

INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (9, CAST(0xA83C02A6 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (10, CAST(0xA83C02A6 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (11, CAST(0xA83C02A6 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (12, CAST(0xA83C02A6 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (13, CAST(0xA83C02A6 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (14, CAST(0xA83C02A7 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (15, CAST(0xA83C02A9 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (16, CAST(0xA83C02A9 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (17, CAST(0xA83C02A9 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (18, CAST(0xA83C02A9 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (24, CAST(0xA83C0382 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (28, CAST(0xA83E038E AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (33, CAST(0xA83E038F AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (36, CAST(0xA83E0390 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (37, CAST(0xA83E0391 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (38, CAST(0xA83E0392 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (39, CAST(0xA83E0393 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (40, CAST(0xA83E0394 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (41, CAST(0xA83E0394 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (42, CAST(0xA83F04BE AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (45, CAST(0xA83F04CA AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (47, CAST(0xA83F04CA AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (48, CAST(0xA84003FA AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (49, CAST(0xA84003FA AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (51, CAST(0xA8400482 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (52, CAST(0xA8400483 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (53, CAST(0xA8400483 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (54, CAST(0xA84004EA AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (55, CAST(0xA8410471 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (56, CAST(0xA8410472 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (57, CAST(0xA8410472 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (58, CAST(0xA8410474 AS SmallDateTime))
INSERT [dbo].[smalldatatime] ([id], [data]) VALUES (59, CAST(0xA84302A8 AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[smalldatatime] OFF
SET IDENTITY_INSERT [dbo].[style] ON 

INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (1, N'username                      ', N'nchar30                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (2, N'password                      ', N'nchar30                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (3, N'UnToPwd                       ', N'null                          ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (4, N'nickName                      ', N'nchar30                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (5, N'sex                           ', N'bit                           ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (6, N'birthday                      ', N'nchar10                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (7, N'bloodType                     ', N'int                           ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (8, N'job                           ', N'nchar10                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (9, N'introduction                  ', N'ncharMAX                      ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (10, N'null                          ', N'null                          ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (11, N'journalTitle                  ', N'nchar30                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (12, N'journalData                   ', N'ncharMAX                      ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (14, N'imagesUrl                     ', N'nchar30                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (15, N'dynamicContent                ', N'ncharMAX                      ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (16, N'dynamicEditTime               ', N'smalldatatime                 ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (19, N'linesFriend                   ', N'null                          ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (20, N'replyEditTime                 ', N'smalldatatime                 ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (21, N'replyContent                  ', N'ncharMAX                      ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (22, N'journalReplyContent           ', N'ncharMAX                      ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (23, N'journalReplyTime              ', N'smalldatatime                 ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (24, N'messageContent                ', N'ncharMAX                      ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (25, N'messageTime                   ', N'smalldatatime                 ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (26, N'email                         ', N'nchar30                       ')
INSERT [dbo].[style] ([id], [styleName], [tableName]) VALUES (27, N'userIdInCookies               ', N'nchar30                       ')
SET IDENTITY_INSERT [dbo].[style] OFF
ALTER TABLE [dbo].[lines]  WITH CHECK ADD  CONSTRAINT [FK_lines_data] FOREIGN KEY([firstId])
REFERENCES [dbo].[data] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[lines] CHECK CONSTRAINT [FK_lines_data]
GO
USE [master]
GO
ALTER DATABASE [qzone] SET  READ_WRITE 
GO
