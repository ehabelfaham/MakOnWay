CREATE TABLE [dbo].[Country] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [ArName] NVARCHAR (200) NULL,
    [EnName] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([ID] ASC)
);

