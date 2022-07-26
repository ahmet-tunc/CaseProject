USE [master]
GO
/****** Object:  Database [dbCase]    Script Date: 24.07.2022 23:49:24 ******/
CREATE DATABASE [dbCase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbCase', FILENAME = N'C:\Users\Ahmet\dbCase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbCase_log', FILENAME = N'C:\Users\Ahmet\dbCase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [dbCase] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbCase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbCase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbCase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbCase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbCase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbCase] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbCase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbCase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbCase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbCase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbCase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbCase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbCase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbCase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbCase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbCase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbCase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbCase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbCase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbCase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbCase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbCase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbCase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbCase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbCase] SET  MULTI_USER 
GO
ALTER DATABASE [dbCase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbCase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbCase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbCase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbCase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbCase] SET QUERY_STORE = OFF
GO
USE [dbCase]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [dbCase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24.07.2022 23:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Histories]    Script Date: 24.07.2022 23:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Histories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](max) NULL,
	[EventDescription] [nvarchar](max) NULL,
	[HistoryCategoryId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
 CONSTRAINT [PK_Histories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryCategories]    Script Date: 24.07.2022 23:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LanguageId] [int] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
 CONSTRAINT [PK_HistoryCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 24.07.2022 23:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShortName] [nvarchar](max) NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 24.07.2022 23:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 24.07.2022 23:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.07.2022 23:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[Status] [bit] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Histories_CreatedUserId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_Histories_CreatedUserId] ON [dbo].[Histories]
(
	[CreatedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Histories_HistoryCategoryId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_Histories_HistoryCategoryId] ON [dbo].[Histories]
(
	[HistoryCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Histories_LanguageId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_Histories_LanguageId] ON [dbo].[Histories]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Histories_UpdatedUserId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_Histories_UpdatedUserId] ON [dbo].[Histories]
(
	[UpdatedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryCategories_CreatedUserId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryCategories_CreatedUserId] ON [dbo].[HistoryCategories]
(
	[CreatedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryCategories_LanguageId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryCategories_LanguageId] ON [dbo].[HistoryCategories]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HistoryCategories_UpdatedUserId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryCategories_UpdatedUserId] ON [dbo].[HistoryCategories]
(
	[UpdatedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Languages_CreatedUserId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_Languages_CreatedUserId] ON [dbo].[Languages]
(
	[CreatedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Languages_UpdatedUserId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_Languages_UpdatedUserId] ON [dbo].[Languages]
(
	[UpdatedUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 24.07.2022 23:49:24 ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Histories]  WITH CHECK ADD  CONSTRAINT [FK_Histories_HistoryCategories_HistoryCategoryId] FOREIGN KEY([HistoryCategoryId])
REFERENCES [dbo].[HistoryCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Histories] CHECK CONSTRAINT [FK_Histories_HistoryCategories_HistoryCategoryId]
GO
ALTER TABLE [dbo].[Histories]  WITH CHECK ADD  CONSTRAINT [FK_Histories_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Histories] CHECK CONSTRAINT [FK_Histories_Languages_LanguageId]
GO
ALTER TABLE [dbo].[Histories]  WITH CHECK ADD  CONSTRAINT [FK_Histories_Users_CreatedUserId] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Histories] CHECK CONSTRAINT [FK_Histories_Users_CreatedUserId]
GO
ALTER TABLE [dbo].[Histories]  WITH CHECK ADD  CONSTRAINT [FK_Histories_Users_UpdatedUserId] FOREIGN KEY([UpdatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Histories] CHECK CONSTRAINT [FK_Histories_Users_UpdatedUserId]
GO
ALTER TABLE [dbo].[HistoryCategories]  WITH CHECK ADD  CONSTRAINT [FK_HistoryCategories_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistoryCategories] CHECK CONSTRAINT [FK_HistoryCategories_Languages_LanguageId]
GO
ALTER TABLE [dbo].[HistoryCategories]  WITH CHECK ADD  CONSTRAINT [FK_HistoryCategories_Users_CreatedUserId] FOREIGN KEY([CreatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[HistoryCategories] CHECK CONSTRAINT [FK_HistoryCategories_Users_CreatedUserId]
GO
ALTER TABLE [dbo].[HistoryCategories]  WITH CHECK ADD  CONSTRAINT [FK_HistoryCategories_Users_UpdatedUserId] FOREIGN KEY([UpdatedUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[HistoryCategories] CHECK CONSTRAINT [FK_HistoryCategories_Users_UpdatedUserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [dbCase] SET  READ_WRITE 
GO
