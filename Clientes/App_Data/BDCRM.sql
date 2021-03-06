USE [BDCRM]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoEmpresa]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoEmpresa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NULL,
 CONSTRAINT [PK_TipoEmpresa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoAccion]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoAccion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoAccion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Direccion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Domicilio] [varchar](150) NOT NULL,
	[Poblacion] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[CP] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Carg] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DireccionContacto]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DireccionContacto](
	[IDContacto] [int] NOT NULL,
	[IDDireccion] [int] NOT NULL,
 CONSTRAINT [PK_DireccionContacto] PRIMARY KEY CLUSTERED 
(
	[IDContacto] ASC,
	[IDDireccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CIF] [varchar](50) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Web] [varchar](50) NULL,
	[TipoEmpresa] [int] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DireccionEmpresa]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DireccionEmpresa](
	[IDEmprsa] [int] NOT NULL,
	[IDDireccion] [int] NOT NULL,
 CONSTRAINT [PK_DireccionEmpresa] PRIMARY KEY CLUSTERED 
(
	[IDEmprsa] ASC,
	[IDDireccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TelefonoEmpresa]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TelefonoEmpresa](
	[IDEmpresa] [int] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TelefonoEmpresa] PRIMARY KEY CLUSTERED 
(
	[Telefono] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccionComercial]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccionComercial](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [int] NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Comentarios] [varchar](250) NULL,
	[IDAccion] [int] NOT NULL,
	[IDEstado] [int] NOT NULL,
 CONSTRAINT [PK_AccionComercial] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contacto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDEmpresa] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CargoContacto]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CargoContacto](
	[IDContacto] [int] NOT NULL,
	[IDCargo] [int] NOT NULL,
 CONSTRAINT [PK_CargoContacto] PRIMARY KEY CLUSTERED 
(
	[IDContacto] ASC,
	[IDCargo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TelefonoContacto]    Script Date: 08/05/2014 17:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TelefonoContacto](
	[IDContacto] [int] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TelefonoContacto] PRIMARY KEY CLUSTERED 
(
	[Telefono] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_AccionComercial_Empresa]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[AccionComercial]  WITH CHECK ADD  CONSTRAINT [FK_AccionComercial_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([ID])
GO
ALTER TABLE [dbo].[AccionComercial] CHECK CONSTRAINT [FK_AccionComercial_Empresa]
GO
/****** Object:  ForeignKey [FK_AccionComercial_Estado]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[AccionComercial]  WITH CHECK ADD  CONSTRAINT [FK_AccionComercial_Estado] FOREIGN KEY([IDEstado])
REFERENCES [dbo].[Estado] ([ID])
GO
ALTER TABLE [dbo].[AccionComercial] CHECK CONSTRAINT [FK_AccionComercial_Estado]
GO
/****** Object:  ForeignKey [FK_AccionComercial_TipoAccion]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[AccionComercial]  WITH CHECK ADD  CONSTRAINT [FK_AccionComercial_TipoAccion] FOREIGN KEY([IDAccion])
REFERENCES [dbo].[TipoAccion] ([ID])
GO
ALTER TABLE [dbo].[AccionComercial] CHECK CONSTRAINT [FK_AccionComercial_TipoAccion]
GO
/****** Object:  ForeignKey [FK_AccionComercial_User]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[AccionComercial]  WITH CHECK ADD  CONSTRAINT [FK_AccionComercial_User] FOREIGN KEY([Usuario])
REFERENCES [dbo].[User] ([IDUsuario])
GO
ALTER TABLE [dbo].[AccionComercial] CHECK CONSTRAINT [FK_AccionComercial_User]
GO
/****** Object:  ForeignKey [FK_CargoContacto_Cargo]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[CargoContacto]  WITH CHECK ADD  CONSTRAINT [FK_CargoContacto_Cargo] FOREIGN KEY([IDCargo])
REFERENCES [dbo].[Cargo] ([ID])
GO
ALTER TABLE [dbo].[CargoContacto] CHECK CONSTRAINT [FK_CargoContacto_Cargo]
GO
/****** Object:  ForeignKey [FK_CargoContacto_Contacto]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[CargoContacto]  WITH CHECK ADD  CONSTRAINT [FK_CargoContacto_Contacto] FOREIGN KEY([IDContacto])
REFERENCES [dbo].[Contacto] ([ID])
GO
ALTER TABLE [dbo].[CargoContacto] CHECK CONSTRAINT [FK_CargoContacto_Contacto]
GO
/****** Object:  ForeignKey [FK_Contacto_Empresa]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([ID])
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Empresa]
GO
/****** Object:  ForeignKey [FK_DireccionContacto_Direccion]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[DireccionContacto]  WITH CHECK ADD  CONSTRAINT [FK_DireccionContacto_Direccion] FOREIGN KEY([IDDireccion])
REFERENCES [dbo].[Direccion] ([ID])
GO
ALTER TABLE [dbo].[DireccionContacto] CHECK CONSTRAINT [FK_DireccionContacto_Direccion]
GO
/****** Object:  ForeignKey [FK_DireccionEmpresa_Direccion]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[DireccionEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_DireccionEmpresa_Direccion] FOREIGN KEY([IDDireccion])
REFERENCES [dbo].[Direccion] ([ID])
GO
ALTER TABLE [dbo].[DireccionEmpresa] CHECK CONSTRAINT [FK_DireccionEmpresa_Direccion]
GO
/****** Object:  ForeignKey [FK_DireccionEmpresa_Empresa]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[DireccionEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_DireccionEmpresa_Empresa] FOREIGN KEY([IDEmprsa])
REFERENCES [dbo].[Empresa] ([ID])
GO
ALTER TABLE [dbo].[DireccionEmpresa] CHECK CONSTRAINT [FK_DireccionEmpresa_Empresa]
GO
/****** Object:  ForeignKey [FK_Empresa_TipoEmpresa]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_TipoEmpresa] FOREIGN KEY([TipoEmpresa])
REFERENCES [dbo].[TipoEmpresa] ([ID])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_TipoEmpresa]
GO
/****** Object:  ForeignKey [FK_TelefonoContacto_Contacto]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[TelefonoContacto]  WITH CHECK ADD  CONSTRAINT [FK_TelefonoContacto_Contacto] FOREIGN KEY([IDContacto])
REFERENCES [dbo].[Contacto] ([ID])
GO
ALTER TABLE [dbo].[TelefonoContacto] CHECK CONSTRAINT [FK_TelefonoContacto_Contacto]
GO
/****** Object:  ForeignKey [FK_TelefonoEmpresa_Empresa]    Script Date: 08/05/2014 17:46:43 ******/
ALTER TABLE [dbo].[TelefonoEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_TelefonoEmpresa_Empresa] FOREIGN KEY([IDEmpresa])
REFERENCES [dbo].[Empresa] ([ID])
GO
ALTER TABLE [dbo].[TelefonoEmpresa] CHECK CONSTRAINT [FK_TelefonoEmpresa_Empresa]
GO
