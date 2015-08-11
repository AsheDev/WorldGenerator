USE WorldGen
GO
IF (EXISTS (SELECT name FROM sysobjects WHERE (name = N'RaceNameGet') AND (TYPE = 'P')))
	DROP PROCEDURE w.RaceNameGet
GO
CREATE PROCEDURE w.RaceNameGet
	@Id INT
AS
	SET NOCOUNT ON;
	---

GO