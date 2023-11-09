CREATE TRIGGER TR_DesactivarUsuario ON Usuario
INSTEAD OF DELETE 
AS
BEGIN
    BEGIN TRANSACTION

    BEGIN TRY
        UPDATE Usuario SET Estado = 0 WHERE id = (SELECT id FROM deleted)

        COMMIT TRANSACTION
    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION
        RAISERROR('Error al desactivar el usuario',  5, 1)
    END CATCH

END
