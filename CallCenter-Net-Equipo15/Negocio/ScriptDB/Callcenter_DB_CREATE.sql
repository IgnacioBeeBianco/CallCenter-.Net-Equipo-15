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

-- Verificar si la tabla "Prioridad" existe, y si no, crearla
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
        Estado BIT DEFAULT 1,
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
        fecha_cierre DATETIME NOT NULL,
        estado_id INT NOT NULL,
        prioridad_id BIGINT NOT NULL,
        tipo_incidencia_id BIGINT NOT NULL,
        comentario_cierra NVARCHAR(300),
        problematica NVARCHAR(500)

        PRIMARY KEY(id),
        FOREIGN KEY(creador_id) REFERENCES Usuario(id),
        FOREIGN KEY(asignado_id) REFERENCES Usuario(id),
        FOREIGN KEY(estado_id) REFERENCES Estado(id),
        FOREIGN KEY(prioridad_id) REFERENCES Prioridad(id),
        FOREIGN KEY(tipo_incidencia_id) REFERENCES TipoIncidencia(oid)
    )
END


INSERT INTO Incidencia (creador_id, asignado_id, fecha_creacion, fecha_cierre, estado_id, prioridad_id, tipo_incidencia_id, comentario_cierra, problematica)
VALUES
    (1, 1, '2023-11-13 08:00:00', '2023-11-14 10:30:00', 1, 2, 2, 'Comentario de cierre', 'Descripción del problema');

 SELECT I.id,U.id as idCreador, U.nombre as creador,U2.id as idAsignado, U2.nombre as asignado, I.fecha_creacion, I.fecha_cierre,E.id as idEstado, E.nombre as Estado,P.id as idPrioridad, P.nombre as Prioridad,TI.oid as idTipoIncidencia, TI.nombre as TipoIncidencia, I.comentario_cierra, I.problematica
 FROM Incidencia as I
 INNER JOIN Usuario as U on I.creador_id = U.cuenta_id
 INNER JOIN Usuario as U2 on I.asignado_id = U2.cuenta_id
 INNER JOIN Estado as E on I.estado_id = E.id
 INNER JOIN Prioridad as P on I.prioridad_id = P.id
 INNER JOIN TipoIncidencia as TI on I.tipo_incidencia_id = TI.oid
 WHERE E.nombre LIKE 'Abierto'
                    
SELECT *
FROM Estado
WHERE nombre <> 'Abierto';

INSERT INTO Incidencia (
    creador_id,
    asignado_id,
    fecha_creacion,
    fecha_cierre,
    estado_id,
    prioridad_id,
    tipo_incidencia_id,
    comentario_cierra,
    problematica
)
VALUES (
    1, -- ID del creador (reemplaza con el valor correcto)
    1, -- ID del asignado (reemplaza con el valor correcto)
    GETDATE(), -- Fecha de creación (puedes usar la función adecuada para obtener la fecha actual)
    GETDATE(),
    null, -- Fecha de cierre (puedes usar la función adecuada para obtener la fecha actual)
    3, -- ID del estado (reemplaza con el valor correcto)
    1, -- ID de la prioridad (reemplaza con el valor correcto)
    2, -- ID del tipo de incidencia (reemplaza con el valor correcto)
    'Comentario de cierre aquí', -- Comentario de cierre (reemplaza con el valor correcto)
    'Descripción del problema aquí' -- Descripción del problema (reemplaza con el valor correcto)
);

