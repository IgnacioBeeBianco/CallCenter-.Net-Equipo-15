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