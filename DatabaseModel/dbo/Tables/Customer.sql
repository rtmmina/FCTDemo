CREATE TABLE [dbo].[Customer]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), --Primary key would create clustered index by default.
	[Name] VARCHAR(128) NOT NULL,
	[Email] VARCHAR(128) NOT NULL UNIQUE, --front end would remove leading and trailing white spaces.
	[Password] VARCHAR(256) NOT NULL -- Password gets hashed at the backend!
)
