CREATE TABLE [dbo].[Address]
(
	[Id_Address] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Street] VARCHAR(50) NULL, 
    [Number] INT NULL, 
    [Neighborhood] VARCHAR(50) NULL, 
    [Cep] VARCHAR(50) NULL, 
    [Complement] VARCHAR(50) NULL, 
    [Id_City_Address] INT NULL, 
    [DtRegister_Address] DATETIME NULL, 
    CONSTRAINT [FK_Address_City] FOREIGN KEY ([Id_City_Address]) REFERENCES [dbo].[City]([Id_City])
)
