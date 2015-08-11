USE WorldGen
GO
IF (EXISTS (SELECT name FROM sysobjects WHERE (name = N'AdjectiveAdd') AND (TYPE = 'P')))
	DROP PROCEDURE w.AdjectiveAdd
GO
CREATE PROCEDURE w.AdjectiveAdd
	@Words AdjectiveList READONLY
AS
	-- WITH ENCRYPTION ON AS
	SET NOCOUNT ON;
	BEGIN TRANSACTION;
	SET XACT_ABORT ON;
	BEGIN TRY
		---
		INSERT INTO w.Adjectives
		(Name)
		SELECT Name FROM @Words;
		---
		-- EXEC SOMETHING?
		---
		COMMIT;
	END TRY
	BEGIN CATCH
		IF XACT_STATE() = -1 ROLLBACK;
		DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
		SET @ErrorMessage = CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();
		SET @ErrorSeverity = ERROR_SEVERITY();
		SET @ErrorState = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
		-- EXEC SOMETHING?
	END CATCH;
GO