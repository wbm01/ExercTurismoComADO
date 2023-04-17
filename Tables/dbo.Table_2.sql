CREATE TABLE [dbo].[Ticket]
(
	[Id_Ticket] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Id_Address_Origin] INT NULL, 
    [Id_Address_Destiny] INT NULL, 
    [Id_Client_Ticket] INT NULL, 
    [DtTicket] DATETIME NULL, 
    [Ticket_Value] DECIMAL NULL, 
    CONSTRAINT [FK_Ticket_Client] FOREIGN KEY ([Id_Client_Ticket]) REFERENCES [dbo].[Client]([Id_Client]), 
    CONSTRAINT [FK_Ticket_Address_Origin] FOREIGN KEY ([Id_Address_Origin]) REFERENCES [dbo].[Address]([Id_Address]), 
    CONSTRAINT [FK_Ticket_Address_Destiny] FOREIGN KEY ([Id_Address_Destiny]) REFERENCES [dbo].[Address]([Id_Address])
)
