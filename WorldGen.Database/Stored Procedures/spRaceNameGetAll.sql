USE WorldGen
GO
IF (EXISTS (SELECT name FROM sysobjects WHERE (name = N'RaceNameGetAll') AND (TYPE = 'P')))
	DROP PROCEDURE w.RaceNameGetAll
GO
CREATE PROCEDURE w.RaceNameGetAll
	@RaceId INT,
	@HasPrestige BIT = NULL -- don't know what I want to do with this yet
AS
	SET NOCOUNT ON;
	---
	SELECT Id, FK_RaceId, Name, Masculine, HasPrestige
	FROM w.RaceNames
	WHERE FK_RaceId = @RaceId;
GO