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
ALTER TABLE [dbo].[reviewSubTopic] DROP CONSTRAINT [FK_reviewSubTopic_subTopic]
GO
ALTER TABLE [dbo].[reviewSubTopic] DROP CONSTRAINT [FK_reviewSubTopic_review]
GO
ALTER TABLE [dbo].[reviewSector] DROP CONSTRAINT [FK_reviewSector_sector]
GO
ALTER TABLE [dbo].[reviewSector] DROP CONSTRAINT [FK_reviewSector_review]
GO
ALTER TABLE [dbo].[reviewRegion] DROP CONSTRAINT [FK_reviewRegion_review]
GO
ALTER TABLE [dbo].[reviewRegion] DROP CONSTRAINT [FK_reviewRegion_region]
GO
ALTER TABLE [dbo].[reviewKeyLearningPoint] DROP CONSTRAINT [FK_reviewKeyLearningPoint_review]
GO
ALTER TABLE [dbo].[reviewer] DROP CONSTRAINT [FK_reviewer_users1]
GO
ALTER TABLE [dbo].[reviewer] DROP CONSTRAINT [FK_reviewer_users]
GO
ALTER TABLE [dbo].[reviewCompetency] DROP CONSTRAINT [FK_reviewCompetency_review]
GO
ALTER TABLE [dbo].[reviewCompetency] DROP CONSTRAINT [FK_reviewCompetency_competency]
GO
ALTER TABLE [dbo].[reviewActivity] DROP CONSTRAINT [FK_reviewActivity_review]
GO
ALTER TABLE [dbo].[review] DROP CONSTRAINT [FK_review_usersUpdated]
GO
ALTER TABLE [dbo].[review] DROP CONSTRAINT [FK_review_usersCreated]
GO
ALTER TABLE [dbo].[review] DROP CONSTRAINT [FK_review_reviewStatus]
GO
ALTER TABLE [dbo].[review] DROP CONSTRAINT [FK_review_reviewer]
GO
ALTER TABLE [dbo].[review] DROP CONSTRAINT [FK_review_issue]
GO
ALTER TABLE [dbo].[review] DROP CONSTRAINT [FK_review_guideType]
GO
ALTER TABLE [dbo].[quizQuestion] DROP CONSTRAINT [FK_quizQuestion_review]
GO
ALTER TABLE [dbo].[quizQuestion] DROP CONSTRAINT [FK_quizQuestion_questionType]
GO
ALTER TABLE [dbo].[quizAnswer] DROP CONSTRAINT [FK_quizAnswer_quizQuestion]
GO
ALTER TABLE [dbo].[issue] DROP CONSTRAINT [FK_issue_users1]
GO
ALTER TABLE [dbo].[issue] DROP CONSTRAINT [FK_issue_users]
GO
ALTER TABLE [dbo].[discussionQuestion] DROP CONSTRAINT [FK_discussionQuestion_review]
GO
/****** Object:  Index [UserNameIndex]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [UserNameIndex] ON [dbo].[users]
GO
/****** Object:  Index [EmailIndex]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [EmailIndex] ON [dbo].[users]
GO
/****** Object:  Index [PK_subTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[subTopic] DROP CONSTRAINT [PK_subTopic]
GO
/****** Object:  Index [PK_sector]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[sector] DROP CONSTRAINT [PK_sector]
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [RoleNameIndex] ON [dbo].[roles]
GO
/****** Object:  Index [PK_reviewSubTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewSubTopic] DROP CONSTRAINT [PK_reviewSubTopic]
GO
/****** Object:  Index [PK_reviewStatus]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewStatus] DROP CONSTRAINT [PK_reviewStatus]
GO
/****** Object:  Index [PK_reviewSector]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewSector] DROP CONSTRAINT [PK_reviewSector]
GO
/****** Object:  Index [PK_reviewRegion]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewRegion] DROP CONSTRAINT [PK_reviewRegion]
GO
/****** Object:  Index [PK_keyLearningPoint]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewKeyLearningPoint] DROP CONSTRAINT [PK_keyLearningPoint]
GO
/****** Object:  Index [PK_reviewer]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewer] DROP CONSTRAINT [PK_reviewer]
GO
/****** Object:  Index [PK_reviewCompetency]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewCompetency] DROP CONSTRAINT [PK_reviewCompetency]
GO
/****** Object:  Index [PK_reviewActivity]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewActivity] DROP CONSTRAINT [PK_reviewActivity]
GO
/****** Object:  Index [PK_review]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[review] DROP CONSTRAINT [PK_review]
GO
/****** Object:  Index [PK_region]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[region] DROP CONSTRAINT [PK_region]
GO
/****** Object:  Index [PK_quizQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[quizQuestion] DROP CONSTRAINT [PK_quizQuestion]
GO
/****** Object:  Index [PK_quizAnswer]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[quizAnswer] DROP CONSTRAINT [PK_quizAnswer]
GO
/****** Object:  Index [PK_question]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[questionType] DROP CONSTRAINT [PK_question]
GO
/****** Object:  Index [PK_issue]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[issue] DROP CONSTRAINT [PK_issue]
GO
/****** Object:  Index [PK_guide]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[guideType] DROP CONSTRAINT [PK_guide]
GO
/****** Object:  Index [PK_discussionQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[discussionQuestion] DROP CONSTRAINT [PK_discussionQuestion]
GO
/****** Object:  Index [PK_discipline]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[discipline] DROP CONSTRAINT [PK_discipline]
GO
/****** Object:  Index [PK_competency]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[competency] DROP CONSTRAINT [PK_competency]
GO
/****** Object:  Table [dbo].[users]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[users]
GO
/****** Object:  Table [dbo].[userRoles]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[userRoles]
GO
/****** Object:  Table [dbo].[userLogins]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[userLogins]
GO
/****** Object:  Table [dbo].[userClaims]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[userClaims]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[subTopic] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[subTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[subTopic]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[sector] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[sector]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[sector]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[roles]
GO
/****** Object:  Table [dbo].[roleClaims]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[roleClaims]
GO
/****** Object:  Index [IX_reviewId_subTopicId]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_reviewId_subTopicId] ON [dbo].[reviewSubTopic] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[reviewSubTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewSubTopic]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[reviewStatus] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[reviewStatus]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewStatus]
GO
/****** Object:  Index [IX_reviewId_sectorId]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_reviewId_sectorId] ON [dbo].[reviewSector] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[reviewSector]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewSector]
GO
/****** Object:  Index [IX_reviewId_regionId]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_reviewId_regionId] ON [dbo].[reviewRegion] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[reviewRegion]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewRegion]
GO
/****** Object:  Table [dbo].[reviewKeyLearningPoint]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewKeyLearningPoint]
GO
/****** Object:  Index [IX_lastName_firstName_middleInitial]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_lastName_firstName_middleInitial] ON [dbo].[reviewer] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[reviewer]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewer]
GO
/****** Object:  Index [IX_reviewId_competencyId]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_reviewId_competencyId] ON [dbo].[reviewCompetency] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[reviewCompetency]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewCompetency]
GO
/****** Object:  Table [dbo].[reviewActivity]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[reviewActivity]
GO
/****** Object:  Table [dbo].[review]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[review]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[region] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[region]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[region]
GO
/****** Object:  Table [dbo].[quizQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[quizQuestion]
GO
/****** Object:  Table [dbo].[quizAnswer]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[quizAnswer]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[questionType] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[questionType]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[questionType]
GO
/****** Object:  Table [dbo].[issue]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[issue]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[guideType] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[guideType]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[guideType]
GO
/****** Object:  Table [dbo].[discussionQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[discussionQuestion]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[discipline] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[discipline]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[discipline]
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP INDEX [IX_name] ON [dbo].[competency] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[competency]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP TABLE [dbo].[competency]
GO
USE [master]
GO
/****** Object:  Database [bbw]    Script Date: 6/26/2017 11:27:15 AM ******/
DROP DATABASE [bbw]
GO
/****** Object:  Database [bbw]    Script Date: 6/26/2017 11:27:15 AM ******/
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
/****** Object:  Table [dbo].[competency]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[competency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[competency]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[discipline]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[discipline](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[discipline]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[discussionQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[discussionQuestion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[question] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[guideType]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[guideType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[guideType]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[issue]    Script Date: 6/26/2017 11:27:15 AM ******/
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
/****** Object:  Table [dbo].[questionType]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[questionType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[questionType]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[quizAnswer]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quizAnswer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[quizQuestionId] [bigint] NOT NULL,
	[answer] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[quizQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quizQuestion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[questionTypeId] [bigint] NOT NULL,
	[question] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[region]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[region](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[region]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[review]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[review](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](1024) NOT NULL,
	[url] [nvarchar](max) NOT NULL,
	[issueId] [bigint] NOT NULL,
	[reviewerId] [bigint] NOT NULL,
	[abstract] [nvarchar](max) NOT NULL,
	[summary] [nvarchar](max) NOT NULL,
	[guideTypeId] [bigint] NOT NULL,
	[reviewStatusId] [bigint] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[createdByUserId] [nvarchar](450) NOT NULL,
	[lastUpdated] [datetime] NOT NULL,
	[updatedByUserId] [nvarchar](450) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewActivity]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewActivity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[activity] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewCompetency]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewCompetency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[competencyId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_reviewId_competencyId]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_reviewId_competencyId] ON [dbo].[reviewCompetency]
(
	[reviewId] ASC,
	[competencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewer]    Script Date: 6/26/2017 11:27:15 AM ******/
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
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_lastName_firstName_middleInitial]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_lastName_firstName_middleInitial] ON [dbo].[reviewer]
(
	[lastName] ASC,
	[firstName] ASC,
	[middleInitial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewKeyLearningPoint]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewKeyLearningPoint](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[keyLearningPoint] [nvarchar](max) NOT NULL,
	[ordinal] [bigint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewRegion]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewRegion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[regionId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_reviewId_regionId]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_reviewId_regionId] ON [dbo].[reviewRegion]
