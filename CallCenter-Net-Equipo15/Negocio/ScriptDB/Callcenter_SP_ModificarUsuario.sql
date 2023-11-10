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