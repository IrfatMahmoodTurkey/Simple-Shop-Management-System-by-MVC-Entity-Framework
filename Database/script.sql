USE [master]
GO
/****** Object:  Database [ShopManagementSystemDb]    Script Date: 28/10/2018 21:56:48 ******/
CREATE DATABASE [ShopManagementSystemDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopManagementSystemDb', FILENAME = N'G:\Microsoft SQL server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShopManagementSystemDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ShopManagementSystemDb_log', FILENAME = N'G:\Microsoft SQL server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShopManagementSystemDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ShopManagementSystemDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopManagementSystemDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopManagementSystemDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopManagementSystemDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopManagementSystemDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopManagementSystemDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopManagementSystemDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopManagementSystemDb] SET  MULTI_USER 
GO
ALTER DATABASE [ShopManagementSystemDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopManagementSystemDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopManagementSystemDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopManagementSystemDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ShopManagementSystemDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ShopManagementSystemDb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ActionType] [nvarchar](max) NULL,
	[ActionDate] [nvarchar](max) NULL,
	[ActionBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Companies]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[ActionType] [nvarchar](max) NULL,
	[ActionDate] [nvarchar](max) NULL,
	[ActionBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Damageds]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Damageds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ActionType] [nvarchar](max) NULL,
	[ActionDate] [nvarchar](max) NULL,
	[ActionBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Damageds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ItemName] [nvarchar](100) NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ActionType] [nvarchar](max) NULL,
	[ActionDate] [nvarchar](max) NULL,
	[ActionBy] [nvarchar](max) NULL,
	[SerialNo] [nvarchar](50) NULL,
	[Quantity] [int] NOT NULL DEFAULT ((0)),
	[SellPrice] [decimal](18, 2) NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Losses]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Losses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ActionType] [nvarchar](max) NULL,
	[ActionDate] [nvarchar](max) NULL,
	[ActionBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Losses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sells]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sells](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
	[ActionType] [nvarchar](max) NULL,
	[ActionDate] [nvarchar](max) NULL,
	[ActionBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Sells] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockIns]    Script Date: 28/10/2018 21:56:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockIns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Date] [nvarchar](max) NOT NULL,
	[StockInQuantity] [int] NOT NULL,
	[Month] [nvarchar](max) NULL,
	[Year] [nvarchar](max) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[ActionType] [nvarchar](max) NULL,
	[ActionDate] [nvarchar](max) NULL,
	[ActionBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.StockIns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Id]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[AspNetUserClaims]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyId] ON [dbo].[Damageds]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_ItemId] ON [dbo].[Damageds]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Items]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyId] ON [dbo].[Items]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyId] ON [dbo].[Losses]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_ItemId] ON [dbo].[Losses]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyId] ON [dbo].[Sells]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_ItemId] ON [dbo].[Sells]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CompanyId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_CompanyId] ON [dbo].[StockIns]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ItemId]    Script Date: 28/10/2018 21:56:50 ******/
CREATE NONCLUSTERED INDEX [IX_ItemId] ON [dbo].[StockIns]
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Damageds]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damageds_dbo.Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Damageds] CHECK CONSTRAINT [FK_dbo.Damageds_dbo.Companies_CompanyId]
GO
ALTER TABLE [dbo].[Damageds]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Damageds_dbo.Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[Damageds] CHECK CONSTRAINT [FK_dbo.Damageds_dbo.Items_ItemId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Items_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_dbo.Items_dbo.Categories_CategoryId]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Items_dbo.Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_dbo.Items_dbo.Companies_CompanyId]
GO
ALTER TABLE [dbo].[Losses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Losses_dbo.Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Losses] CHECK CONSTRAINT [FK_dbo.Losses_dbo.Companies_CompanyId]
GO
ALTER TABLE [dbo].[Losses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Losses_dbo.Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[Losses] CHECK CONSTRAINT [FK_dbo.Losses_dbo.Items_ItemId]
GO
ALTER TABLE [dbo].[Sells]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sells_dbo.Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Sells] CHECK CONSTRAINT [FK_dbo.Sells_dbo.Companies_CompanyId]
GO
ALTER TABLE [dbo].[Sells]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Sells_dbo.Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[Sells] CHECK CONSTRAINT [FK_dbo.Sells_dbo.Items_ItemId]
GO
ALTER TABLE [dbo].[StockIns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StockIns_dbo.Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[StockIns] CHECK CONSTRAINT [FK_dbo.StockIns_dbo.Companies_CompanyId]
GO
ALTER TABLE [dbo].[StockIns]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StockIns_dbo.Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[StockIns] CHECK CONSTRAINT [FK_dbo.StockIns_dbo.Items_ItemId]
GO
USE [master]
GO
ALTER DATABASE [ShopManagementSystemDb] SET  READ_WRITE 
GO
