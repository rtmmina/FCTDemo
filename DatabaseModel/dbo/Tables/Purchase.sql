CREATE TABLE [dbo].[Purchase]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), --Primary key would create clustered index by default.
	[UserID] INT NOT NULL,
	[ProductID] INT NOT NULL,
	FOREIGN KEY (UserID) REFERENCES Customer(ID),
	FOREIGN KEY (ProductID) REFERENCES Product(ID)
)
