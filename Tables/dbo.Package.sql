CREATE TABLE [dbo].[Package] (
    [Id_Package]          INT          IDENTITY (1, 1) NOT NULL,
    [Id_Hotel_Package]       VARCHAR (50) NULL,
    [Id_Ticket_Package]   INT          NULL,
    [Dt_Register_Package] DATETIME     NULL,
    [Package_Value]       DECIMAL (18) NULL,
    [Id_Client_Package]   INT          NULL,
    PRIMARY KEY CLUSTERED ([Id_Package] ASC), 
    CONSTRAINT [FK_Package_Client] FOREIGN KEY ([Id_Client_Package]) REFERENCES [dbo].[Client]([Id_Client]), 
    CONSTRAINT [FK_Package_Ticket] FOREIGN KEY ([Id_Ticket_Package]) REFERENCES [dbo].[Ticket]([Id_Ticket]), 
    CONSTRAINT [FK_Package_Hotel] FOREIGN KEY ([Id_Hotel_Package]) REFERENCES [dbo].[Hotel]([Id_Hotel])
);

