CREATE TRIGGER TR_Eliminar_Usuario ON Usuario
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @ID_Cuenta INT = (SELECT cuenta_id FROM deleted)
    
    DELETE FROM Cuenta WHERE id = @ID_Cuenta;
    DELETE FROM Usuario WHERE id in (SELECT id FROM deleted)
END