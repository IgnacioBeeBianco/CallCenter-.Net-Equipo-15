USE Callcenter
GO

CREATE TABLE TipoIncidencia(
	oid BIGINT IDENTITY(1,1),
	nombre NVARCHAR(150) NOT NULL,
	descripcion NVARCHAR(300),

	PRIMARY KEY (oid)
);