Use Master
Go
Create Database Callcenter
go
Use Callcenter
go

CREATE TABLE Rol(
    id INT IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL

    PRIMARY KEY(id)
)
GO
CREATE TABLE Cuenta(
    id INT IDENTITY(1,1),
    email VARCHAR(300) NOT NULL,
    password_ VARCHAR(300) NOT NULL,
    id_rol INT NOT NULL

    PRIMARY KEY(id),
    FOREIGN KEY (id_rol) REFERENCES Rol(id),
    UNIQUE(email)
)
GO
CREATE TABLE TipoIncidencia(
	oid BIGINT IDENTITY(1,1),
	nombre NVARCHAR(150) NOT NULL,
	descripcion NVARCHAR(300),

	PRIMARY KEY (oid)
)
GO
CREATE TABLE Cliente(
    id INT IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    dni VARCHAR(8) NOT NULL,
    cuenta_id INT NOT NULL,

    PRIMARY KEY(id),
    FOREIGN KEY (cuenta_id) REFERENCES Cuenta(id),
    UNIQUE(dni)
)
GO
CREATE TABLE Usuario(
    id INT IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    dni VARCHAR(8) NOT NULL,
    domicilio VARCHAR(100) NOT NULL,
    telefono VARCHAR(10) NOT NULL,
    genero CHAR NOT NULL CHECK(genero='M' or genero='F' or genero='X'),
    cuenta_id INT NOT NULL,

    PRIMARY KEY(id),
    FOREIGN KEY (cuenta_id) REFERENCES Cuenta(id),
    UNIQUE(dni)
)





