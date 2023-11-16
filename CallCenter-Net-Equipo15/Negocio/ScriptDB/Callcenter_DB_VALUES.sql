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
INSERT INTO Prioridad (nombre, nivelPrioridad, estado) VALUES 
    ('Urgente', 10, 1),
    ('Alta', 8, 1),
    ('Media', 6, 1),
    ('Baja', 4, 1);

-- Agrega nuevos registros a la tabla Estado
INSERT INTO Estado (nombre, nivelEstado, estado) VALUES 
    ('Abierto', 10, 1),
    ('En Análisis',8, 1),
    ('Asignado', 6, 1),
    ('Resuelto', 4, 1),
    ('Reabierto', 2, 1),
    ('Cerrado', 0, 1);

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

-- Agrega nuevos registros a la tabla Incidencia
INSERT INTO Incidencia (creador_id, asignado_id, fecha_creacion, fecha_ultimo_cambio, estado_id, prioridad_id, tipo_incidencia_id, comentario_cierra, problematica)
VALUES
    (4, 1, '2023-11-15 10:00:00', '2023-11-16 15:30:00', 1, 1, 1, 'Cerrado con éxito', 'Problema de red en la oficina principal'),
    (4, 2, '2023-11-16 12:30:00', '2023-11-17 14:45:00', 2, 2, 2, 'Cerrado por falta de información', 'Problema con la impresora en el departamento de recursos humanos'),
    (4, 3, '2023-11-17 09:15:00', '2023-11-18 11:00:00', 3, 3, 3, 'Cerrado con solución temporal', 'Problema con el servidor de correo'),
    (4, 1, '2023-11-18 14:45:00', '2023-11-19 16:30:00', 1, 1, 1, 'Cerrado sin resolver', 'Problema de conexión a internet en la sala de conferencias');