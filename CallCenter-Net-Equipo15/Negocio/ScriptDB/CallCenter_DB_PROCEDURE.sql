USE Callcenter
GO
CREATE PROCEDURE insertarNuevaCuentaCliente
@email VARCHAR(50), @password VARCHAR(50)
AS
INSERT INTO Cuenta (email, password_, id_rol) OUTPUT INSERTED.id
VALUES (@email, @password,(SELECT id FROM Rol WHERE nombre = 'Cliente'))