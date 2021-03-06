USE [master]
GO
/****** Object:  Database [prenotazioni-impostazioni]    Script Date: 20/07/2022 11:10:50 ******/
CREATE DATABASE [prenotazioni-impostazioni]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'prenotazioni-impostazioni', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\prenotazioni-impostazioni.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'prenotazioni-impostazioni_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\prenotazioni-impostazioni_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [prenotazioni-impostazioni] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [prenotazioni-impostazioni].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [prenotazioni-impostazioni] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET ARITHABORT OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET  DISABLE_BROKER 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET RECOVERY FULL 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET  MULTI_USER 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [prenotazioni-impostazioni] SET DB_CHAINING OFF 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [prenotazioni-impostazioni] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'prenotazioni-impostazioni', N'ON'
GO
ALTER DATABASE [prenotazioni-impostazioni] SET QUERY_STORE = OFF
GO
USE [prenotazioni-impostazioni]
GO
/****** Object:  Table [dbo].[Feste]    Script Date: 20/07/2022 11:10:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feste](
	[idFesta] [int] IDENTITY(1,1) NOT NULL,
	[giorno] [date] NOT NULL,
	[descrizione] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impostazioni]    Script Date: 20/07/2022 11:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impostazioni](
	[modEmergenza] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prenotazioni]    Script Date: 20/07/2022 11:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prenotazioni](
	[idPrenotazioni] [int] IDENTITY(1,1) NOT NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NOT NULL,
	[idStanza] [int] NOT NULL,
	[idUtente] [int] NOT NULL,
 CONSTRAINT [PK_prenotazioni] PRIMARY KEY CLUSTERED 
(
	[idPrenotazioni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ruoli]    Script Date: 20/07/2022 11:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruoli](
	[idRuolo] [int] NOT NULL,
	[descRuolo] [varchar](256) NULL,
	[accessoImpostazioni] [tinyint] NULL,
 CONSTRAINT [PK_RuoliTest] PRIMARY KEY CLUSTERED 
(
	[idRuolo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stanze]    Script Date: 20/07/2022 11:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stanze](
	[idStanza] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[postiMax] [int] NOT NULL,
	[postiMaxEmergenza] [int] NOT NULL,
 CONSTRAINT [PK_Stanze] PRIMARY KEY CLUSTERED 
(
	[idStanza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 20/07/2022 11:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[idUtente] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](24) NOT NULL,
	[cognome] [nvarchar](24) NOT NULL,
	[immagine] [image] NULL,
	[email] [nvarchar](64) NOT NULL,
	[idRuolo] [int] NOT NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[idUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voti]    Script Date: 20/07/2022 11:10:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voti](
	[idVoto] [int] IDENTITY(1,1) NOT NULL,
	[idUtente] [int] NOT NULL,
	[idUtenteVotato] [int] NOT NULL,
	[votoEffettuato] [bit] NOT NULL,
 CONSTRAINT [PK_Voti] PRIMARY KEY CLUSTERED 
(
	[idVoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Log] ( 
  [ID] [int] IDENTITY (1, 1) NOT NULL ,
  [Date] [datetime] NOT NULL ,
  [Thread] [varchar] (255) NOT NULL ,
  [Level] [varchar] (50) NOT NULL ,
  [Message] [varchar] (4000) NOT NULL 
) ON [PRIMARY]
GO
/****** Object:  Index [IX_prenotazioni]    Script Date: 20/07/2022 11:10:51 ******/
CREATE NONCLUSTERED INDEX [IX_prenotazioni] ON [dbo].[Prenotazioni]
(
	[idPrenotazioni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prenotazioni]  WITH CHECK ADD  CONSTRAINT [FK_Prenotazioni_Stanze] FOREIGN KEY([idStanza])
REFERENCES [dbo].[Stanze] ([idStanza])
GO
ALTER TABLE [dbo].[Prenotazioni] CHECK CONSTRAINT [FK_Prenotazioni_Stanze]
GO
ALTER TABLE [dbo].[Prenotazioni]  WITH CHECK ADD  CONSTRAINT [FK_Prenotazioni_Utenti] FOREIGN KEY([idUtente])
REFERENCES [dbo].[Utenti] ([idUtente])
GO
ALTER TABLE [dbo].[Prenotazioni] CHECK CONSTRAINT [FK_Prenotazioni_Utenti]
GO
ALTER TABLE [dbo].[Utenti]  WITH CHECK ADD  CONSTRAINT [FK_Utenti_Utenti] FOREIGN KEY([idRuolo])
REFERENCES [dbo].[Ruoli] ([idRuolo])
GO
ALTER TABLE [dbo].[Utenti] CHECK CONSTRAINT [FK_Utenti_Utenti]
GO
ALTER TABLE [dbo].[Voti]  WITH CHECK ADD  CONSTRAINT [FK_Voti_Utenti] FOREIGN KEY([idUtente])
REFERENCES [dbo].[Utenti] ([idUtente])
GO
ALTER TABLE [dbo].[Voti] CHECK CONSTRAINT [FK_Voti_Utenti]
GO
ALTER TABLE [dbo].[Voti]  WITH CHECK ADD  CONSTRAINT [FK_Voti_Utenti1] FOREIGN KEY([idUtenteVotato])
REFERENCES [dbo].[Utenti] ([idUtente])
GO
ALTER TABLE [dbo].[Voti] CHECK CONSTRAINT [FK_Voti_Utenti1]
GO
USE [master]
GO
ALTER DATABASE [prenotazioni-impostazioni] SET  READ_WRITE 
GO
