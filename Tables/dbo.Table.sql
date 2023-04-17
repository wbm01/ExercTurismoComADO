CREATE TABLE [dbo].[Client]
(
	[Id_Client] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name_Client] VARCHAR(50) NULL, 
    [Phone] VARCHAR(50) NULL, 
    [Id_Address_Client] INT NULL, 
    [DtRegister_Client] DATETIME NULL, 
    CONSTRAINT [FK_Client_Address] FOREIGN KEY ([Id_Address_Client]) REFERENCES [dbo].[Address]([Id_Address])
)
