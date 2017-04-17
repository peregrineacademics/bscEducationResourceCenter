USE [bbw]
GO
ALTER TABLE [dbo].[userRoles] DROP CONSTRAINT [FK_IdentityUserRole<string>_IdentityRole_roleId]
GO
ALTER TABLE [dbo].[userRoles] DROP CONSTRAINT [FK_IdentityUserRole<string>_ApplicationUser_userId]
GO
ALTER TABLE [dbo].[userLogins] DROP CONSTRAINT [FK_IdentityUserLogin<string>_ApplicationUser_userId]
GO
ALTER TABLE [dbo].[userClaims] DROP CONSTRAINT [FK_IdentityUserClaim<string>_ApplicationUser_userId]
GO
ALTER TABLE [dbo].[subTopic] DROP CONSTRAINT [FK_subTopic_discipline]
GO
ALTER TABLE [dbo].[roleClaims] DROP CONSTRAINT [FK_IdentityRoleClaim<string>_IdentityRole_roleId]
GO
ALTER TABLE [dbo].[reviewer] DROP CONSTRAINT [FK_reviewer_users1]
GO
ALTER TABLE [dbo].[reviewer] DROP CONSTRAINT [FK_reviewer_users]
GO
ALTER TABLE [dbo].[issue] DROP CONSTRAINT [FK_issue_users1]
GO
ALTER TABLE [dbo].[issue] DROP CONSTRAINT [FK_issue_users]
GO
ALTER TABLE [dbo].[articleSubTopic] DROP CONSTRAINT [FK_articleSubTopic_subTopic]
GO
ALTER TABLE [dbo].[articleSubTopic] DROP CONSTRAINT [FK_articleSubTopic_article]
GO
ALTER TABLE [dbo].[articleSector] DROP CONSTRAINT [FK_articleSector_sector]
GO
ALTER TABLE [dbo].[articleSector] DROP CONSTRAINT [FK_articleSector_article]
GO
ALTER TABLE [dbo].[articleRegion] DROP CONSTRAINT [FK_articleRegion_region]
GO
ALTER TABLE [dbo].[articleRegion] DROP CONSTRAINT [FK_articleRegion_article]
GO
ALTER TABLE [dbo].[articleQuizQuestion] DROP CONSTRAINT [FK_articleQuizQuestion_article]
GO
ALTER TABLE [dbo].[articleKeyLearningPoint] DROP CONSTRAINT [FK_articleKeyLearningPoint_article]
GO
ALTER TABLE [dbo].[articleDiscussionQuestion] DROP CONSTRAINT [FK_articleDiscussionQuestion_article]
GO
ALTER TABLE [dbo].[articleCompetency] DROP CONSTRAINT [FK_articleCompetency_competency]
GO
ALTER TABLE [dbo].[articleCompetency] DROP CONSTRAINT [FK_articleCompetency_article]
GO
ALTER TABLE [dbo].[articleActivity] DROP CONSTRAINT [FK_articleActivity_article]
GO
ALTER TABLE [dbo].[article] DROP CONSTRAINT [FK_article_users1]
GO
ALTER TABLE [dbo].[article] DROP CONSTRAINT [FK_article_users]
GO
ALTER TABLE [dbo].[article] DROP CONSTRAINT [FK_article_reviewer]
GO
ALTER TABLE [dbo].[article] DROP CONSTRAINT [FK_article_issue]
GO
ALTER TABLE [dbo].[article] DROP CONSTRAINT [FK_article_guideType]
GO
ALTER TABLE [dbo].[article] DROP CONSTRAINT [FK_article_articleStatus]
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [UserNameIndex] ON [dbo].[users]
GO
/****** Object:  Index [EmailIndex]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [EmailIndex] ON [dbo].[users]
GO
/****** Object:  Index [PK_subTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[subTopic] DROP CONSTRAINT [PK_subTopic]
GO
/****** Object:  Index [PK_sector]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[sector] DROP CONSTRAINT [PK_sector]
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [RoleNameIndex] ON [dbo].[roles]
GO
/****** Object:  Index [PK_reviewer]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[reviewer] DROP CONSTRAINT [PK_reviewer]
GO
/****** Object:  Index [PK_region]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[region] DROP CONSTRAINT [PK_region]
GO
/****** Object:  Index [PK_issue]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[issue] DROP CONSTRAINT [PK_issue]
GO
/****** Object:  Index [PK_guide]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[guideType] DROP CONSTRAINT [PK_guide]
GO
/****** Object:  Index [PK_discipline]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[discipline] DROP CONSTRAINT [PK_discipline]
GO
/****** Object:  Index [PK_competency]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[competency] DROP CONSTRAINT [PK_competency]
GO
/****** Object:  Index [PK_articleSubTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleSubTopic] DROP CONSTRAINT [PK_articleSubTopic]
GO
/****** Object:  Index [PK_articleStatus]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleStatus] DROP CONSTRAINT [PK_articleStatus]
GO
/****** Object:  Index [PK_articleSector]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleSector] DROP CONSTRAINT [PK_articleSector]
GO
/****** Object:  Index [PK_articleRegion]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleRegion] DROP CONSTRAINT [PK_articleRegion]
GO
/****** Object:  Index [PK_articleQuizQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleQuizQuestion] DROP CONSTRAINT [PK_articleQuizQuestion]
GO
/****** Object:  Index [PK_keyLearningPoint]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleKeyLearningPoint] DROP CONSTRAINT [PK_keyLearningPoint]
GO
/****** Object:  Index [PK_articleDiscussionQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleDiscussionQuestion] DROP CONSTRAINT [PK_articleDiscussionQuestion]
GO
/****** Object:  Index [PK_articleCompetency]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleCompetency] DROP CONSTRAINT [PK_articleCompetency]
GO
/****** Object:  Index [PK_articleActivity]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleActivity] DROP CONSTRAINT [PK_articleActivity]
GO
/****** Object:  Index [PK_article]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[article] DROP CONSTRAINT [PK_article]
GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_name] ON [dbo].[subTopic] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_name] ON [dbo].[sector] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_lastName_firstName_middleInitial]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_lastName_firstName_middleInitial] ON [dbo].[reviewer] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_name] ON [dbo].[region] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_name] ON [dbo].[guideType] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_name] ON [dbo].[discipline] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_name] ON [dbo].[competency] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_articleId_subTopicId]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_articleId_subTopicId] ON [dbo].[articleSubTopic] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_name] ON [dbo].[articleStatus] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_articleId_sectorId]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_articleId_sectorId] ON [dbo].[articleSector] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_articleId_regionId]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_articleId_regionId] ON [dbo].[articleRegion] WITH ( ONLINE = OFF )
GO
/****** Object:  Index [IX_articleId_competencyId]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP INDEX [IX_articleId_competencyId] ON [dbo].[articleCompetency] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[users]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[userRoles]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[userRoles]
GO
/****** Object:  Table [dbo].[userLogins]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[userLogins]
GO
/****** Object:  Table [dbo].[userClaims]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[userClaims]
GO
/****** Object:  Table [dbo].[subTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[subTopic]
GO
/****** Object:  Table [dbo].[sector]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[sector]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[roles]
GO
/****** Object:  Table [dbo].[roleClaims]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[roleClaims]
GO
/****** Object:  Table [dbo].[reviewer]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[reviewer]
GO
/****** Object:  Table [dbo].[region]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[region]
GO
/****** Object:  Table [dbo].[issue]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[issue]
GO
/****** Object:  Table [dbo].[guideType]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[guideType]
GO
/****** Object:  Table [dbo].[discipline]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[discipline]
GO
/****** Object:  Table [dbo].[competency]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[competency]
GO
/****** Object:  Table [dbo].[articleSubTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleSubTopic]
GO
/****** Object:  Table [dbo].[articleStatus]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleStatus]
GO
/****** Object:  Table [dbo].[articleSector]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleSector]
GO
/****** Object:  Table [dbo].[articleRegion]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleRegion]
GO
/****** Object:  Table [dbo].[articleQuizQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleQuizQuestion]
GO
/****** Object:  Table [dbo].[articleKeyLearningPoint]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleKeyLearningPoint]
GO
/****** Object:  Table [dbo].[articleDiscussionQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleDiscussionQuestion]
GO
/****** Object:  Table [dbo].[articleCompetency]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleCompetency]
GO
/****** Object:  Table [dbo].[articleActivity]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[articleActivity]
GO
/****** Object:  Table [dbo].[article]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP TABLE [dbo].[article]
GO
USE [master]
GO
/****** Object:  Database [bbw]    Script Date: 4/17/2017 1:49:24 PM ******/
DROP DATABASE [bbw]
GO
/****** Object:  Database [bbw]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE DATABASE [bbw] ON  PRIMARY 
( NAME = N'bbw', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\bbw.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bbw_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\bbw_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bbw] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bbw].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bbw] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bbw] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bbw] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bbw] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bbw] SET ARITHABORT OFF 
GO
ALTER DATABASE [bbw] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bbw] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [bbw] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bbw] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bbw] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bbw] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bbw] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bbw] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bbw] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bbw] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bbw] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bbw] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bbw] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bbw] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bbw] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bbw] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bbw] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bbw] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bbw] SET RECOVERY FULL 
GO
ALTER DATABASE [bbw] SET  MULTI_USER 
GO
ALTER DATABASE [bbw] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bbw] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'bbw', N'ON'
GO
USE [bbw]
GO
/****** Object:  Table [dbo].[article]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](1024) NOT NULL,
	[url] [nvarchar](max) NOT NULL,
	[issueId] [bigint] NOT NULL,
	[reviewerId] [bigint] NOT NULL,
	[abstract] [nvarchar](max) NOT NULL,
	[summary] [nvarchar](max) NOT NULL,
	[guideTypeId] [bigint] NOT NULL,
	[articleStatusId] [bigint] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[createdByUserId] [nvarchar](450) NOT NULL,
	[lastUpdated] [datetime] NOT NULL,
	[updatedByUserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleActivity]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleActivity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[activity] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleCompetency]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleCompetency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[competencyId] [bigint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleDiscussionQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleDiscussionQuestion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[question] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleKeyLearningPoint]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleKeyLearningPoint](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[keyLearningPoint] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleQuizQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleQuizQuestion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[questionTypeId] [bigint] NOT NULL,
	[quizQuestion] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleRegion]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleRegion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[regionId] [bigint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleSector]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleSector](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[sectorId] [bigint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleStatus]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleStatus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](25) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[articleSubTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articleSubTopic](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[articleId] [bigint] NOT NULL,
	[subTopicId] [bigint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[competency]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[competency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[discipline]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[discipline](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[guideType]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[guideType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[issue]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[issue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[issueDate] [datetime] NOT NULL,
	[coverImage] [nvarchar](max) NOT NULL,
	[isEnabled] [bit] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[createdByUserId] [nvarchar](450) NOT NULL,
	[lastUpdated] [datetime] NOT NULL,
	[updatedByUserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[region]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[region](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[reviewer]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[lastName] [nvarchar](64) NOT NULL,
	[firstName] [nvarchar](64) NOT NULL,
	[middleInitial] [nvarchar](64) NOT NULL,
	[degree] [nvarchar](64) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[isEnabled] [bit] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[createdByUserId] [nvarchar](450) NOT NULL,
	[lastUpdated] [datetime] NOT NULL,
	[updatedByUserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[roleClaims]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[claimType] [nvarchar](max) NULL,
	[claimValue] [nvarchar](max) NULL,
	[roleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_IdentityRoleClaim<string>] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[roles]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[Id] [nvarchar](450) NOT NULL,
	[concurrencyStamp] [nvarchar](max) NULL,
	[name] [nvarchar](max) NULL,
	[normalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_IdentityRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sector]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sector](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[subTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subTopic](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[disciplineId] [bigint] NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userClaims]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[claimType] [nvarchar](max) NULL,
	[claimValue] [nvarchar](max) NULL,
	[userId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_IdentityUserClaim<string>] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userLogins]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userLogins](
	[loginProvider] [nvarchar](450) NOT NULL,
	[providerKey] [nvarchar](450) NOT NULL,
	[providerDisplayName] [nvarchar](max) NULL,
	[userId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_IdentityUserLogin<string>] PRIMARY KEY CLUSTERED 
(
	[loginProvider] ASC,
	[providerKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userRoles]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userRoles](
	[userId] [nvarchar](450) NOT NULL,
	[roleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_IdentityUserRole<string>] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 4/17/2017 1:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[Id] [nvarchar](450) NOT NULL,
	[accessFailedCount] [int] NOT NULL,
	[concurrencyStamp] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[emailConfirmed] [bit] NOT NULL,
	[lockoutEnabled] [bit] NOT NULL,
	[lockoutEnd] [datetimeoffset](7) NULL,
	[normalizedEmail] [nvarchar](256) NULL,
	[normalizedUserName] [nvarchar](256) NULL,
	[passwordHash] [nvarchar](max) NULL,
	[phoneNumber] [nvarchar](max) NULL,
	[phoneNumberConfirmed] [bit] NOT NULL,
	[securityStamp] [nvarchar](max) NULL,
	[twoFactorEnabled] [bit] NOT NULL,
	[userName] [nvarchar](256) NOT NULL,
	[lastName] [nvarchar](256) NOT NULL,
	[firstName] [nvarchar](256) NOT NULL,
	[middleName] [nvarchar](256) NOT NULL,
	[title] [nvarchar](256) NOT NULL,
	[isEnabled] [bit] NOT NULL,
	[dateCreated] [datetime2](7) NOT NULL,
	[lastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_articleId_competencyId]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_articleId_competencyId] ON [dbo].[articleCompetency]
(
	[articleId] ASC,
	[competencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_articleId_regionId]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_articleId_regionId] ON [dbo].[articleRegion]
(
	[articleId] ASC,
	[regionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_articleId_sectorId]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_articleId_sectorId] ON [dbo].[articleSector]
(
	[articleId] ASC,
	[sectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[articleStatus]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_articleId_subTopicId]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_articleId_subTopicId] ON [dbo].[articleSubTopic]
(
	[articleId] ASC,
	[subTopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[competency]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[discipline]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[guideType]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[region]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_lastName_firstName_middleInitial]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_lastName_firstName_middleInitial] ON [dbo].[reviewer]
(
	[lastName] ASC,
	[firstName] ASC,
	[middleInitial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[sector]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_name]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[subTopic]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[guideType] ON 

INSERT [dbo].[guideType] ([Id], [name]) VALUES (1, N'Instructor Guide')
INSERT [dbo].[guideType] ([Id], [name]) VALUES (2, N'EDGE Guide')
SET IDENTITY_INSERT [dbo].[guideType] OFF
SET IDENTITY_INSERT [dbo].[sector] ON 

INSERT [dbo].[sector] ([Id], [name]) VALUES (1, N'test')
SET IDENTITY_INSERT [dbo].[sector] OFF
INSERT [dbo].[users] ([Id], [accessFailedCount], [concurrencyStamp], [email], [emailConfirmed], [lockoutEnabled], [lockoutEnd], [normalizedEmail], [normalizedUserName], [passwordHash], [phoneNumber], [phoneNumberConfirmed], [securityStamp], [twoFactorEnabled], [userName], [lastName], [firstName], [middleName], [title], [isEnabled], [dateCreated], [lastUpdated]) VALUES (N'e1ad7552-9398-496b-8233-bc1d1cb68d30', 0, N'5db951ec-3f1e-4e4f-b033-db0e3b160fb2', N'admin@peregrineacademics.com', 0, 1, NULL, N'ADMIN@PEREGRINEACADEMICS.COM', N'ADMIN@PEREGRINEACADEMICS.COM', N'AQAAAAEAACcQAAAAEEOJ5SPw2tZET+BUPtLeeIHtyDsezG9DI9qC6dsnGJFLVqydF/eZUl5xnajj7Ko4+Q==', NULL, 0, N'6357c65f-3a05-4490-bfa6-4315c8530259', 0, N'admin@peregrineacademics.com', N'Administrator', N'PAS', N'', N'', 1, CAST(N'2017-04-17 09:52:30.2864399' AS DateTime2), CAST(N'2017-04-17 09:52:30.2869419' AS DateTime2))
INSERT [dbo].[users] ([Id], [accessFailedCount], [concurrencyStamp], [email], [emailConfirmed], [lockoutEnabled], [lockoutEnd], [normalizedEmail], [normalizedUserName], [passwordHash], [phoneNumber], [phoneNumberConfirmed], [securityStamp], [twoFactorEnabled], [userName], [lastName], [firstName], [middleName], [title], [isEnabled], [dateCreated], [lastUpdated]) VALUES (N'f3992f9a-1e52-4573-a808-32b2399cb789', 0, N'7aa1c2df-3dba-4694-8cb4-3b5596db5b16', N'demo@peregrineacademics.com', 0, 1, NULL, N'DEMO@PEREGRINEACADEMICS.COM', N'DEMO@PEREGRINEACADEMICS.COM', N'AQAAAAEAACcQAAAAEGPrQhRFlA2Wdu/GkKL4KNa36Xpe7VV6XfHlciq24XjiZKz5X7xgZFq8BQLdYhiOhg==', NULL, 0, N'f3bce868-1c0b-4902-8f68-d73aff8d8b57', 0, N'demo@peregrineacademics.com', N'Administrator', N'PAS', N'', N'', 1, CAST(N'2017-04-10 09:43:08.5557743' AS DateTime2), CAST(N'2017-04-10 09:43:08.5567744' AS DateTime2))
/****** Object:  Index [PK_article]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[article] ADD  CONSTRAINT [PK_article] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleActivity]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleActivity] ADD  CONSTRAINT [PK_articleActivity] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleCompetency]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleCompetency] ADD  CONSTRAINT [PK_articleCompetency] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleDiscussionQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleDiscussionQuestion] ADD  CONSTRAINT [PK_articleDiscussionQuestion] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_keyLearningPoint]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleKeyLearningPoint] ADD  CONSTRAINT [PK_keyLearningPoint] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleQuizQuestion]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleQuizQuestion] ADD  CONSTRAINT [PK_articleQuizQuestion] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleRegion]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleRegion] ADD  CONSTRAINT [PK_articleRegion] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleSector]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleSector] ADD  CONSTRAINT [PK_articleSector] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleStatus]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleStatus] ADD  CONSTRAINT [PK_articleStatus] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_articleSubTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[articleSubTopic] ADD  CONSTRAINT [PK_articleSubTopic] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_competency]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[competency] ADD  CONSTRAINT [PK_competency] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_discipline]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[discipline] ADD  CONSTRAINT [PK_discipline] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_guide]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[guideType] ADD  CONSTRAINT [PK_guide] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_issue]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[issue] ADD  CONSTRAINT [PK_issue] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_region]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[region] ADD  CONSTRAINT [PK_region] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewer]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[reviewer] ADD  CONSTRAINT [PK_reviewer] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[roles]
(
	[normalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sector]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[sector] ADD  CONSTRAINT [PK_sector] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_subTopic]    Script Date: 4/17/2017 1:49:24 PM ******/
