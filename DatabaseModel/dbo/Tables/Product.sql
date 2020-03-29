CREATE TABLE [dbo].[Product]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), --Primary key would create clustered index by default.
	[Name] VARCHAR(50) NOT NULL UNIQUE, --don't allow duplicates, and the front end would take care of leading and trailing spaces.
	[Description] VARCHAR(1024) -- Allowing no description.
)