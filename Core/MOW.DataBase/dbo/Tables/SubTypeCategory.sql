CREATE TABLE [dbo].[SubTypeCategory] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [AdSubTypeID] INT            NULL,
    [ArName]      NVARCHAR (200) NULL,
    [EnName]      NVARCHAR (200) NULL,
    CONSTRAINT [PK_SubTypeCategory] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SubTypeCategory_AdSubType] FOREIGN KEY ([AdSubTypeID]) REFERENCES [dbo].[AdSubType] ([ID])
);

