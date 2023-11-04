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
INSERT INTO Prioridad (nombre) VALUES ('Alta');
INSERT INTO Prioridad (nombre) VALUES ('Media');
INSERT INTO Prioridad (nombre) VALUES ('Baja');
GO
INSERT INTO Cuenta (email, password_, id_rol) VALUES ('admin@gmail.com', 'admin', (
    SELECT id FROM Rol WHERE nombre = 'Administrador'
))
GO
INSERT INTO Usuario (nombre, apellido, dni, domicilio, telefono, genero, cuenta_id) 
VALUES ('Juan', 'Rodriguez', '43900200', 'Irusta 900', '11458901', 'M', 1) 

