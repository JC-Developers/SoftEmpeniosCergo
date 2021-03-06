USE [master]
GO
/****** Objeto:  Database [CasaEmpeños]    Fecha de la secuencia de comandos: 06/05/2008 17:13:41 ******/
CREATE DATABASE [CasaEmpeños1] ON  PRIMARY 
( NAME = N'CasaEmpeños1', FILENAME = N'c:\Archivos de programa\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\CasaEmpeños1.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CasaEmpeños1_log', FILENAME = N'c:\Archivos de programa\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\CasaEmpeños1_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'CasaEmpeños1', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CasaEmpeños1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CasaEmpeños1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET ARITHABORT OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CasaEmpeños1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CasaEmpeños1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CasaEmpeños1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CasaEmpeños1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CasaEmpeños1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CasaEmpeños1] SET  READ_WRITE 
GO
ALTER DATABASE [CasaEmpeños1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CasaEmpeños1] SET  MULTI_USER 
GO
ALTER DATABASE [CasaEmpeños1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CasaEmpeños1] SET DB_CHAINING OFF 

USE [CasaEmpeños1]
GO

/****** Objeto:  View [dbo].[vistaBuscarEmpenio]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaBuscarEmpenio]'))
DROP VIEW [dbo].[vistaBuscarEmpenio]
GO
/****** Objeto:  View [dbo].[vistaPrueba2]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaPrueba2]'))
DROP VIEW [dbo].[vistaPrueba2]
GO
/****** Objeto:  View [dbo].[VistaEncabezadoTicket]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VistaEncabezadoTicket]'))
DROP VIEW [dbo].[VistaEncabezadoTicket]
GO
/****** Objeto:  View [dbo].[vistaprueba]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaprueba]'))
DROP VIEW [dbo].[vistaprueba]
GO
/****** Objeto:  View [dbo].[vistaBoletasClienteAtrasado]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaBoletasClienteAtrasado]'))
DROP VIEW [dbo].[vistaBoletasClienteAtrasado]
GO
/****** Objeto:  View [dbo].[VistaBoletasAtrasadas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VistaBoletasAtrasadas]'))
DROP VIEW [dbo].[VistaBoletasAtrasadas]
GO
/****** Objeto:  View [dbo].[vistaBoletaCliente]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaBoletaCliente]'))
DROP VIEW [dbo].[vistaBoletaCliente]
GO
/****** Objeto:  View [dbo].[vistaVentaArticulo]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaVentaArticulo]'))
DROP VIEW [dbo].[vistaVentaArticulo]
GO
/****** Objeto:  View [dbo].[Vista_Bol_Cli_Usu]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_Bol_Cli_Usu]'))
DROP VIEW [dbo].[Vista_Bol_Cli_Usu]
GO
/****** Objeto:  View [dbo].[Vista_VentasReporte]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_VentasReporte]'))
DROP VIEW [dbo].[Vista_VentasReporte]
GO
/****** Objeto:  View [dbo].[Vista_PagosReporte]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_PagosReporte]'))
DROP VIEW [dbo].[Vista_PagosReporte]
GO
/****** Objeto:  View [dbo].[Vista_Desempeños]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_Desempeños]'))
DROP VIEW [dbo].[Vista_Desempeños]
GO
/****** Objeto:  View [dbo].[Vista_Pagos_Intereses]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_Pagos_Intereses]'))
DROP VIEW [dbo].[Vista_Pagos_Intereses]
GO
/****** Objeto:  View [dbo].[vistaPagosdeEmpenios]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaPagosdeEmpenios]'))
DROP VIEW [dbo].[vistaPagosdeEmpenios]
GO
/****** Objeto:  View [dbo].[VistaCompras]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VistaCompras]'))
DROP VIEW [dbo].[VistaCompras]
GO
/****** Objeto:  Table [dbo].[PagosVentas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PagosVentas]') AND type in (N'U'))
DROP TABLE [dbo].[PagosVentas]
GO
/****** Objeto:  Table [dbo].[Desempeños]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Desempeños]') AND type in (N'U'))
DROP TABLE [dbo].[Desempeños]
GO
/****** Objeto:  Table [dbo].[PagosInteres]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PagosInteres]') AND type in (N'U'))
DROP TABLE [dbo].[PagosInteres]
GO
/****** Objeto:  Table [dbo].[Caja]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Caja]') AND type in (N'U'))
DROP TABLE [dbo].[Caja]
GO
/****** Objeto:  Table [dbo].[Compras]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Compras]') AND type in (N'U'))
DROP TABLE [dbo].[Compras]
GO
/****** Objeto:  Table [dbo].[Transacciones]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transacciones]') AND type in (N'U'))
DROP TABLE [dbo].[Transacciones]
GO
/****** Objeto:  Table [dbo].[Configuracion]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Configuracion]') AND type in (N'U'))
DROP TABLE [dbo].[Configuracion]
GO
/****** Objeto:  Table [dbo].[Boletas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Boletas]') AND type in (N'U'))
DROP TABLE [dbo].[Boletas]
GO
/****** Objeto:  Table [dbo].[Clientes]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
DROP TABLE [dbo].[Clientes]
GO
/****** Objeto:  Table [dbo].[Ventas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ventas]') AND type in (N'U'))
DROP TABLE [dbo].[Ventas]
GO
/****** Objeto:  Table [dbo].[Usuarios]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[Usuarios]
GO
/****** Objeto:  Table [dbo].[Usuarios]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[CveUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Usuario] [nchar](10) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[contraseña] [nchar](10) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Permisos] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[CveUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[Ventas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ventas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ventas](
	[cveventa] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](100) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[cveArticulo] [int] NOT NULL,
	[fechaVenta] [datetime] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[enganche] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 0) NOT NULL,
	[tipoVenta] [nchar](10) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[estado] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[cvevendedor] [int] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[cveventa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[Clientes]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clientes](
	[CveCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[NumIFE] [varchar](20) COLLATE Modern_Spanish_CI_AS NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[CveCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[Boletas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Boletas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Boletas](
	[Folio] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[FechaPrestamo] [datetime] NOT NULL,
	[Articulos] [varchar](250) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Prestamo] [decimal](18, 2) NOT NULL,
	[PesoEmpeño] [decimal](18, 2) NULL,
	[TipoEmpeño] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Interes] [decimal](18, 2) NOT NULL,
	[Pagado] [bit] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[CveUsuario] [int] NOT NULL,
	[EstadoBoleta] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_Boletas] PRIMARY KEY CLUSTERED 
(
	[Folio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Boletas', N'COLUMN',N'EstadoBoleta'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'este campo es el que sera para que se pusiera si esta pagado,fundido,' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Boletas', @level2type=N'COLUMN',@level2name=N'EstadoBoleta'
GO
/****** Objeto:  Table [dbo].[Configuracion]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Configuracion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Configuracion](
	[IdConfiguracion] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpresa] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[RazonSocial] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[RFC] [varchar](50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[CURP] [varchar](50) COLLATE Modern_Spanish_CI_AS NULL,
	[Direccion] [varchar](250) COLLATE Modern_Spanish_CI_AS NULL,
	[CodigoPostal] [nchar](5) COLLATE Modern_Spanish_CI_AS NULL,
	[Municipio] [nchar](15) COLLATE Modern_Spanish_CI_AS NULL,
	[PorcentajeInteres] [decimal](18, 0) NOT NULL,
	[Proroga] [int] NULL,
	[PrecioCompraDolar] [decimal](18, 0) NOT NULL,
	[PrecioCompraPlata] [decimal](18, 0) NOT NULL,
	[PrecioOro10kamarillo] [decimal](18, 0) NOT NULL,
	[PrecioOro10krojo] [decimal](18, 0) NOT NULL,
	[PrecioOro14k] [decimal](18, 0) NOT NULL,
	[PrecioOro18K] [decimal](18, 0) NOT NULL,
	[PrecioOro22k] [decimal](18, 0) NOT NULL,
	[PrecioOro24k] [decimal](18, 0) NOT NULL,
	[FechaUltimaModificacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Configuracion] PRIMARY KEY CLUSTERED 
(
	[IdConfiguracion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[Transacciones]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transacciones]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transacciones](
	[IDTransaccion] [int] IDENTITY(1,1) NOT NULL,
	[TipoTransaccion] [nchar](10) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[Cantidad] [decimal](18, 0) NOT NULL,
	[FechaTransaccion] [datetime] NOT NULL,
 CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED 
(
	[IDTransaccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[Compras]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Compras]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Compras](
	[CveCompra] [int] IDENTITY(1,1) NOT NULL,
	[PesoCantidad] [decimal](18, 2) NOT NULL,
	[PrecioCompra] [decimal](18, 2) NOT NULL,
	[CveUsuario] [int] NOT NULL,
	[TipodeCompra] [nvarchar](15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[TotalCompra] [decimal](18, 0) NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[CveCompra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[Caja]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Caja]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Caja](
	[IDCaja] [int] IDENTITY(1,1) NOT NULL,
	[CajaInicial] [decimal](18, 0) NOT NULL,
	[CajeroCerro] [int] NOT NULL,
	[CajeroAbrio] [int] NOT NULL,
	[FechaCajaAbierto] [datetime] NOT NULL,
	[FechaCajaCierre] [datetime] NOT NULL,
	[Desempenios] [decimal](18, 0) NOT NULL,
	[InteresCobrados] [decimal](18, 0) NOT NULL,
	[TotalEmpenios] [decimal](18, 0) NOT NULL,
	[TotalDepositos] [decimal](18, 0) NOT NULL,
	[TotalRetiros] [decimal](18, 0) NOT NULL,
	[TotalAbonos] [decimal](18, 0) NOT NULL,
	[CajaFinal] [decimal](18, 0) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[IDCaja] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[PagosInteres]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PagosInteres]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PagosInteres](
	[CvePago] [int] IDENTITY(1,1) NOT NULL,
	[FolioBoleta] [int] NOT NULL,
	[NumPago] [int] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[Interes] [decimal](18, 2) NOT NULL,
	[Recargos] [decimal](18, 2) NOT NULL,
	[DiasRecargo] [int] NOT NULL,
	[RecargoXDia] [decimal](18, 2) NOT NULL,
	[TotalPagar] [decimal](18, 2) NOT NULL,
	[CveUsuario] [int] NOT NULL,
 CONSTRAINT [PK_PagosInteres] PRIMARY KEY CLUSTERED 
(
	[CvePago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[Desempeños]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Desempeños]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Desempeños](
	[cveDesempeño] [int] IDENTITY(1,1) NOT NULL,
	[FolioBoleta] [int] NOT NULL,
	[Interes] [decimal](18, 2) NOT NULL,
	[Recargos] [decimal](18, 2) NOT NULL,
	[DiasRecargo] [decimal](18, 2) NOT NULL,
	[recargoXDia] [decimal](18, 2) NOT NULL,
	[TotalPagar] [decimal](18, 2) NOT NULL,
	[FechaDesempeño] [datetime] NOT NULL,
	[Observaciones] [varchar](250) COLLATE Modern_Spanish_CI_AS NULL,
	[cveUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Desempeños] PRIMARY KEY CLUSTERED 
(
	[cveDesempeño] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  Table [dbo].[PagosVentas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PagosVentas]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PagosVentas](
	[cvepago] [int] IDENTITY(1,1) NOT NULL,
	[cveventa] [int] NOT NULL,
	[abono] [decimal](18, 2) NOT NULL,
	[saldo] [decimal](18, 0) NOT NULL,
	[fechapago] [datetime] NOT NULL,
	[observaciones] [varchar](250) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[cveusuario] [int] NOT NULL,
 CONSTRAINT [PK_PagosVentas] PRIMARY KEY CLUSTERED 
(
	[cvepago] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Objeto:  View [dbo].[VistaCompras]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VistaCompras]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VistaCompras]
AS
SELECT     dbo.Usuarios.Nombre, dbo.Compras.CveCompra, dbo.Compras.PesoCantidad, dbo.Compras.PrecioCompra, dbo.Compras.TotalCompra, dbo.Compras.TipodeCompra, 
                      dbo.Compras.FechaCompra
FROM         dbo.Compras INNER JOIN
                      dbo.Usuarios ON dbo.Compras.CveUsuario = dbo.Usuarios.CveUsuario
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VistaCompras', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[43] 4[31] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -1248
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Compras"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 189
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 178
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaCompras'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VistaCompras', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaCompras'
GO
/****** Objeto:  View [dbo].[vistaPagosdeEmpenios]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaPagosdeEmpenios]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vistaPagosdeEmpenios]
AS
SELECT     dbo.PagosInteres.NumPago AS [Pago Numero], dbo.PagosInteres.FechaPago AS [Fecha de Pago], dbo.PagosInteres.Recargos, 
                      dbo.PagosInteres.DiasRecargo AS [Dias de Recargo], dbo.PagosInteres.RecargoXDia AS [Recargos por dia], dbo.PagosInteres.TotalPagar AS [Total a Pagado], 
                      dbo.Usuarios.Nombre AS [Registro pago], dbo.Boletas.Folio, dbo.PagosInteres.Interes
FROM         dbo.Boletas INNER JOIN
                      dbo.Usuarios ON dbo.Boletas.CveUsuario = dbo.Usuarios.CveUsuario INNER JOIN
                      dbo.PagosInteres ON dbo.Boletas.Folio = dbo.PagosInteres.FolioBoleta AND dbo.Usuarios.CveUsuario = dbo.PagosInteres.CveUsuario
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vistaPagosdeEmpenios', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 125
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PagosInteres"
            Begin Extent = 
               Top = 6
               Left = 510
               Bottom = 207
               Right = 708
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaPagosdeEmpenios'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vistaPagosdeEmpenios', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaPagosdeEmpenios'
GO
/****** Objeto:  View [dbo].[Vista_Pagos_Intereses]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_Pagos_Intereses]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Vista_Pagos_Intereses]
AS
SELECT     dbo.PagosInteres.CvePago, dbo.PagosInteres.FechaPago, dbo.PagosInteres.Interes, dbo.PagosInteres.Recargos, dbo.PagosInteres.DiasRecargo, 
                      dbo.PagosInteres.RecargoXDia, dbo.PagosInteres.TotalPagar, dbo.Usuarios.Nombre, dbo.Boletas.Cliente, dbo.Boletas.Articulos, dbo.PagosInteres.FolioBoleta, 
                      dbo.Boletas.Prestamo, dbo.Boletas.FechaPrestamo, dbo.Usuarios.CveUsuario
FROM         dbo.PagosInteres LEFT OUTER JOIN
                      dbo.Usuarios ON dbo.PagosInteres.CveUsuario = dbo.Usuarios.CveUsuario LEFT OUTER JOIN
                      dbo.Boletas ON dbo.PagosInteres.FolioBoleta = dbo.Boletas.Folio
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_Pagos_Intereses', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[15] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PagosInteres"
            Begin Extent = 
               Top = 24
               Left = 258
               Bottom = 258
               Right = 456
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 34
               Left = 4
               Bottom = 281
               Right = 202
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 6
               Left = 510
               Bottom = 256
               Right = 708
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Pagos_Intereses'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_Pagos_Intereses', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Pagos_Intereses'
GO
/****** Objeto:  View [dbo].[Vista_Desempeños]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_Desempeños]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Vista_Desempeños]
AS
SELECT     dbo.Desempeños.cveDesempeño, dbo.Desempeños.FolioBoleta, dbo.Boletas.Cliente, dbo.Boletas.Articulos, dbo.Desempeños.Interes, dbo.Boletas.Prestamo, 
                      dbo.Desempeños.Recargos, dbo.Desempeños.DiasRecargo, dbo.Desempeños.recargoXDia, dbo.Desempeños.TotalPagar, dbo.Desempeños.FechaDesempeño, 
                      dbo.Usuarios.Nombre AS Cajero, dbo.Boletas.FechaPrestamo AS FechaEmpeño
FROM         dbo.Boletas INNER JOIN
                      dbo.Desempeños ON dbo.Boletas.Folio = dbo.Desempeños.FolioBoleta INNER JOIN
                      dbo.Usuarios ON dbo.Desempeños.cveUsuario = dbo.Usuarios.CveUsuario
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_Desempeños', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[15] 2[29] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 235
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Desempeños"
            Begin Extent = 
               Top = 6
               Left = 494
               Bottom = 201
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 61
               Left = 726
               Bottom = 236
               Right = 916
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Desempeños'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_Desempeños', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Desempeños'
GO
/****** Objeto:  View [dbo].[Vista_PagosReporte]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_PagosReporte]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Vista_PagosReporte]
AS
SELECT     dbo.PagosVentas.cvepago, dbo.PagosVentas.cveventa, dbo.Ventas.Cliente, dbo.PagosVentas.abono, dbo.PagosVentas.saldo, 
                      dbo.PagosVentas.fechapago, dbo.Usuarios.Nombre AS Cajero, dbo.Articulos.Precio, dbo.Articulos.Descripcion AS Articulo
FROM         dbo.PagosVentas INNER JOIN
                      dbo.Usuarios ON dbo.PagosVentas.cveusuario = dbo.Usuarios.CveUsuario INNER JOIN
                      dbo.Ventas ON dbo.PagosVentas.cveventa = dbo.Ventas.cveventa INNER JOIN
                      dbo.Articulos ON dbo.Ventas.cveArticulo = dbo.Articulos.Cvearticulo
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_PagosReporte', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[8] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PagosVentas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 163
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 113
               Left = 281
               Bottom = 221
               Right = 471
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ventas"
            Begin Extent = 
               Top = 31
               Left = 560
               Bottom = 228
               Right = 750
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Articulos"
            Begin Extent = 
               Top = 168
               Left = 38
               Bottom = 276
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_PagosReporte'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_PagosReporte', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_PagosReporte'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_PagosReporte', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_PagosReporte'
GO
/****** Objeto:  View [dbo].[Vista_VentasReporte]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_VentasReporte]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Vista_VentasReporte] AS SELECT     dbo.Ventas.cveventa, dbo.Ventas.Cliente, dbo.Articulos.Descripcion, dbo.Ventas.fechaVenta, dbo.Ventas.Saldo, dbo.Ventas.enganche, dbo.Ventas.Precio, dbo.Ventas.tipoVenta, dbo.Ventas.estado, dbo.Usuarios.Nombre AS Cajero FROM         dbo.Articulos INNER JOIN dbo.Ventas ON dbo.Articulos.Cvearticulo = dbo.Ventas.cveArticulo INNER JOIN dbo.Usuarios ON dbo.Ventas.cvevendedor = dbo.Usuarios.CveUsuario 
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_VentasReporte', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Articulos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ventas"
            Begin Extent = 
               Top = 6
               Left = 306
               Bottom = 213
               Right = 496
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 51
               Left = 586
               Bottom = 159
               Right = 776
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_VentasReporte'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_VentasReporte', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_VentasReporte'
GO
/****** Objeto:  View [dbo].[Vista_Bol_Cli_Usu]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Vista_Bol_Cli_Usu]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[Vista_Bol_Cli_Usu]
AS
SELECT     dbo.Boletas.Folio, dbo.Boletas.Cliente, dbo.Boletas.FechaPrestamo, dbo.Boletas.Articulos, dbo.Boletas.Prestamo, dbo.Boletas.PesoEmpeño, 
                      dbo.Boletas.TipoEmpeño, dbo.Usuarios.Nombre AS Vendedor
FROM         dbo.Boletas INNER JOIN
                      dbo.Usuarios ON dbo.Boletas.CveUsuario = dbo.Usuarios.CveUsuario
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_Bol_Cli_Usu', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[17] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 232
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 6
               Left = 494
               Bottom = 129
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Bol_Cli_Usu'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'Vista_Bol_Cli_Usu', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vista_Bol_Cli_Usu'
GO
/****** Objeto:  View [dbo].[vistaVentaArticulo]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaVentaArticulo]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vistaVentaArticulo] AS SELECT     dbo.Ventas.cveventa, dbo.Ventas.Cliente, dbo.Articulos.Descripcion, dbo.Ventas.fechaVenta, dbo.Ventas.Saldo, dbo.Ventas.enganche,  dbo.Ventas.Precio FROM         dbo.Articulos INNER JOIN dbo.Ventas ON dbo.Articulos.Cvearticulo = dbo.Ventas.cveArticulo WHERE     (dbo.Ventas.tipoVenta = ''Abonos'') AND (dbo.Ventas.estado = ''Credito'') 
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vistaVentaArticulo', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Articulos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 173
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ventas"
            Begin Extent = 
               Top = 6
               Left = 361
               Bottom = 168
               Right = 551
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaVentaArticulo'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vistaVentaArticulo', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaVentaArticulo'
GO
/****** Objeto:  View [dbo].[vistaBoletaCliente]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaBoletaCliente]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vistaBoletaCliente]
AS
SELECT     dbo.Boletas.Folio, dbo.Boletas.FechaPrestamo, dbo.Boletas.Articulos, dbo.Boletas.Prestamo, dbo.Boletas.PesoEmpeño, dbo.Boletas.Metal, 
                      dbo.Boletas.Interes, dbo.Boletas.Pagado, dbo.Boletas.FechaPago, dbo.Boletas.CveUsuario, dbo.Clientes.Nombre, dbo.Boletas.EstadoBoleta
FROM         dbo.Boletas INNER JOIN
                      dbo.Clientes ON dbo.Boletas.CveCliente = dbo.Clientes.CveCliente
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vistaBoletaCliente', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[48] 4[13] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 270
               Right = 333
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Clientes"
            Begin Extent = 
               Top = 21
               Left = 461
               Bottom = 121
               Right = 651
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaBoletaCliente'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vistaBoletaCliente', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaBoletaCliente'
GO
/****** Objeto:  View [dbo].[VistaBoletasAtrasadas]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VistaBoletasAtrasadas]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VistaBoletasAtrasadas]
AS
SELECT     Folio, Cliente, FechaPrestamo, Articulos, Prestamo, TipoEmpeño, PesoEmpeño,
                          (SELECT     ISNULL(MAX(FechaPago), dbo.Boletas.FechaPrestamo) AS Expr1
                            FROM          dbo.PagosInteres
                            WHERE      (FolioBoleta = dbo.Boletas.Folio)) AS FechaUltimoPago
FROM         dbo.Boletas
WHERE     (Pagado = ''false'') AND (EstadoBoleta = ''vigente'') AND (DATEDIFF(dd, ISNULL(DATEADD(mm,
                          (SELECT     MAX(NumPago) AS Expr1
                            FROM          dbo.PagosInteres AS PagosInteres_1
                            WHERE      (FolioBoleta = dbo.Boletas.Folio)), FechaPrestamo), FechaPrestamo), GETDATE()) > 61)
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VistaBoletasAtrasadas', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[11] 2[31] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -3234
      End
      Begin Tables = 
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 241
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2085
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaBoletasAtrasadas'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VistaBoletasAtrasadas', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaBoletasAtrasadas'
GO
/****** Objeto:  View [dbo].[vistaBoletasClienteAtrasado]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaBoletasClienteAtrasado]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vistaBoletasClienteAtrasado]
AS
SELECT     dbo.Boletas.Folio, dbo.Boletas.Cliente, dbo.Boletas.FechaPrestamo, dbo.Boletas.Articulos, dbo.Boletas.Prestamo, dbo.Boletas.PesoEmpeño, 
                      dbo.Boletas.TipoEmpeño, dbo.Boletas.EstadoBoleta, dbo.Boletas.Interes, ISNULL(MAX(dbo.PagosInteres.FechaPago), dbo.Boletas.FechaPrestamo) 
                      AS FechaUltimoPago, dbo.PagosInteres.NumPago
FROM         dbo.Boletas LEFT OUTER JOIN
                      dbo.PagosInteres ON dbo.Boletas.Folio = dbo.PagosInteres.FolioBoleta
WHERE     (dbo.Boletas.EstadoBoleta = ''Vigente'') OR
                      (dbo.Boletas.EstadoBoleta = ''Vencido'')
GROUP BY dbo.Boletas.Folio, dbo.Boletas.Cliente, dbo.Boletas.FechaPrestamo, dbo.Boletas.Articulos, dbo.Boletas.Prestamo, dbo.Boletas.PesoEmpeño, 
                      dbo.Boletas.TipoEmpeño, dbo.Boletas.EstadoBoleta, dbo.Boletas.Interes, dbo.PagosInteres.NumPago
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vistaBoletasClienteAtrasado', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[48] 4[7] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 169
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PagosInteres"
            Begin Extent = 
               Top = 109
               Left = 426
               Bottom = 217
               Right = 616
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaBoletasClienteAtrasado'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vistaBoletasClienteAtrasado', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaBoletasClienteAtrasado'
GO
/****** Objeto:  View [dbo].[vistaprueba]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaprueba]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vistaprueba]
AS
SELECT     Folio, Cliente, FechaPrestamo, Articulos, Prestamo, PesoEmpeño, TipoEmpeño, Interes, Pagado, FechaPago, CveUsuario, EstadoBoleta, DATEDIFF(mm, 
                      FechaPrestamo, GETDATE()) AS meses,
                          (SELECT     COUNT(NumPago) AS Expr1
                            FROM          dbo.PagosInteres
                            WHERE      (FolioBoleta = dbo.Boletas.Folio)) AS pagos
FROM         dbo.Boletas
WHERE     (Pagado = ''false'')
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vistaprueba', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[9] 2[25] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Boletas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 15
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaprueba'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vistaprueba', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaprueba'
GO
/****** Objeto:  View [dbo].[VistaEncabezadoTicket]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VistaEncabezadoTicket]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VistaEncabezadoTicket]
AS
SELECT     NombreEmpresa, RazonSocial, RFC, CURP, Direccion, Municipio, CodigoPostal
FROM         dbo.Configuracion
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VistaEncabezadoTicket', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[69] 4[3] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Configuracion"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 323
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaEncabezadoTicket'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VistaEncabezadoTicket', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaEncabezadoTicket'
GO
/****** Objeto:  View [dbo].[vistaPrueba2]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaPrueba2]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vistaPrueba2]
AS
SELECT     Folio, FechaPrestamo, Articulos, Prestamo, PesoEmpeño, TipoEmpeño, Interes, Pagado, FechaPago, EstadoBoleta, pagos, DATEADD(mm, pagos, FechaPrestamo) 
                      AS ultimafechapago, Cliente, meses
FROM         dbo.vistaprueba
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vistaPrueba2', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[12] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vistaprueba"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 272
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaPrueba2'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vistaPrueba2', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaPrueba2'
GO
/****** Objeto:  View [dbo].[vistaBuscarEmpenio]    Fecha de la secuencia de comandos: 10/24/2011 01:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vistaBuscarEmpenio]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vistaBuscarEmpenio]
AS
SELECT     Folio, Nombre AS Cliente, Articulos, Prestamo, Interes, FechaPrestamo AS [Fechas de Prestamo], FechaPago AS [Fecha de Pago], 
                      EstadoBoleta AS [Estado de Boleta]
FROM         dbo.vistaBoletaCliente
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vistaBuscarEmpenio', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vistaBoletaCliente"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaBuscarEmpenio'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vistaBuscarEmpenio', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaBuscarEmpenio'
GO
