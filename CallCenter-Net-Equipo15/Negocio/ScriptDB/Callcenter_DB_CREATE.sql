USE Master
GO

-- Verificar si la base de datos "Callcenter" existe, y si no, crearla
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Callcenter')
BEGIN
    CREATE DATABASE Callcenter
END
GO

USE Callcenter
GO

-- Verificar si la tabla "Rol" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Rol')
BEGIN
    CREATE TABLE Rol (
        id INT IDENTITY(1,1),
        nombre NVARCHAR(100) NOT NULL,
        PRIMARY KEY (id)
    )
END
GO

-- Verificar si la tabla "Cuenta" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cuenta')
BEGIN
    CREATE TABLE Cuenta (
        id INT IDENTITY(1,1),
        email VARCHAR(300) NOT NULL,
        password_ VARCHAR(300) NOT NULL,
        id_rol INT NOT NULL,
        PRIMARY KEY (id),
        FOREIGN KEY (id_rol) REFERENCES Rol(id),
        UNIQUE(email)
    )
END
GO

-- Verificar si la tabla "TipoIncidencia" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TipoIncidencia')
BEGIN
    CREATE TABLE TipoIncidencia (
        oid BIGINT IDENTITY(1,1),
        nombre NVARCHAR(150) NOT NULL,
        descripcion NVARCHAR(300),
        PRIMARY KEY (oid)
    )
END
GO

-- Verificar si la tabla "TipoIncidencia" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Prioridad')
BEGIN
    CREATE TABLE Prioridad (
        id BIGINT IDENTITY(1,1),
        nombre NVARCHAR(150) NOT NULL UNIQUE,
        PRIMARY KEY (id)
    )
END
GO

-- Verificar si la tabla "Usuario" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuario')
BEGIN
    CREATE TABLE Usuario (
        id INT IDENTITY(1,1),
        nombre VARCHAR(50) NOT NULL,
        apellido VARCHAR(50) NOT NULL,
        dni VARCHAR(8) NOT NULL,
        domicilio VARCHAR(100) NOT NULL,
        telefono VARCHAR(10) NOT NULL,
        genero CHAR NOT NULL CHECK (genero = 'M' or genero = 'F' or genero = 'X'),
        cuenta_id INT NOT NULL,
        PRIMARY KEY (id),
        FOREIGN KEY (cuenta_id) REFERENCES Cuenta(id),
        UNIQUE(dni)
    )
END
GO
