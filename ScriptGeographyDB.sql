USE [GeographyDB]
GO
/****** Object:  Table [dbo].[BA_DETALLE_DEPOSITO]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BA_DETALLE_DEPOSITO](
	[ID_DETALLE_DEPOSITO] [int] IDENTITY(1,1) NOT NULL,
	[COD_EMPRESA] [varchar](5) NOT NULL,
	[ID_CUENTA] [numeric](8, 0) NOT NULL,
	[NUM_SECUENCIA] [numeric](8, 0) NOT NULL,
	[TIP_TRANSACCION] [varchar](5) NOT NULL,
	[NUM_DETALLE] [numeric](3, 0) NOT NULL,
	[TIP_EMISOR] [varchar](1) NOT NULL,
	[COD_EMISOR] [varchar](5) NOT NULL,
	[TIP_DOCUMENTO] [varchar](2) NOT NULL,
	[NUMCTA_EXTERNA] [varchar](15) NOT NULL,
	[NUM_DOCUMENTO] [numeric](10, 0) NOT NULL,
	[MON_DOCUMENTO] [numeric](15, 2) NOT NULL,
	[IND_ESTADO] [varchar](1) NOT NULL,
 CONSTRAINT [PK_BA_DETALLE_DEPOSITO] PRIMARY KEY CLUSTERED 
(
	[ID_DETALLE_DEPOSITO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BA_DETALLE_ESTADO_CUENTA]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BA_DETALLE_ESTADO_CUENTA](
	[ID_DETALLE_ESTADO_CUENTA] [int] IDENTITY(1,1) NOT NULL,
	[COD_EMPRESA] [varchar](5) NOT NULL,
	[ID_CUENTA] [numeric](8, 0) NOT NULL,
	[NUM_SECUENCIA] [numeric](8, 0) NOT NULL,
	[COD_TRANSACCION] [varchar](5) NOT NULL,
	[NUM_DOCUMENTO] [varchar](20) NOT NULL,
	[FEC_TRANSACCION] [datetime] NULL,
	[MON_DOCUMENTO] [decimal](15, 2) NULL,
	[OBSERVACIONES] [varchar](255) NULL,
	[IND_ESTADO] [char](1) NULL,
 CONSTRAINT [PK_BA_DETALLE_ESTADO_CUENTA] PRIMARY KEY CLUSTERED 
(
	[ID_DETALLE_ESTADO_CUENTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BA_ESTADO_CUENTA]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BA_ESTADO_CUENTA](
	[ID_ESTADO_CUENTA] [int] IDENTITY(1,1) NOT NULL,
	[COD_EMPRESA] [varchar](5) NOT NULL,
	[ID_CUENTA] [numeric](8, 0) NOT NULL,
	[NUM_SECUENCIA] [numeric](8, 0) NOT NULL,
	[FEC_INICIO] [datetime] NULL,
	[FEC_FIN] [datetime] NULL,
	[SALDO_INI] [decimal](15, 2) NULL,
	[SALDO_FIN] [decimal](15, 2) NULL,
	[IND_ESTADO] [char](1) NULL,
	[IND_ESTADO_INF] [varchar](1) NULL,
 CONSTRAINT [PK_BA_ESTADO_CUENTA] PRIMARY KEY CLUSTERED 
(
	[ID_ESTADO_CUENTA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BA_SALDOS_DIARIOS]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BA_SALDOS_DIARIOS](
	[ID_SALDOS_DIARIOS] [int] IDENTITY(1,1) NOT NULL,
	[COD_EMPRESA] [varchar](5) NOT NULL,
	[ID_CUENTA] [numeric](8, 0) NOT NULL,
	[FEC_CIERRE] [datetime] NOT NULL,
	[SALDO_INI] [decimal](15, 2) NULL,
	[SALDO_ACT] [decimal](15, 2) NULL,
 CONSTRAINT [PK_BA_SALDOS_DIARIOS] PRIMARY KEY CLUSTERED 
(
	[ID_SALDOS_DIARIOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BA_TRAN_DIARIO]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BA_TRAN_DIARIO](
	[ID_TRAN_DIARIO] [int] IDENTITY(1,1) NOT NULL,
	[COD_EMPRESA] [varchar](5) NOT NULL,
	[ID_CUENTA] [numeric](8, 0) NOT NULL,
	[NUM_SECUENCIA] [numeric](8, 0) NOT NULL,
	[TIP_TRANSACCION] [varchar](5) NOT NULL,
	[SUBTIP_TRANSAC] [varchar](5) NULL,
	[FEC_TRANSACCION] [datetime] NULL,
	[COD_MONEDA] [varchar](5) NOT NULL,
	[COD_SISTEMA] [varchar](2) NOT NULL,
	[COD_CLIENTE] [varchar](15) NULL,
	[MON_MOVIMIENTO] [decimal](15, 2) NULL,
	[TIP_CAMBIO] [decimal](15, 2) NULL,
	[ASIENTO_CONTABLE] [numeric](10, 0) NULL,
	[BENEFICIARIO] [varchar](40) NULL,
	[IND_ESTADO] [char](1) NULL,
	[OBSERVACIONES] [varchar](255) NULL,
	[NUM_DOCUMENTO] [varchar](25) NULL,
	[IND_ENV_CAJAS] [varchar](1) NULL,
	[COD_CAJERO] [varchar](15) NULL,
	[CTA_EXTERNA] [varchar](15) NULL,
	[NUM_REFERENCIA] [varchar](30) NULL,
	[TransactionTime] [datetime] NULL,
 CONSTRAINT [PK_BA_TRAN_DIARIO] PRIMARY KEY CLUSTERED 
(
	[ID_TRAN_DIARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[IdCity] [int] NOT NULL,
	[IdCountry] [int] NULL,
	[CityName] [nvarchar](100) NULL,
	[FoundationYear] [int] NULL,
	[Population] [int] NULL,
	[Area] [decimal](18, 2) NULL,
	[Elevation] [int] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[IdCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[IdCountry] [int] NOT NULL,
	[CountryName] [nvarchar](100) NULL,
	[CountryCode] [char](2) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[IdCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatabaseLog]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatabaseLog](
	[DatabaseLogID] [int] IDENTITY(1,1) NOT NULL,
	[PostTime] [datetime] NOT NULL,
	[DatabaseUser] [sysname] NOT NULL,
	[Event] [sysname] NOT NULL,
	[Schema] [sysname] NULL,
	[Object] [sysname] NULL,
	[TSQL] [nvarchar](max) NOT NULL,
	[XmlEvent] [xml] NOT NULL,
 CONSTRAINT [PK_DatabaseLog_DatabaseLogID] PRIMARY KEY NONCLUSTERED 
(
	[DatabaseLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorTime] [datetime] NOT NULL,
	[UserName] [sysname] NOT NULL,
	[ErrorNumber] [int] NOT NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorProcedure] [nvarchar](126) NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_ErrorLog_ErrorLogID] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tBiometricsData]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tBiometricsData](
	[BiometricsDataID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientFileID] [bigint] NOT NULL,
	[BiometricsData] [varbinary](max) NOT NULL,
	[BiometricsHash] [nvarchar](max) NOT NULL,
	[BiometricsTypeID] [nchar](1) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedOn] [datetime2](7) NULL,
	[DeletedBy] [bigint] NULL,
 CONSTRAINT [PK_tBiometricsData] PRIMARY KEY CLUSTERED 
(
	[BiometricsDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tBiometricsTypes]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tBiometricsTypes](
	[BiometricsTypeID] [nchar](1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_tBiometricsTypes] PRIMARY KEY CLUSTERED 
(
	[BiometricsTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tOrganizations]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tOrganizations](
	[OrganizationID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[OrganizationTypeID] [bigint] NULL,
	[UsernamePolicyID] [bigint] NULL,
 CONSTRAINT [PK_tOrganizations] PRIMARY KEY CLUSTERED 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProfileCredentials]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProfileCredentials](
	[ProfileID] [bigint] NOT NULL,
	[CredentialsID] [bigint] NOT NULL,
 CONSTRAINT [PK_tProfileCredentials] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProfileHierarchy]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProfileHierarchy](
	[ProfileIDMaster] [bigint] NOT NULL,
	[ProfileIDSlave] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProfileRoles]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProfileRoles](
	[ProfileID] [bigint] NOT NULL,
	[RoleID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProfiles]    Script Date: 4/7/2020 10:06:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProfiles](
	[ProfileID] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonID] [bigint] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[IsAuthorized] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [bigint] NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedOn] [datetime2](7) NULL,
	[DeletedBy] [bigint] NULL,
	[ProfileDetails] [nvarchar](max) NULL,
 CONSTRAINT [PK_tProfiles] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProfileSessions]    Script Date: 4/7/2020 10:06:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProfileSessions](
	[ProfileID] [bigint] NOT NULL,
	[SessionID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProfileUnits]    Script Date: 4/7/2020 10:06:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProfileUnits](
	[ProfileID] [bigint] NOT NULL,
	[UnitID] [bigint] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([IdCountry])
REFERENCES [dbo].[Country] ([IdCountry])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
