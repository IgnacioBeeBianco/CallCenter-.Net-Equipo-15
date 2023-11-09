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

        INSERT INTO Cuenta (email, password_, id_rol)
        SELECT @email, @password_, (SELECT id FROM Rol WHERE nombre = 'Cliente')

        DECLARE @cuenta_id INT
        SET @cuenta_id = SCOPE_IDENTITY()

        INSERT INTO Usuario (nombre, apellido, dni, domicilio, telefono, genero, cuenta_id)
        VALUES (@nombre, @apellido, @dni, @domicilio, @telefono, @genero, @cuenta_id)

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
    END CATCH
END
