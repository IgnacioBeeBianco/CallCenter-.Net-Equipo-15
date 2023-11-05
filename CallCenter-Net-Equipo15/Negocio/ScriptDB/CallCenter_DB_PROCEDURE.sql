USE Callcenter
GO
CREATE PROCEDURE insertarNuevaCuentaCliente
@email VARCHAR(50), @password VARCHAR(50)
AS
INSERT INTO Cuenta (email, password_, id_rol) OUTPUT INSERTED.id
VALUES (@email, @password,(SELECT id FROM Rol WHERE nombre = 'Cliente'))

GO

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

    INSERT INTO Cuenta (email, password_, id_rol)
    SELECT @email, @password_, id
    FROM Rol
    WHERE nombre = 'Cliente'

    DECLARE @cuenta_id INT
    SET @cuenta_id = SCOPE_IDENTITY()

    INSERT INTO Usuario (nombre, apellido, dni, domicilio, telefono, genero, cuenta_id)
    VALUES (@nombre, @apellido, @dni, @domicilio, @telefono, @genero, @cuenta_id)
END