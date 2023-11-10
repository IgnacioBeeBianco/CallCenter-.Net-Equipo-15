CREATE TRIGGER TR_DesactivarUsuario ON Usuario
INSTEAD OF DELETE
AS 
BEGIN
    BEGIN TRANSACTION

    BEGIN TRY
        UPDATE Usuario SET Estado = 0 WHERE id in (SELECT id from deleted);
        UPDATE Cuenta SET Estado = 0 WHERE id in (SELECT cuenta_id from deleted)

    COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
    ROLLBACK TRANSACTION
    END CATCH

END