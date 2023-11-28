USE Callcenter
GO
--USAR POR SI YA ESTA CREADO EL SP ANTERIOR:
--DROP PROCEDURE InsertarClienteYAsociarCuenta
--DROP PROCEDURE insertarNuevaCuentaCliente --(Por si tenian este que ya no se usa)
CREATE PROCEDURE InsertarClienteYAsociarCuenta
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @dni VARCHAR(8),
    @domicilio VARCHAR(100),
    @telefono VARCHAR(10),
    @genero CHAR,
    @email VARCHAR(300),
    @password_ VARCHAR(300)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        INSERT INTO Cuenta (email, password_, id_rol, estado)
        SELECT @email, @password_, (SELECT id FROM Rol WHERE nombre = 'Cliente'), 1

        DECLARE @cuenta_id INT
        SET @cuenta_id = SCOPE_IDENTITY()

        INSERT INTO Usuario (nombre, apellido, dni, domicilio, telefono, genero, cuenta_id, estado)
        VALUES (@nombre, @apellido, @dni, @domicilio, @telefono, @genero, @cuenta_id, 1)

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH
END

GO

CREATE PROCEDURE SP_CrearUsuario(
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @dni VARCHAR(8),
    @domicilio VARCHAR(100),
    @telefono VARCHAR(10),
    @genero CHAR,
    @email VARCHAR(300),
    @password_ VARCHAR(300),
    @id_rol INT
)
AS 
BEGIN 
    BEGIN TRANSACTION

    BEGIN TRY
        INSERT INTO Cuenta (email, password_, id_rol, estado) VALUES(@email, @password_, @id_rol, 1)

        DECLARE @cuenta_id INT
        SET @cuenta_id = SCOPE_IDENTITY()

        INSERT INTO Usuario (nombre, apellido, dni, domicilio, telefono, genero, cuenta_id, estado)
        VALUES (@nombre, @apellido, @dni, @domicilio, @telefono, @genero, @cuenta_id, 1)

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        RAISERROR('Error al dar de alta el usuario', 1,2)
    END CATCH

END 

GO

CREATE PROCEDURE SP_ModificarUsuario(
    @id INT,
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @dni VARCHAR(8),
    @domicilio VARCHAR(100),
    @telefono VARCHAR(10),
    @genero CHAR,
    @email VARCHAR(300),
    @password_ VARCHAR(300),
    @id_rol INT
)
AS 
BEGIN 
    BEGIN TRANSACTION

    BEGIN TRY
        UPDATE Usuario SET nombre = @nombre, apellido = @apellido, dni = @dni, domicilio = @domicilio, telefono = @telefono, genero = @genero WHERE id = @id
        DECLARE @cuenta_id INT = (SELECT cuenta_id FROM Usuario WHERE dni = @dni)

        UPDATE Cuenta SET email = @email, password_ = @password_, id_rol = @id_rol WHERE id = @cuenta_id
    
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        RAISERROR('Error al modificar el usario', 1,2)
    END CATCH

END 

GO
--DROP PROCEDURE SP_CrearIncidencia
CREATE PROCEDURE SP_CrearIncidencia
    @creador_id INT,
    @asignado_id INT,
    @fechaCreacion DATETIME,
    @fechaCambio DATETIME,
    @estado_id INT,
    @prioridad_id INT,
    @tipo_incidencia_id INT,
    @comentario_cierra NVARCHAR(300),
    @problematica NVARCHAR(500)
AS
BEGIN
    BEGIN TRANSACTION

    BEGIN TRY
    INSERT INTO Incidencia (creador_id, asignado_id, fecha_creacion, fecha_ultimo_cambio, estado_id, prioridad_id, tipo_incidencia_id, comentario_cierra, problematica, estado)
    VALUES
    (
        @creador_id,
        @asignado_id,
        @fechaCreacion,
        @fechaCambio,
        @estado_id,
        @prioridad_id,
        @tipo_incidencia_id,
        @comentario_cierra,
        @problematica,
        1
    )
    COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        RAISERROR('Error al crear incidencia', 1,2)
    END CATCH
END

GO

CREATE PROCEDURE SP_VerificarUsoPrioridad
    @PrioridadId INT
AS
BEGIN
    DECLARE @ExisteUso INT

    SELECT @ExisteUso = COUNT(*)
    FROM Incidencia
    WHERE prioridad_id = @PrioridadId

    IF @ExisteUso = 0
    BEGIN
        UPDATE Prioridad SET estado = 0 WHERE id = @PrioridadId
    END
    ELSE
    BEGIN
        RAISERROR('No se puede realizar la baja lógica. La Prioridad está siendo utilizada en una incidencia.', 16, 1)
    END
END

GO

CREATE PROCEDURE SP_VerificarUsoTipoIncidencia
    @TipoIncidenciaId INT
AS
BEGIN
    DECLARE @ExisteUso INT

    SELECT @ExisteUso = COUNT(*)
    FROM Incidencia
    WHERE tipo_incidencia_id = @TipoIncidenciaId

    IF @ExisteUso = 0
    BEGIN
        UPDATE TipoIncidencia SET estado = 0 WHERE id = @TipoIncidenciaId
    END
    ELSE
    BEGIN
        RAISERROR('No se puede realizar la baja lógica. El Tipo de Incidencia está siendo utilizado en una incidencia.', 16, 1)
    END
END

GO

CREATE PROCEDURE SP_VerificarUsoEstado
    @EstadoId INT
AS
BEGIN
    DECLARE @ExisteUso INT

    SELECT @ExisteUso = COUNT(*)
    FROM Incidencia
    WHERE estado_id = @EstadoId

    IF @ExisteUso = 0
    BEGIN
        UPDATE Estado SET estado = 0 WHERE id = @EstadoId
    END
    ELSE
    BEGIN
        RAISERROR('No se puede realizar la baja lógica. El Estado está siendo utilizado en una incidencia.', 16, 1)
    END
END

GO

CREATE PROCEDURE SP_VerificarUsoUsuario
    @UsuarioId INT
AS
BEGIN
    DECLARE @ExisteUso INT

    SELECT @ExisteUso = COUNT(*)
    FROM Incidencia
    WHERE creador_id = @UsuarioId OR asignado_id = @UsuarioId

    IF @ExisteUso = 0
    BEGIN
        UPDATE Usuario SET estado = 0 WHERE id = @UsuarioId
    END
    ELSE
    BEGIN
        RAISERROR('No se puede realizar la baja lógica. El Usuario está siendo utilizado en una incidencia.', 16, 1)
    END
END

GO

CREATE PROCEDURE SP_VerificarUsoRol
    @RolId INT
AS
BEGIN
    DECLARE @ExisteUso INT

    SELECT @ExisteUso = COUNT(*)
    FROM Cuenta
    WHERE id_rol = @RolId

    IF @ExisteUso = 0
    BEGIN
        UPDATE Rol SET estado = 0 WHERE id = @RolId
    END
    ELSE
    BEGIN
        RAISERROR('No se puede realizar la baja lógica. El Rol está siendo utilizado en una incidencia.', 16, 1)
    END
END