USE [master]
GO
/****** Object:  Database [ProcessoSeletivo]    Script Date: 30/01/2014 00:07:55 ******/
CREATE DATABASE [ProcessoSeletivo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProcessoSeletivo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProcessoSeletivo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProcessoSeletivo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProcessoSeletivo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProcessoSeletivo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProcessoSeletivo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProcessoSeletivo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProcessoSeletivo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProcessoSeletivo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProcessoSeletivo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProcessoSeletivo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProcessoSeletivo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET RECOVERY FULL 
GO
ALTER DATABASE [ProcessoSeletivo] SET  MULTI_USER 
GO
ALTER DATABASE [ProcessoSeletivo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProcessoSeletivo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProcessoSeletivo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProcessoSeletivo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProcessoSeletivo', N'ON'
GO
USE [ProcessoSeletivo]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 30/01/2014 00:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [bigint] IDENTITY(1,1) NOT NULL,
	[DescricaoCategoria] [varchar](150) NOT NULL,
	[idCategoriaPai] [bigint] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 30/01/2014 00:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[idProduto] [bigint] IDENTITY(1,1) NOT NULL,
	[DescricaoProduto] [varchar](150) NOT NULL,
	[Preco] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[idProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProdutoCategoria]    Script Date: 30/01/2014 00:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoCategoria](
	[idProdCat] [bigint] NOT NULL,
	[idProduto] [bigint] NOT NULL,
	[idCategoria] [bigint] NOT NULL,
 CONSTRAINT [PK_ProdutoCategoria] PRIMARY KEY CLUSTERED 
(
	[idProdCat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProdutoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCategoria_Categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[ProdutoCategoria] CHECK CONSTRAINT [FK_ProdutoCategoria_Categoria]
GO
ALTER TABLE [dbo].[ProdutoCategoria]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCategoria_Produto] FOREIGN KEY([idProduto])
REFERENCES [dbo].[Produto] ([idProduto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProdutoCategoria] CHECK CONSTRAINT [FK_ProdutoCategoria_Produto]
GO
USE [master]
GO
ALTER DATABASE [ProcessoSeletivo] SET  READ_WRITE 
GO
