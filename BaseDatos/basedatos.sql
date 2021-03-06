USE MASTER
GO
--DROP DATABASE [BD_PRUEBA]
--GO
CREATE DATABASE  [BD_PRUEBA]
GO
USE [BD_PRUEBA]
GO
CREATE TABLE [dbo].[autor](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[vCodigoAutor] [varchar](5) NULL,
	[nNombre] [nvarchar](30) NULL,
	[nApellidoPaterno] [nvarchar](20) NULL,
	[nApellidoMaterno] [nvarchar](20) NULL,
	[iEdad] [tinyint] NULL,
	[bEstado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libro]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[vTitulo] [varchar](60) NULL,
	[bEstado] [bit] NULL,
	[IdAutor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libro_coautor]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libro_coautor](
	[IdLibro] [int] NOT NULL,
	[IdAutor] [int] NOT NULL,
	[fechaAsignacion] [datetime] NULL,
	[ResumenContribucion] [nvarchar](max) NULL,
 CONSTRAINT [FK_libro_coautor_IdAutor] PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC,
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[autor] ON 

INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (3, N'C0001', N'sampl', N'sample string 5', N'sample string 4', 6, 0)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (6, N'C0002', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (1003, N'C0003', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (1004, N'C0004', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (1005, N'C0005', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (1006, N'C0006', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (1007, N'C0007', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (1008, N'C0008', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
INSERT [dbo].[autor] ([IdAutor], [vCodigoAutor], [nNombre], [nApellidoPaterno], [nApellidoMaterno], [iEdad], [bEstado]) VALUES (1009, N'C0009', N'sampl', N'sample string 5', N'sample string 4', 6, 1)
SET IDENTITY_INSERT [dbo].[autor] OFF
GO
SET IDENTITY_INSERT [dbo].[libro] ON 

INSERT [dbo].[libro] ([IdLibro], [vTitulo], [bEstado], [IdAutor]) VALUES (4, N'sample string 2', NULL, 6)
INSERT [dbo].[libro] ([IdLibro], [vTitulo], [bEstado], [IdAutor]) VALUES (7, N'LIBRO CREADO', NULL, 3)
INSERT [dbo].[libro] ([IdLibro], [vTitulo], [bEstado], [IdAutor]) VALUES (8, N'LIBRO CREADO', NULL, 3)
SET IDENTITY_INSERT [dbo].[libro] OFF
GO
INSERT [dbo].[libro_coautor] ([IdLibro], [IdAutor], [fechaAsignacion], [ResumenContribucion]) VALUES (4, 1003, NULL, N'Mi resumen1 modificado ')
INSERT [dbo].[libro_coautor] ([IdLibro], [IdAutor], [fechaAsignacion], [ResumenContribucion]) VALUES (4, 1004, NULL, N'Mi resumen2 modifica')
INSERT [dbo].[libro_coautor] ([IdLibro], [IdAutor], [fechaAsignacion], [ResumenContribucion]) VALUES (4, 1005, NULL, N'Mi resumen3 modifica ')
INSERT [dbo].[libro_coautor] ([IdLibro], [IdAutor], [fechaAsignacion], [ResumenContribucion]) VALUES (7, 1003, CAST(N'2022-02-10T14:59:38.423' AS DateTime), N'Mi resumen1 CREADO ')
INSERT [dbo].[libro_coautor] ([IdLibro], [IdAutor], [fechaAsignacion], [ResumenContribucion]) VALUES (7, 1004, CAST(N'2022-02-10T14:59:38.423' AS DateTime), N'Mi resumen1 CREADO')
INSERT [dbo].[libro_coautor] ([IdLibro], [IdAutor], [fechaAsignacion], [ResumenContribucion]) VALUES (8, 1003, CAST(N'2022-02-10T15:17:30.000' AS DateTime), N'Mi resumen1 CREADO ')
INSERT [dbo].[libro_coautor] ([IdLibro], [IdAutor], [fechaAsignacion], [ResumenContribucion]) VALUES (8, 1004, CAST(N'2022-02-10T15:17:30.000' AS DateTime), N'Mi resumen1 CREADO')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__autor__9A03D3DE91DAA383]    Script Date: 2/10/2022 3:34:43 PM ******/
ALTER TABLE [dbo].[autor] ADD UNIQUE NONCLUSTERED 
(
	[vCodigoAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[autor] ADD  DEFAULT ((1)) FOR [bEstado]
GO
ALTER TABLE [dbo].[libro_coautor] ADD  DEFAULT (getdate()) FOR [fechaAsignacion]
GO
ALTER TABLE [dbo].[libro_coautor]  WITH CHECK ADD  CONSTRAINT [FK_libro_coautor_autor] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[autor] ([IdAutor])
GO
ALTER TABLE [dbo].[libro_coautor] CHECK CONSTRAINT [FK_libro_coautor_autor]
GO
ALTER TABLE [dbo].[libro_coautor]  WITH CHECK ADD  CONSTRAINT [FK_libro_coautor_libro] FOREIGN KEY([IdLibro])
REFERENCES [dbo].[libro] ([IdLibro])
GO
ALTER TABLE [dbo].[libro_coautor] CHECK CONSTRAINT [FK_libro_coautor_libro]
GO
/****** Object:  StoredProcedure [dbo].[spEliminaAutor]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEliminaAutor](
@iIdAutor int)
as
begin

DELETE FROM autor
WHERE IdAutor=@iIdAutor

SELECT @@ROWCOUNT
end
GO
/****** Object:  StoredProcedure [dbo].[spEliminaAutorSecundario]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEliminaAutorSecundario](
@iIdLibro int)
as
begin
delete from libro_coautor where IdLibro=@iIdLibro
end
GO
/****** Object:  StoredProcedure [dbo].[spEliminaLAutor]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEliminaLAutor](
@iIdAutor int)
as
begin

UPDATE autor
SET bEstado=0
WHERE IdAutor=@iIdAutor

SELECT @@ROWCOUNT
end
GO
/****** Object:  StoredProcedure [dbo].[spEliminaLibro]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEliminaLibro](
@iIdLibro int)
as
begin

DELETE FROM libro
WHERE IdLibro=@iIdLibro

SELECT @@ROWCOUNT
end
GO
/****** Object:  StoredProcedure [dbo].[spInsertaAutor]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertaAutor](
@vCodigoAutor varchar(5),
@vNombre nvarchar(5),
@nApellidoPaterno nvarchar(20),
@nApellidoMaterno nvarchar(20),
@iEdad tinyint
)
AS
BEGIN

INSERT INTO autor(vCodigoAutor,nNombre,nApellidoPaterno,nApellidoMaterno,iEdad)
VALUES(@vCodigoAutor,@vNombre,@nApellidoPaterno,@nApellidoMaterno,@iEdad)
SELECT @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertaAutorSecundario]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsertaAutorSecundario](
@iIdLibro int,
@iIdAutor int,
@vResumen nvarchar(max))
as
begin

insert into libro_coautor(IdLibro,IdAutor,ResumenContribucion,fechaAsignacion)
values(@iIdLibro,@iIdAutor,@vResumen,GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[spInsertaLibro]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[spInsertaLibro](
@vTitulo varchar(60),
@iIdAutor int)
as
begin

INSERT INTO  libro (vTitulo,IdAutor)
VALUES (@vTitulo,@iIdAutor)

SELECT @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[spListaAutores]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListaAutores]
as
begin
      SELECT * FROM autor 
        ORDER BY IdAutor  
end
GO
/****** Object:  StoredProcedure [dbo].[spListaAutoresPaginacion]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListaAutoresPaginacion](
@NroPagina INT,
@CantidadRegistros INT)
AS
BEGIN

 
   SET NOCOUNT ON;  

 
        DECLARE @SALTOFILA INT  
        SET @SALTOFILA =(@NroPagina - 1)* @CantidadRegistros  
  
        SELECT * FROM autor 
        ORDER BY IdAutor   
      
        OFFSET @SALTOFILA ROWS FETCH NEXT @CantidadRegistros ROWS ONLY  
   

END

GO
/****** Object:  StoredProcedure [dbo].[spModificaAutores]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spModificaAutores]
@iIdAutor int,
@vNombre nvarchar(5),
@nApellidoPaterno nvarchar(20),
@nApellidoMaterno nvarchar(20),
@iEdad tinyint
AS  
BEGIN  
    SET NOCOUNT ON;  
    UPDATE autor  
      SET nNombre = @vNombre,  
          nApellidoPaterno = @nApellidoPaterno,  
          nApellidoMaterno = @nApellidoMaterno,
		  iEdad=@iEdad
      WHERE IdAutor=@iIdAutor

        SELECT @@ROWCOUNT 
END
GO
/****** Object:  StoredProcedure [dbo].[spModificaLibro]    Script Date: 2/10/2022 3:34:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spModificaLibro](
@vTitulo varchar(60),
@iIdAutor int,
@iIdlibro int)
as
begin
update libro
set vTitulo=@vTitulo,
IdAutor=@iIdAutor
WHERE IdLibro=@iIdlibro

SELECT @@ROWCOUNT
end
GO
