USE Master;
ALTER DATABASE Callcenter SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
USE master;
SELECT * FROM sys.dm_exec_sessions WHERE database_id = DB_ID('Callcenter');
DROP DATABASE Callcenter
GO
USE master;
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
        estado BIT NOT NULL DEFAULT 1
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
        estado BIT NOT NULL DEFAULT 1
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
        id INT IDENTITY(1,1),
        nombre NVARCHAR(150) NOT NULL,
        descripcion NVARCHAR(300),
        estado BIT NOT NULL DEFAULT 1
        PRIMARY KEY (id)
    )
END
GO

-- Verificar si la tabla "Prioridad" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Prioridad')
BEGIN
    CREATE TABLE Prioridad (
        id INT IDENTITY(1,1),
        nombre NVARCHAR(150) NOT NULL UNIQUE,
        nivelPrioridad INT NOT NULL,
        estado BIT NOT NULL DEFAULT 1,
        CHECK (nivelPrioridad BETWEEN 1 AND 10),
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
        estado BIT DEFAULT 1,
        PRIMARY KEY (id),
        FOREIGN KEY (cuenta_id) REFERENCES Cuenta(id),
        UNIQUE(dni)
    )
END
GO

-- Verificar si la tabla "Estado" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Estado')
BEGIN
    CREATE TABLE Estado (
        id INT IDENTITY(1,1),
        nombre NVARCHAR(100) NOT NULL,
        nivelEstado INT NOT NULL,
        estado BIT NOT NULL DEFAULT 1,
        CHECK (nivelEstado BETWEEN 1 AND 10),
        PRIMARY KEY (id)
    )
END

-- Verificar si la tabla "Incidencia" existe, y si no, crearla
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Incidencia')
BEGIN
    CREATE TABLE Incidencia (
        id INT IDENTITY(1,1),
        creador_id INT NOT NULL,
        asignado_id INT NOT NULL,
        fecha_creacion DATETIME NOT NULL,
        fecha_ultimo_cambio DATETIME,
        estado_id INT NOT NULL,
        prioridad_id INT NOT NULL,
        tipo_incidencia_id INT NOT NULL,
        comentario_cierra NVARCHAR(300),
        problematica NVARCHAR(500),
        estado BIT NOT NULL DEFAULT 1

        PRIMARY KEY(id),
        FOREIGN KEY(creador_id) REFERENCES Usuario(id),
        FOREIGN KEY(asignado_id) REFERENCES Usuario(id),
        FOREIGN KEY(estado_id) REFERENCES Estado(id),
        FOREIGN KEY(prioridad_id) REFERENCES Prioridad(id),
        FOREIGN KEY(tipo_incidencia_id) REFERENCES TipoIncidencia(id)
    )
END