ALTER TABLE [dbo].[subTopic] ADD  CONSTRAINT [PK_subTopic] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[users]
(
	[normalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/17/2017 1:49:24 PM ******/
CREATE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[users]
(
	[normalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_articleStatus] FOREIGN KEY([articleStatusId])
REFERENCES [dbo].[articleStatus] ([Id])
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_articleStatus]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_guideType] FOREIGN KEY([guideTypeId])
REFERENCES [dbo].[guideType] ([Id])
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_guideType]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_issue] FOREIGN KEY([issueId])
REFERENCES [dbo].[issue] ([Id])
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_issue]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_reviewer] FOREIGN KEY([reviewerId])
REFERENCES [dbo].[reviewer] ([Id])
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_reviewer]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_users] FOREIGN KEY([createdByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_users]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_users1] FOREIGN KEY([updatedByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_users1]
GO
ALTER TABLE [dbo].[articleActivity]  WITH CHECK ADD  CONSTRAINT [FK_articleActivity_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleActivity] CHECK CONSTRAINT [FK_articleActivity_article]
GO
ALTER TABLE [dbo].[articleCompetency]  WITH CHECK ADD  CONSTRAINT [FK_articleCompetency_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleCompetency] CHECK CONSTRAINT [FK_articleCompetency_article]
GO
ALTER TABLE [dbo].[articleCompetency]  WITH CHECK ADD  CONSTRAINT [FK_articleCompetency_competency] FOREIGN KEY([competencyId])
REFERENCES [dbo].[competency] ([Id])
GO
ALTER TABLE [dbo].[articleCompetency] CHECK CONSTRAINT [FK_articleCompetency_competency]
GO
ALTER TABLE [dbo].[articleDiscussionQuestion]  WITH CHECK ADD  CONSTRAINT [FK_articleDiscussionQuestion_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleDiscussionQuestion] CHECK CONSTRAINT [FK_articleDiscussionQuestion_article]
GO
ALTER TABLE [dbo].[articleKeyLearningPoint]  WITH CHECK ADD  CONSTRAINT [FK_articleKeyLearningPoint_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleKeyLearningPoint] CHECK CONSTRAINT [FK_articleKeyLearningPoint_article]
GO
ALTER TABLE [dbo].[articleQuizQuestion]  WITH CHECK ADD  CONSTRAINT [FK_articleQuizQuestion_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleQuizQuestion] CHECK CONSTRAINT [FK_articleQuizQuestion_article]
GO
ALTER TABLE [dbo].[articleRegion]  WITH CHECK ADD  CONSTRAINT [FK_articleRegion_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleRegion] CHECK CONSTRAINT [FK_articleRegion_article]
GO
ALTER TABLE [dbo].[articleRegion]  WITH CHECK ADD  CONSTRAINT [FK_articleRegion_region] FOREIGN KEY([regionId])
REFERENCES [dbo].[region] ([Id])
GO
ALTER TABLE [dbo].[articleRegion] CHECK CONSTRAINT [FK_articleRegion_region]
GO
ALTER TABLE [dbo].[articleSector]  WITH CHECK ADD  CONSTRAINT [FK_articleSector_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleSector] CHECK CONSTRAINT [FK_articleSector_article]
GO
ALTER TABLE [dbo].[articleSector]  WITH CHECK ADD  CONSTRAINT [FK_articleSector_sector] FOREIGN KEY([sectorId])
REFERENCES [dbo].[sector] ([Id])
GO
ALTER TABLE [dbo].[articleSector] CHECK CONSTRAINT [FK_articleSector_sector]
GO
ALTER TABLE [dbo].[articleSubTopic]  WITH CHECK ADD  CONSTRAINT [FK_articleSubTopic_article] FOREIGN KEY([articleId])
REFERENCES [dbo].[article] ([Id])
GO
ALTER TABLE [dbo].[articleSubTopic] CHECK CONSTRAINT [FK_articleSubTopic_article]
GO
ALTER TABLE [dbo].[articleSubTopic]  WITH CHECK ADD  CONSTRAINT [FK_articleSubTopic_subTopic] FOREIGN KEY([subTopicId])
REFERENCES [dbo].[subTopic] ([Id])
GO
ALTER TABLE [dbo].[articleSubTopic] CHECK CONSTRAINT [FK_articleSubTopic_subTopic]
GO
ALTER TABLE [dbo].[issue]  WITH CHECK ADD  CONSTRAINT [FK_issue_users] FOREIGN KEY([createdByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[issue] CHECK CONSTRAINT [FK_issue_users]
GO
ALTER TABLE [dbo].[issue]  WITH CHECK ADD  CONSTRAINT [FK_issue_users1] FOREIGN KEY([updatedByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[issue] CHECK CONSTRAINT [FK_issue_users1]
GO
ALTER TABLE [dbo].[reviewer]  WITH CHECK ADD  CONSTRAINT [FK_reviewer_users] FOREIGN KEY([createdByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[reviewer] CHECK CONSTRAINT [FK_reviewer_users]
GO
ALTER TABLE [dbo].[reviewer]  WITH CHECK ADD  CONSTRAINT [FK_reviewer_users1] FOREIGN KEY([updatedByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[reviewer] CHECK CONSTRAINT [FK_reviewer_users1]
GO
ALTER TABLE [dbo].[roleClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityRoleClaim<string>_IdentityRole_roleId] FOREIGN KEY([roleId])
REFERENCES [dbo].[roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[roleClaims] CHECK CONSTRAINT [FK_IdentityRoleClaim<string>_IdentityRole_roleId]
GO
ALTER TABLE [dbo].[subTopic]  WITH CHECK ADD  CONSTRAINT [FK_subTopic_discipline] FOREIGN KEY([disciplineId])
REFERENCES [dbo].[discipline] ([Id])
GO
ALTER TABLE [dbo].[subTopic] CHECK CONSTRAINT [FK_subTopic_discipline]
GO
ALTER TABLE [dbo].[userClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserClaim<string>_ApplicationUser_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[userClaims] CHECK CONSTRAINT [FK_IdentityUserClaim<string>_ApplicationUser_userId]
GO
ALTER TABLE [dbo].[userLogins]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserLogin<string>_ApplicationUser_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[userLogins] CHECK CONSTRAINT [FK_IdentityUserLogin<string>_ApplicationUser_userId]
GO
ALTER TABLE [dbo].[userRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole<string>_ApplicationUser_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[userRoles] CHECK CONSTRAINT [FK_IdentityUserRole<string>_ApplicationUser_userId]
GO
ALTER TABLE [dbo].[userRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole<string>_IdentityRole_roleId] FOREIGN KEY([roleId])
REFERENCES [dbo].[roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[userRoles] CHECK CONSTRAINT [FK_IdentityUserRole<string>_IdentityRole_roleId]
GO
USE [master]
GO
ALTER DATABASE [bbw] SET  READ_WRITE 
GO
