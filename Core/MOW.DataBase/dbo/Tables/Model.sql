CREATE TABLE [dbo].[Model] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [BrandID] INT            NULL,
    [ArName]  NVARCHAR (200) NULL,
    [EnName]  NVARCHAR (200) NULL,
    CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Model_Brand] FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brand] ([ID])
);

