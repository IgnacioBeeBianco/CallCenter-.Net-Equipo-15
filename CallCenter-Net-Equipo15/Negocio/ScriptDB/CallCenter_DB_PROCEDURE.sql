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
        INSERT INTO Cuenta (email, password_, id_rol) VALUES(@email, @password_, @id_rol)

        DECLARE @cuenta_id INT
        SET @cuenta_id = SCOPE_IDENTITY()

        INSERT INTO Usuario (nombre, apellido, dni, domicilio, telefono, genero, cuenta_id)
        VALUES (@nombre, @apellido, @dni, @domicilio, @telefono, @genero, @cuenta_id)

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        RAISERROR('Error al dar de alta el usuario', 1,2)
    END CATCH

END 

GO

CREATE PROCEDURE SP_UpdatePerfil(
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
        UPDATE Usuario 
        SET nombre = @nombre, 
            apellido = @apellido, 
            dni = @dni, 
            domicilio = @domicilio, 
            telefono = @telefono, 
            genero = @genero 
        WHERE id = @id;

        UPDATE Cuenta 
        SET email = @email, 
            password_ = @password_, 
            id_rol = @id_rol 
        WHERE id = (SELECT cuenta_id FROM Usuario WHERE id = @id);
    
        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        RAISERROR('Error al actualizar el perfil', 16,1);
    END CATCH
END
