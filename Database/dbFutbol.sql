USE [master]
GO
/****** Object:  Database [FUTBOL]    Script Date: 08/12/2022 19:02:24 ******/
CREATE DATABASE [FUTBOL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FUTBOL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FUTBOL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FUTBOL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\FUTBOL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FUTBOL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FUTBOL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FUTBOL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FUTBOL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FUTBOL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FUTBOL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FUTBOL] SET ARITHABORT OFF 
GO
ALTER DATABASE [FUTBOL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FUTBOL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FUTBOL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FUTBOL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FUTBOL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FUTBOL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FUTBOL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FUTBOL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FUTBOL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FUTBOL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FUTBOL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FUTBOL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FUTBOL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FUTBOL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FUTBOL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FUTBOL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FUTBOL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FUTBOL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FUTBOL] SET  MULTI_USER 
GO
ALTER DATABASE [FUTBOL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FUTBOL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FUTBOL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FUTBOL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FUTBOL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FUTBOL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FUTBOL] SET QUERY_STORE = OFF
GO
USE [FUTBOL]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF;
GO
USE [FUTBOL]
GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 08/12/2022 19:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[logo] [varchar](200) NULL,
 CONSTRAINT [PK_Equipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugador]    Script Date: 08/12/2022 19:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Altura] [int] NULL,
	[Edad] [int] NULL,
	[FechaNacimiento] [date] NULL,
	[Foto] [varchar](300) NULL,
	[IdPosicion] [int] NULL,
	[IdEquipo] [int] NULL,
	[IdNacionalidad] [int] NULL,
	[IdTorneo] [int] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Jugador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nacionalidad]    Script Date: 08/12/2022 19:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nacionalidad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Nacionalidad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posicion]    Script Date: 08/12/2022 19:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posicion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Posicion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Torneo]    Script Date: 08/12/2022 19:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Torneo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Torneo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TorneoEquipo]    Script Date: 08/12/2022 19:02:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TorneoEquipo](
	[IdTorneo] [int] NOT NULL,
	[IdEquipo] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Equipo] ON 

INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (1, N'Huracán', N'https://upload.wikimedia.org/wikipedia/commons/0/0d/Escudo_de_Hurac%C3%A1n.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (2, N'Boca', N'https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/Escudo_del_Club_Atl%C3%A9tico_Boca_Juniors.svg/1774px-Escudo_del_Club_Atl%C3%A9tico_Boca_Juniors.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (3, N'River', N'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/CA_river_plate_logo.svg/1638px-CA_river_plate_logo.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (4, N'Newell''s Old Boys', N'https://upload.wikimedia.org/wikipedia/commons/thumb/6/69/Escudo_del_Club_Atl%C3%A9tico_Newell%27s_Old_Boys_de_Rosario.svg/1200px-Escudo_del_Club_Atl%C3%A9tico_Newell%27s_Old_Boys_de_Rosario.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (5, N'San Lorenzo', N'https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Escudo_del_C.A._San_Lorenzo_de_Almagro.svg/1200px-Escudo_del_C.A._San_Lorenzo_de_Almagro.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (6, N'Racing', N'https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Escudo_de_Racing_Club_%282014%29.svg/1200px-Escudo_de_Racing_Club_%282014%29.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (7, N'Independiente', N'https://upload.wikimedia.org/wikipedia/commons/thumb/d/db/Escudo_del_Club_Atl%C3%A9tico_Independiente.svg/1200px-Escudo_del_Club_Atl%C3%A9tico_Independiente.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (8, N'Estudiantes de la Plata', N'https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Escudo_del_Club_Estudiantes_de_La_Plata.svg/1200px-Escudo_del_Club_Estudiantes_de_La_Plata.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (9, N'Gimnasia y Esgrima de la Plata', N'https://upload.wikimedia.org/wikipedia/commons/thumb/3/3d/Escudo_del_Club_de_Gimnasia_y_Esgrima_La_Plata.svg/1200px-Escudo_del_Club_de_Gimnasia_y_Esgrima_La_Plata.svg.png')
INSERT [dbo].[Equipo] ([Id], [Nombre], [logo]) VALUES (10, N'Velez Sarsfield', N'https://upload.wikimedia.org/wikipedia/commons/thumb/2/21/Escudo_del_Club_Atl%C3%A9tico_V%C3%A9lez_Sarsfield.svg/1793px-Escudo_del_Club_Atl%C3%A9tico_V%C3%A9lez_Sarsfield.svg.png')
SET IDENTITY_INSERT [dbo].[Equipo] OFF
GO
SET IDENTITY_INSERT [dbo].[Jugador] ON 

INSERT [dbo].[Jugador] ([Id], [Nombre], [Apellido], [Altura], [Edad], [FechaNacimiento], [Foto], [IdPosicion], [IdEquipo], [IdNacionalidad], [IdTorneo], [Activo]) VALUES (2, N'Lionel Andres', N'Messi', 170, 35, CAST(N'2022-12-05' AS Date), N'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Lionel_Messi_20180626.jpg/245px-Lionel_Messi_20180626.jpg', 4, 4, 1, 1, 1)
INSERT [dbo].[Jugador] ([Id], [Nombre], [Apellido], [Altura], [Edad], [FechaNacimiento], [Foto], [IdPosicion], [IdEquipo], [IdNacionalidad], [IdTorneo], [Activo]) VALUES (3, N'Javier Matias', N'Pastore', 187, 33, CAST(N'1989-06-20' AS Date), N'https://img.a.transfermarkt.technology/portrait/big/55215-1596030059.jpg?lm=1', 3, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Jugador] OFF
GO
SET IDENTITY_INSERT [dbo].[Nacionalidad] ON 

INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (1, N'Argentina')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (2, N'Brasil')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (3, N'Colombia')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (4, N'Mexico')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (5, N'Peru')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (6, N'Bolivia')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (7, N'Paraguay')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (8, N'Uruguay')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (9, N'Chile')
INSERT [dbo].[Nacionalidad] ([Id], [Nombre]) VALUES (10, N'Venezuela')
SET IDENTITY_INSERT [dbo].[Nacionalidad] OFF
GO
SET IDENTITY_INSERT [dbo].[Posicion] ON 

INSERT [dbo].[Posicion] ([Id], [Nombre]) VALUES (1, N'Arquero')
INSERT [dbo].[Posicion] ([Id], [Nombre]) VALUES (2, N'Defensor')
INSERT [dbo].[Posicion] ([Id], [Nombre]) VALUES (3, N'Volante')
INSERT [dbo].[Posicion] ([Id], [Nombre]) VALUES (4, N'Delantero')
SET IDENTITY_INSERT [dbo].[Posicion] OFF
GO
SET IDENTITY_INSERT [dbo].[Torneo] ON 

INSERT [dbo].[Torneo] ([Id], [Nombre]) VALUES (1, N'Torneo Binance 2023')
INSERT [dbo].[Torneo] ([Id], [Nombre]) VALUES (2, N'Campeonato de Primera Nacional 2023')
SET IDENTITY_INSERT [dbo].[Torneo] OFF
GO
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 1)
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 2)
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 3)
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 4)
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 5)
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 6)
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 7)
INSERT [dbo].[TorneoEquipo] ([IdTorneo], [IdEquipo]) VALUES (1, 8)
GO
ALTER TABLE [dbo].[Jugador]  WITH CHECK ADD  CONSTRAINT [FK_Jugador_Equipo] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([Id])
GO
ALTER TABLE [dbo].[Jugador] CHECK CONSTRAINT [FK_Jugador_Equipo]
GO
ALTER TABLE [dbo].[Jugador]  WITH CHECK ADD  CONSTRAINT [FK_Jugador_Nacionalidad] FOREIGN KEY([IdNacionalidad])
REFERENCES [dbo].[Nacionalidad] ([Id])
GO
ALTER TABLE [dbo].[Jugador] CHECK CONSTRAINT [FK_Jugador_Nacionalidad]
GO
ALTER TABLE [dbo].[Jugador]  WITH CHECK ADD  CONSTRAINT [FK_Jugador_Posicion] FOREIGN KEY([IdPosicion])
REFERENCES [dbo].[Posicion] ([Id])
GO
ALTER TABLE [dbo].[Jugador] CHECK CONSTRAINT [FK_Jugador_Posicion]
GO
ALTER TABLE [dbo].[Jugador]  WITH CHECK ADD  CONSTRAINT [FK_Jugador_Torneo] FOREIGN KEY([IdTorneo])
REFERENCES [dbo].[Torneo] ([Id])
GO
ALTER TABLE [dbo].[Jugador] CHECK CONSTRAINT [FK_Jugador_Torneo]
GO
ALTER TABLE [dbo].[TorneoEquipo]  WITH CHECK ADD  CONSTRAINT [FK__TorneoEqu__IdEqu__3B75D760] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipo] ([Id])
GO
ALTER TABLE [dbo].[TorneoEquipo] CHECK CONSTRAINT [FK__TorneoEqu__IdEqu__3B75D760]
GO
ALTER TABLE [dbo].[TorneoEquipo]  WITH CHECK ADD FOREIGN KEY([IdTorneo])
REFERENCES [dbo].[Torneo] ([Id])
GO
USE [master]
GO
ALTER DATABASE [FUTBOL] SET  READ_WRITE 
GO
