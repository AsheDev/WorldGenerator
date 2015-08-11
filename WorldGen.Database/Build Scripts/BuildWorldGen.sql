USE MASTER
ALTER DATABASE WorldGen SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
DROP DATABASE WorldGen
GO
CREATE DATABASE WorldGen
GO
USE WorldGen
GO
CREATE SCHEMA [w]
GO
SET NOCOUNT ON
GO
-- needed to manually create login "Generator_Engine" with password 1234
CREATE USER Generator_Engine FOR LOGIN Generator_Engine
GO
ALTER USER Generator_Engine WITH DEFAULT_SCHEMA = [o]
GO
ALTER ROLE [db_owner] ADD MEMBER [Generator_Engine] -- set Generator_Engine as db_owner



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





-- STORED PROCEDURES

r: "C:\Users\Michael\Documents\Visual Studio 2013\Projects\WorldGenerator\WorldGen.Database\Stored Procedures\spAdjectiveAdd.sql"