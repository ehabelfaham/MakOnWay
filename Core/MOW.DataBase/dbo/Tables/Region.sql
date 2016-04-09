CREATE TABLE [dbo].[Region] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [CityID] INT            NULL,
    [ArName] NVARCHAR (200) NULL,
    [EnName] NVARCHAR (200) NULL,
    CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED ([ID] ASC)
);

