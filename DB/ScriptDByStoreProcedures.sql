USE [master]
GO
/****** Object:  Database [Carro de compras]    Script Date: 2/06/2022 1:32:11 a. m. ******/
CREATE DATABASE [Carro de compras]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Carro de compras', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Carro de compras.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Carro de compras_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Carro de compras_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Carro de compras] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Carro de compras].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Carro de compras] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Carro de compras] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Carro de compras] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Carro de compras] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Carro de compras] SET ARITHABORT OFF 
GO
ALTER DATABASE [Carro de compras] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Carro de compras] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Carro de compras] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Carro de compras] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Carro de compras] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Carro de compras] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Carro de compras] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Carro de compras] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Carro de compras] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Carro de compras] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Carro de compras] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Carro de compras] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Carro de compras] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Carro de compras] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Carro de compras] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Carro de compras] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Carro de compras] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Carro de compras] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Carro de compras] SET  MULTI_USER 
GO
ALTER DATABASE [Carro de compras] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Carro de compras] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Carro de compras] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Carro de compras] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Carro de compras] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Carro de compras] SET QUERY_STORE = OFF
GO
USE [Carro de compras]
GO
/****** Object:  Table [dbo].[tblCompras]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCompras](
	[ComprasID] [int] IDENTITY(1,1) NOT NULL,
	[ProductoID] [int] NULL,
	[UsuarioID] [int] NULL,
	[Fecha] [date] NULL,
	[CantidadComprada] [int] NULL,
 CONSTRAINT [PK_tblCompras] PRIMARY KEY CLUSTERED 
(
	[ComprasID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProductos]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductos](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Cantidad] [int] NULL,
	[Descripcion] [varchar](200) NULL,
	[Precio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tblProductos] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsuarios]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](15) NULL,
	[Contraseña] [varchar](200) NULL,
	[Nombres] [varchar](50) NULL,
	[Identificacion] [varchar](15) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](15) NULL,
	[Perfil] [bit] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spCompras_Buscar]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCompras_Buscar]
	
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT tblUsuarios.Usuario,tblUsuarios.Identificacion, tblUsuarios.Direccion,tblCompras.CantidadComprada, tblCompras.Fecha, tblProductos.Nombre, tblProductos.Descripcion, tblProductos.Cantidad,tblProductos.Precio from tblUsuarios INNER JOIN  tblCompras 
	ON tblUsuarios.UsuarioID= tblCompras.UsuarioID INNER JOIN tblProductos 
	ON tblProductos.ProductoID=tblCompras.ProductoID 

END
GO
/****** Object:  StoredProcedure [dbo].[spCompras_Guardar]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spCompras_Guardar]
	@ProductoID int,
	@UsuarioID int,
	@Fecha date,
	@CantidadComprada int
AS
BEGIN

	SET NOCOUNT ON;

    insert into tblCompras (ProductoID,UsuarioID,Fecha,CantidadComprada)
	values(@ProductoID,@UsuarioID,@Fecha,@CantidadComprada)

	  IF (@CantidadComprada > 0)
	  BEGIN
		 UPDATE tblProductos
		 SET Cantidad = Cantidad - @CantidadComprada
		 WHERE ProductoID = @ProductoID
	   END

END
GO
/****** Object:  StoredProcedure [dbo].[spProductos_Actualizar]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spProductos_Actualizar]
	@ProductoID int,
	@Nombre varchar(50),
	@Cantidad int,
	@Descripcion varchar(200),
	@Precio decimal(18,2)

AS
BEGIN
	
	SET NOCOUNT OFF; --con SET NOCOUNT en OFF, se habilita para contar el número de filas afectadas

    update tblProductos set Nombre=@Nombre,Cantidad=@Cantidad,Descripcion=@Descripcion,Precio=@Precio
	where ProductoID=@ProductoID

	SELECT @@ROWCOUNT; --Devuelve el número de filas afectadas en la actualización
	
END
GO
/****** Object:  StoredProcedure [dbo].[spProductos_Buscar]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spProductos_Buscar]
	
AS
BEGIN

	SET NOCOUNT ON;
	
    select ProductoID ,Nombre, Cantidad, Descripcion,Precio, 
	CONVERT(varchar,ProductoID) + ';' + CONVERT(varchar, Nombre) + ';' + CONVERT(varchar,Cantidad) AS Cadena  from tblProductos
	where Cantidad>0
END
GO
/****** Object:  StoredProcedure [dbo].[spUsuarios_GuardarUsuario]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUsuarios_GuardarUsuario]
	@Usuario varchar(15),
	@Contraseña varchar(200),
	@Nombres varchar(50),
	@Identificacion varchar(15),
	@Direccion varchar(15),
	@Telefono varchar(15),
	@perfil bit
AS
BEGIN

	SET NOCOUNT ON;
	declare @id int
    -- Insert statements for procedure here
	insert into tblUsuarios (Usuario,Contraseña,Nombres,Identificacion,Direccion,Telefono,Perfil) 
	values(@Usuario,@Contraseña,@Nombres,@Identificacion,@Direccion,@Telefono,@perfil)
	set @id=SCOPE_IDENTITY()
	select @id
END
GO
/****** Object:  StoredProcedure [dbo].[spUsuarios_ValidarUsuario]    Script Date: 2/06/2022 1:32:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUsuarios_ValidarUsuario]
	@Usuario varchar(15),
	@Contraseña varchar(200)
AS
BEGIN
	
	SET NOCOUNT ON;

    select * from tblUsuarios where Usuario=@Usuario --No se comparó la contraseña, porque se valida en el backend (lo que devuelve el IDataReader) para ser más claro al usuario respecto a que dato ingresó incorrectamente
END
GO
USE [master]
GO
ALTER DATABASE [Carro de compras] SET  READ_WRITE 
GO
