CREATE TABLE [dbo].[Hotel]
(
	[Id_Hotel] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name_Hotel] VARCHAR(50) NULL, 
    [Id_Address_Hotel] INT NULL, 
    [DtRegister_Hotel] DATETIME NULL, 
    [Hotel_Value] DECIMAL NULL, 
    CONSTRAINT [FK_Hotel_Address] FOREIGN KEY ([Id_Address_Hotel]) REFERENCES [dbo].[Address]([Id_Address])
)
