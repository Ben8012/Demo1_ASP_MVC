CREATE TABLE [dbo].[Contact] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [LastName]  VARCHAR (255) NOT NULL,
    [FirstName] VARCHAR (255) NOT NULL,
    [Email]     VARCHAR (255) NOT NULL,
    [SurName]   VARCHAR (255) NULL,
    [Phone]     VARCHAR (255) NOT NULL,
    [Birthdate] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

