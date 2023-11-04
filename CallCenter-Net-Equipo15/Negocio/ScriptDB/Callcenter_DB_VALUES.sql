USE Callcenter
GO
INSERT INTO TipoIncidencia(nombre) VALUES ('Defecto interno')
GO
INSERT INTO TipoIncidencia(nombre) VALUES ('Bug')
GO
INSERT INTO TipoIncidencia(nombre) VALUES ('Requerimiento')
GO
INSERT INTO Rol (nombre) VALUES ('Administrador');
GO
INSERT INTO Cuenta (email, password_, id_rol) VALUES ('admin@gmail.com', 'admin', (
    SELECT id FROM Rol WHERE nombre = 'Administrador'
))
