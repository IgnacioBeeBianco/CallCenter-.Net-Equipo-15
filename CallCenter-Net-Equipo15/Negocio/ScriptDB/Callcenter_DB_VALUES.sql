USE master
GO

USE Callcenter
GO

-- Agregar datos a la tabla TipoIncidencia
INSERT INTO TipoIncidencia (nombre, descripcion) VALUES 
    ('Hardware', 'Problemas relacionados con hardware'),
    ('Software', 'Problemas relacionados con software'),
    ('Red', 'Problemas de conectividad de red');

-- Agregar datos a la tabla Prioridad
INSERT INTO Prioridad (nombre, estado) VALUES 
    ('Alta', 1),
    ('Media', 1),
    ('Baja', 1);

-- Agrega nuevos registros a la tabla Estado
INSERT INTO Estado (nombre, estado) VALUES 
    ('Abierto', 1),
    ('En Análisis', 1),
    ('Cerrado', 1),
    ('Reabierto', 1),
    ('Asignado', 1),
    ('Resuelto', 1);

-- Agrega nuevos registros a la tabla Rol
INSERT INTO Rol (nombre, estado) VALUES 
    ('Administrador', 1),
    ('Telefonista', 1),
    ('Supervisor', 1),
    ('Cliente', 1);

-- Agrega nuevos registros a la tabla Cuenta
INSERT INTO Cuenta (email, password_, id_rol) VALUES 
    ('admin@gmail.com', 'admin123', 1),
    ('telefonista@gmail.com', 'telefonista123', 2),
    ('supervisor@gmail.com', 'supervisor123', 3),
    ('cliente@gmail.com', 'cliente123', 4);

-- Agrega nuevos registros a la tabla Usuario
INSERT INTO Usuario (nombre, apellido, dni, domicilio, telefono, genero, cuenta_id) VALUES 
    ('admin', 'admin', '12345678', 'Calle 123', '1234567890', 'M', 1),
    ('Telefonista', 'Ejemplo', '87654321', 'Calle 456', '9876543210', 'F', 2),
    ('Supervisor', 'Ejemplo', '11223344', 'Calle 789', '1112233445', 'M', 3),
    ('Cliente', 'Ejemplo', '44332211', 'Calle XYZ', '5556667777', 'F', 4);