(
	[reviewId] ASC,
	[regionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewSector]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewSector](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[sectorId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_reviewId_sectorId]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_reviewId_sectorId] ON [dbo].[reviewSector]
(
	[reviewId] ASC,
	[sectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewStatus]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewStatus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](25) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[reviewStatus]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reviewSubTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reviewSubTopic](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[reviewId] [bigint] NOT NULL,
	[subTopicId] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Index [IX_reviewId_subTopicId]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_reviewId_subTopicId] ON [dbo].[reviewSubTopic]
(
	[reviewId] ASC,
	[subTopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roleClaims]    Script Date: 6/26/2017 11:27:15 AM ******/
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
/****** Object:  Table [dbo].[roles]    Script Date: 6/26/2017 11:27:15 AM ******/
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
/****** Object:  Table [dbo].[sector]    Script Date: 6/26/2017 11:27:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sector](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[sector]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
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
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_name]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE UNIQUE CLUSTERED INDEX [IX_name] ON [dbo].[subTopic]
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userClaims]    Script Date: 6/26/2017 11:27:15 AM ******/
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
/****** Object:  Table [dbo].[userLogins]    Script Date: 6/26/2017 11:27:15 AM ******/
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
/****** Object:  Table [dbo].[userRoles]    Script Date: 6/26/2017 11:27:15 AM ******/
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
/****** Object:  Table [dbo].[users]    Script Date: 6/26/2017 11:27:15 AM ******/
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
SET IDENTITY_INSERT [dbo].[guideType] ON 

INSERT [dbo].[guideType] ([Id], [name]) VALUES (1, N'Instructor Guide')
INSERT [dbo].[guideType] ([Id], [name]) VALUES (2, N'EDGE Guide')
SET IDENTITY_INSERT [dbo].[guideType] OFF
SET IDENTITY_INSERT [dbo].[sector] ON 

INSERT [dbo].[sector] ([Id], [name]) VALUES (1, N'test')
SET IDENTITY_INSERT [dbo].[sector] OFF
INSERT [dbo].[users] ([Id], [accessFailedCount], [concurrencyStamp], [email], [emailConfirmed], [lockoutEnabled], [lockoutEnd], [normalizedEmail], [normalizedUserName], [passwordHash], [phoneNumber], [phoneNumberConfirmed], [securityStamp], [twoFactorEnabled], [userName], [lastName], [firstName], [middleName], [title], [isEnabled], [dateCreated], [lastUpdated]) VALUES (N'e1ad7552-9398-496b-8233-bc1d1cb68d30', 0, N'5db951ec-3f1e-4e4f-b033-db0e3b160fb2', N'admin@peregrineacademics.com', 0, 1, NULL, N'ADMIN@PEREGRINEACADEMICS.COM', N'ADMIN@PEREGRINEACADEMICS.COM', N'AQAAAAEAACcQAAAAEEOJ5SPw2tZET+BUPtLeeIHtyDsezG9DI9qC6dsnGJFLVqydF/eZUl5xnajj7Ko4+Q==', NULL, 0, N'6357c65f-3a05-4490-bfa6-4315c8530259', 0, N'admin@peregrineacademics.com', N'Administrator', N'PAS', N'', N'', 1, CAST(N'2017-04-17T09:52:30.2864399' AS DateTime2), CAST(N'2017-04-17T09:52:30.2869419' AS DateTime2))
INSERT [dbo].[users] ([Id], [accessFailedCount], [concurrencyStamp], [email], [emailConfirmed], [lockoutEnabled], [lockoutEnd], [normalizedEmail], [normalizedUserName], [passwordHash], [phoneNumber], [phoneNumberConfirmed], [securityStamp], [twoFactorEnabled], [userName], [lastName], [firstName], [middleName], [title], [isEnabled], [dateCreated], [lastUpdated]) VALUES (N'f3992f9a-1e52-4573-a808-32b2399cb789', 0, N'7aa1c2df-3dba-4694-8cb4-3b5596db5b16', N'demo@peregrineacademics.com', 0, 1, NULL, N'DEMO@PEREGRINEACADEMICS.COM', N'DEMO@PEREGRINEACADEMICS.COM', N'AQAAAAEAACcQAAAAEGPrQhRFlA2Wdu/GkKL4KNa36Xpe7VV6XfHlciq24XjiZKz5X7xgZFq8BQLdYhiOhg==', NULL, 0, N'f3bce868-1c0b-4902-8f68-d73aff8d8b57', 0, N'demo@peregrineacademics.com', N'Administrator', N'PAS', N'', N'', 1, CAST(N'2017-04-10T09:43:08.5557743' AS DateTime2), CAST(N'2017-04-10T09:43:08.5567744' AS DateTime2))
/****** Object:  Index [PK_competency]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[competency] ADD  CONSTRAINT [PK_competency] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_discipline]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[discipline] ADD  CONSTRAINT [PK_discipline] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_discussionQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[discussionQuestion] ADD  CONSTRAINT [PK_discussionQuestion] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_guide]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[guideType] ADD  CONSTRAINT [PK_guide] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_issue]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[issue] ADD  CONSTRAINT [PK_issue] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_question]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[questionType] ADD  CONSTRAINT [PK_question] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_quizAnswer]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[quizAnswer] ADD  CONSTRAINT [PK_quizAnswer] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_quizQuestion]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[quizQuestion] ADD  CONSTRAINT [PK_quizQuestion] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_region]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[region] ADD  CONSTRAINT [PK_region] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_review]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[review] ADD  CONSTRAINT [PK_review] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewActivity]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewActivity] ADD  CONSTRAINT [PK_reviewActivity] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewCompetency]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewCompetency] ADD  CONSTRAINT [PK_reviewCompetency] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewer]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewer] ADD  CONSTRAINT [PK_reviewer] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_keyLearningPoint]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewKeyLearningPoint] ADD  CONSTRAINT [PK_keyLearningPoint] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewRegion]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewRegion] ADD  CONSTRAINT [PK_reviewRegion] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewSector]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewSector] ADD  CONSTRAINT [PK_reviewSector] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewStatus]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewStatus] ADD  CONSTRAINT [PK_reviewStatus] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_reviewSubTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[reviewSubTopic] ADD  CONSTRAINT [PK_reviewSubTopic] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[roles]
(
	[normalizedName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_sector]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[sector] ADD  CONSTRAINT [PK_sector] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_subTopic]    Script Date: 6/26/2017 11:27:15 AM ******/
ALTER TABLE [dbo].[subTopic] ADD  CONSTRAINT [PK_subTopic] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[users]
(
	[normalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 6/26/2017 11:27:15 AM ******/
CREATE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[users]
(
	[normalizedUserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[discussionQuestion]  WITH CHECK ADD  CONSTRAINT [FK_discussionQuestion_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[discussionQuestion] CHECK CONSTRAINT [FK_discussionQuestion_review]
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
ALTER TABLE [dbo].[quizAnswer]  WITH CHECK ADD  CONSTRAINT [FK_quizAnswer_quizQuestion] FOREIGN KEY([quizQuestionId])
REFERENCES [dbo].[quizQuestion] ([Id])
GO
ALTER TABLE [dbo].[quizAnswer] CHECK CONSTRAINT [FK_quizAnswer_quizQuestion]
GO
ALTER TABLE [dbo].[quizQuestion]  WITH CHECK ADD  CONSTRAINT [FK_quizQuestion_questionType] FOREIGN KEY([questionTypeId])
REFERENCES [dbo].[questionType] ([Id])
GO
ALTER TABLE [dbo].[quizQuestion] CHECK CONSTRAINT [FK_quizQuestion_questionType]
GO
ALTER TABLE [dbo].[quizQuestion]  WITH CHECK ADD  CONSTRAINT [FK_quizQuestion_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[quizQuestion] CHECK CONSTRAINT [FK_quizQuestion_review]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_guideType] FOREIGN KEY([guideTypeId])
REFERENCES [dbo].[guideType] ([Id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_review_guideType]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_issue] FOREIGN KEY([issueId])
REFERENCES [dbo].[issue] ([Id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_review_issue]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_reviewer] FOREIGN KEY([reviewerId])
REFERENCES [dbo].[reviewer] ([Id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_review_reviewer]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_reviewStatus] FOREIGN KEY([reviewStatusId])
REFERENCES [dbo].[reviewStatus] ([Id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_review_reviewStatus]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_usersCreated] FOREIGN KEY([createdByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_review_usersCreated]
GO
ALTER TABLE [dbo].[review]  WITH CHECK ADD  CONSTRAINT [FK_review_usersUpdated] FOREIGN KEY([updatedByUserId])
REFERENCES [dbo].[users] ([Id])
GO
ALTER TABLE [dbo].[review] CHECK CONSTRAINT [FK_review_usersUpdated]
GO
ALTER TABLE [dbo].[reviewActivity]  WITH CHECK ADD  CONSTRAINT [FK_reviewActivity_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[reviewActivity] CHECK CONSTRAINT [FK_reviewActivity_review]
GO
ALTER TABLE [dbo].[reviewCompetency]  WITH CHECK ADD  CONSTRAINT [FK_reviewCompetency_competency] FOREIGN KEY([competencyId])
REFERENCES [dbo].[competency] ([Id])
GO
ALTER TABLE [dbo].[reviewCompetency] CHECK CONSTRAINT [FK_reviewCompetency_competency]
GO
ALTER TABLE [dbo].[reviewCompetency]  WITH CHECK ADD  CONSTRAINT [FK_reviewCompetency_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[reviewCompetency] CHECK CONSTRAINT [FK_reviewCompetency_review]
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
ALTER TABLE [dbo].[reviewKeyLearningPoint]  WITH CHECK ADD  CONSTRAINT [FK_reviewKeyLearningPoint_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[reviewKeyLearningPoint] CHECK CONSTRAINT [FK_reviewKeyLearningPoint_review]
GO
ALTER TABLE [dbo].[reviewRegion]  WITH CHECK ADD  CONSTRAINT [FK_reviewRegion_region] FOREIGN KEY([regionId])
REFERENCES [dbo].[region] ([Id])
GO
ALTER TABLE [dbo].[reviewRegion] CHECK CONSTRAINT [FK_reviewRegion_region]
GO
ALTER TABLE [dbo].[reviewRegion]  WITH CHECK ADD  CONSTRAINT [FK_reviewRegion_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[reviewRegion] CHECK CONSTRAINT [FK_reviewRegion_review]
GO
ALTER TABLE [dbo].[reviewSector]  WITH CHECK ADD  CONSTRAINT [FK_reviewSector_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[reviewSector] CHECK CONSTRAINT [FK_reviewSector_review]
GO
ALTER TABLE [dbo].[reviewSector]  WITH CHECK ADD  CONSTRAINT [FK_reviewSector_sector] FOREIGN KEY([sectorId])
REFERENCES [dbo].[sector] ([Id])
GO
ALTER TABLE [dbo].[reviewSector] CHECK CONSTRAINT [FK_reviewSector_sector]
GO
ALTER TABLE [dbo].[reviewSubTopic]  WITH CHECK ADD  CONSTRAINT [FK_reviewSubTopic_review] FOREIGN KEY([reviewId])
REFERENCES [dbo].[review] ([Id])
GO
ALTER TABLE [dbo].[reviewSubTopic] CHECK CONSTRAINT [FK_reviewSubTopic_review]
GO
ALTER TABLE [dbo].[reviewSubTopic]  WITH CHECK ADD  CONSTRAINT [FK_reviewSubTopic_subTopic] FOREIGN KEY([subTopicId])
REFERENCES [dbo].[subTopic] ([Id])
GO
ALTER TABLE [dbo].[reviewSubTopic] CHECK CONSTRAINT [FK_reviewSubTopic_subTopic]
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
