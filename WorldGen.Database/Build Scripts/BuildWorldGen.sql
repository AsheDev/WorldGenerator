USE MASTER
ALTER DATABASE DevWorldGen SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE DevWorldGen
CREATE DATABASE DevWorldGen
USE DevWorldGen
GO
CREATE SCHEMA [w]
GO
SET NOCOUNT ON
---
IF NOT EXISTS (SELECT loginname FROM master.dbo.syslogins WHERE name = 'WorldGen_Engine')
BEGIN
	DECLARE @CreateLogin NVARCHAR(256) = 'CREATE LOGIN WorldGen_Engine WITH PASSWORD = ''1234'', DEFAULT_DATABASE = DevWorldGen, DEFAULT_LANGUAGE = us_english, CHECK_POLICY = OFF';
	EXEC sp_executesql @CreateLogin
END
---



-- races
-- civilizations
-- adjectives
IF (NOT EXISTS (SELECT * FROM sysobjects WHERE (name = N'Races') AND (TYPE = 'U')))
BEGIN
	CREATE TABLE w.Races (
		Id					INT IDENTITY(1,1) PRIMARY KEY,
		Name				NVARCHAR(256) NOT NULL,
		[Description]		NVARCHAR(256) NOT NULL,
		IsActive			BIT DEFAULT 1
	);
END
GO

IF (NOT EXISTS (SELECT * FROM sysobjects WHERE (name = N'RaceNames') AND (TYPE = 'U')))
BEGIN
	CREATE TABLE w.RaceNames (
		Id					INT IDENTITY(1,1) PRIMARY KEY,
		FK_RaceId			INT FOREIGN KEY REFERENCES w.Races(Id),
		Name				NVARCHAR(256) NOT NULL,
		Masculine			BIT,
		HasPrestige			BIT DEFAULT 0 -- this will be established somehow (a great king or something)
	);
END
GO

IF (NOT EXISTS (SELECT * FROM sysobjects WHERE (name = N'LocationNames') AND (TYPE = 'U')))
BEGIN
	CREATE TABLE w.LocationNames (
		Id					INT IDENTITY(1,1) PRIMARY KEY,
		FK_RaceId			INT FOREIGN KEY REFERENCES w.Races(Id),
		Name				NVARCHAR(256) NOT NULL
	);
END
GO

IF (NOT EXISTS (SELECT * FROM sysobjects WHERE (name = N'DeityNames') AND (TYPE = 'U')))
BEGIN
	CREATE TABLE w.DeityNames (
		Id					INT IDENTITY(1,1) PRIMARY KEY,
		Name				NVARCHAR(256) NOT NULL
	);
END
GO

IF (NOT EXISTS (SELECT * FROM sysobjects WHERE (name = N'PartsOfSpeech') AND (TYPE = 'U')))
BEGIN
	CREATE TABLE w.PartsOfSpeech (
		Id							INT IDENTITY(1,1) PRIMARY KEY,
		PartOfSpeech				NVARCHAR(256), -- verb, noun, adjective...
		[Description]				NVARCHAR(256)
	);
END
GO

IF (NOT EXISTS (SELECT * FROM sysobjects WHERE (name = N'Adjectives') AND (TYPE = 'U')))
BEGIN
	CREATE TABLE w.Adjectives (
		Id					INT IDENTITY(1,1) PRIMARY KEY,
		Name				NVARCHAR(256) NOT NULL
	);
END
GO

IF (NOT EXISTS (SELECT * FROM sysobjects WHERE (name = N'Traits') AND (TYPE = 'U')))
BEGIN
	CREATE TABLE w.Traits (
		Id					INT IDENTITY(1,1) PRIMARY KEY,
		Name				NVARCHAR(256) NOT NULL,
		Positive			BIT DEFAULT 1
	);
END
GO

--- Below entries are mostly for adding names in bulk ---

IF EXISTS (SELECT name FROM sys.types WHERE name = N'RaceNameList')
	DROP TYPE RaceNameList
CREATE TYPE RaceNameList AS TABLE (
		FK_RaceId			INT,
		Name				NVARCHAR(256),
		Masculine			BIT
);

IF EXISTS (SELECT name FROM sys.types WHERE name = N'DeityNameList')
	DROP TYPE DeityNameList
CREATE TYPE DeityNameList AS TABLE (
		Name				NVARCHAR(256)
);

IF EXISTS (SELECT name FROM sys.types WHERE name = N'TraitList')
	DROP TYPE TraitList
CREATE TYPE TraitList AS TABLE (
		Name				NVARCHAR(256)
);

IF EXISTS (SELECT name FROM sys.types WHERE name = N'AdjectiveList')
	DROP TYPE AdjectiveList
CREATE TYPE AdjectiveList AS TABLE (
		Name				NVARCHAR(256)
);

IF EXISTS (SELECT name FROM sys.types WHERE name = N'LocationList')
	DROP TYPE LocationList
CREATE TYPE LocationList AS TABLE (
		FK_RaceId			INT,
		Name				NVARCHAR(256)
);

--*************--
INSERT INTO w.PartsOfSpeech
(PartOfSpeech, [Description])
VALUES
('Verb', 'An action or state'),
('Noun', 'A thing or person'),
('Adjective', 'Describes a noun'),
('Adverb', 'Describes an a verb, adjective, or an adverb'),
('Pronoun', 'Replaces a noun'),
('Conjunction', 'Join clauses, or sentences, or words'),
('Preposition', 'Links a noun to another word'),
('Interjection', 'A short exclamation that can also be inserted into a sentence');

-- STORED PROCEDURES
:r C:\Users\"Michael Ovies"\Source\Repos\WorldGenerator\WorldGen.Database\"Stored Procedures"\spAdjectiveAdd.sql
:r C:\Users\"Michael Ovies"\Source\Repos\WorldGenerator\WorldGen.Database\"Stored Procedures"\spRaceNameGet.sql
:r C:\Users\"Michael Ovies"\Source\Repos\WorldGenerator\WorldGen.Database\"Stored Procedures"\spRaceNameGetAll.sql
:r C:\Users\"Michael Ovies"\Source\Repos\WorldGenerator\WorldGen.Database\"Stored Procedures"\spRaceNameAdd.sql