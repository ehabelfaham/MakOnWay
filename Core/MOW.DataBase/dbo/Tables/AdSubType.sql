CREATE TABLE [dbo].[AdSubType] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [ArName] NVARCHAR (200) NULL,
    [EnName] NVARCHAR (200) NULL,
    CONSTRAINT [PK_AdSubType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

