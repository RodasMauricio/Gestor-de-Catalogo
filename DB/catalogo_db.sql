use master
go
create database CATALOGO_DB
go
use CATALOGO_DB
go
USE [CATALOGO_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MARCAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
USE [CATALOGO_DB]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 08/09/2019 10:32:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
USE [CATALOGO_DB]
GO
/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 08/09/2019 10:32:24 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](500) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] [money] NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
insert into MARCAS values ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Celulares'),('Televisores'), ('Media'), ('Audio'), ('Consolas')
insert into ARTICULOS values ('S25', 'Galaxy S25', 'El Galaxy S25 estándar cuenta con una pantalla de 6.2 pulgadas, cámara triple de 50MP + 12MP + 10MP, hasta 256GB de almacenamiento, 8GB de RAM y batería de 4,000mAh con carga rápida de 25W', 1, 1, 'https://e00-elmundo.uecdn.es/assets/multimedia/imagenes/2025/01/22/17375706654145.jpg', 1500000),
('M50', 'Moto Edge 50', 'El Motorola Edge 50 Fusion es un celular de gama media alta con características de excelente desempeño como su procesador Snapdragon 6 Gen 1, cámara doble de 50 MP y pantalla pOLED de 6,7 pulgadas.', 5, 1, 'https://armoto.vtexassets.com/arquivos/ids/167275-800-auto?v=638948713056400000&width=800&height=auto&aspect=true', 800000),
('PS2', 'PlayStation 2', 'PlayStation 2 es la segunda videoconsola de sobremesa descontinuada producida por Sony. Lanzamiento 04/03/2000', 3, 5, 'https://cdn.pixabay.com/photo/2017/04/04/18/15/video-game-console-2202637_1280.jpg', 250000),
('B55', 'Bravia 55', 'Mejor calidad de imagen y sonido en películas, programas y juegos con los Smart TV de 55 pulgadas. 4K y Full HD para imágenes increíbles y parlantes Magnetic Fluid para un sonido estremecedor', 3, 2, 'https://images.fravega.com/f1000/4f4c42faf76dbadf30e63dc2b2110a6e.jpg', 2000000),
('ATV', 'Apple TV', 'Apple TV es un reproductor de medios digital que transforma cualquier televisor en un Smart TV, dando acceso a servicios de streaming, películas, juegos, música y más a través de una conexión HDMI', 2, 3, 'https://kiteandkey.rutgers.edu/product_images/MN893LL/A_01.jpg', 400000)
select * from ARTICULOS