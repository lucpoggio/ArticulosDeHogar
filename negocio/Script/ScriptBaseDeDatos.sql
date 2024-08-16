--password de usuarios: 
--admin
--user
--invitado

use master
go
create database CATALOGO_WEB_DB
go
use CATALOGO_WEB_DB
go
USE [CATALOGO_WEB_DB]
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
    [Descripcion] [varchar](150) NULL,
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
create table USERS(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [email] [varchar](100) NOT NULL,
    [pass] [varchar](20) NOT NULL,
    [nombre] [varchar](50) NULL,
    [apellido] [varchar](50) NULL,
    [urlImagenPerfil] [varchar](500) NULL,
    [admin] [bit] NOT NULL DEFAULT 0
)
go
create table FAVORITOS(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [IdUser] [int] NOT NULL,
    [IdArticulo] [int] NOT NULL
)
go
INSERT INTO USERS VALUES
('admin@admin.com','admin','Lucas','Poggio','perfil-admin@admin.com.png',1),
('user@user.com','user','Marcelo','Gallardo','perfil-user@user.com.png',0),
('invitado@invitado.com','invitado','Jorge','Perez','perfil-invitado@invitado.com.png',0);
INSERT INTO ARTICULOS VALUES
('S10','Galaxy','Un poco viejo pero bueno!',1,1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSCIrw0NUMkG4YU-GBPKIgHEKMS4W4HDJShA&s',69.999),
('M03','Moto G Play 7ma Gen','Ya siete de estos?',1,1,'https://i.blogs.es/210960/motog7power/840_560.jpg',15699.00),
('Play4','PlayStation','Ya no se cuantas versiones hay',3,3,'https://www.cronista.com/files/image/428/428425/61f5cfa34d4dd_950_534!.jpg?s=37db0020631566d241fc3b313c18a0dc&d=1721265432',35000.00),
('BV55TH','Bravia 55','Una buena opción para tu habitación.',3,2,'https://intercompras.com/product_thumb_keepratio_2.php?img=images/product/SONY_KDL-55W950A.jpg&w=650&h=450',495000.00),
('A23','AppleTV','Converti tu tv en smart...',2,3,'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/rfb-apple-tv-4k?wid=1144&hei=1144&fmt=jpeg&qlt=80&.v=1513897159574',7850.00),
('HT300','Home Theater','Sonido envolvente de 7.1. Lleva el cine a tu hogar.',3,4,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3BUZk42hbnJjawnc3vjiyofOwhqWGKIzVDw&s',2300000.00),
('Wii','Nintendo','La clasica para jugar y bailar',3,5,'https://m.media-amazon.com/images/I/51gx99LOrFL._SL1500_.jpg',1200000.00),
('X13','Iphone','Uno de los mejorcitos...',2,1,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR39bK8KsnSJ42uDvlJWdVssgmG_tfsyIIeIQ&s',2000500.00),
('X10','Xbox','Consola apta para mayores de 12 años.',12,5,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNYBhroKdnQ9uA8_WSKRpHUN6osmzvZBWOOQ&s',1250000.00),
('NANO','TV','Una opcion accesible para tus series favoritas.',13,2,'https://images.fravega.com/f1000/cae3427c406e0a632fbb582574f8e1e4.jpg',950000.00),
('Sam55','TV','Un poco lenta pero buena.',1,2,'https://www.megatone.net/Images/Articulos/zoom2x/254/TEL5547SSG.jpg',980000.00),
('SON55','TV','Tv Sony Bravia 55 XR. Ultima tecnología en led.',3,2,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ51u9KKpTNfyJXuFyhFjnrNLZcHdoLwPOqTw&s',975000.00);
INSERT INTO CATEGORIAS VALUES
('Celulares'),
('Televisores'),
('Media'),
('Audio'),
('Consolas');
INSERT INTO MARCAS VALUES
('Samsung'),
('Apple'),
('Sony'),
('Huawei'),
('Exo'),
('Xiaomi'),
('Hp'),
('Microsoft'),
('Lg');
