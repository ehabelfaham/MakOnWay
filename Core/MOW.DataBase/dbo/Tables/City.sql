CREATE TABLE [dbo].[City] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [CountryID] INT            NULL,
    [ArName]    NVARCHAR (200) NULL,
    [EnName]    NVARCHAR (200) NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_City_Country] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Country] ([ID])
);

