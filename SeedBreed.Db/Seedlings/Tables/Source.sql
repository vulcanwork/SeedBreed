CREATE TABLE [Seedlings].[Source] (
    [SourceId] INT             IDENTITY (1, 1) NOT NULL,
    [Source]   NVARCHAR (100)  NOT NULL,
    [Website]  NVARCHAR (1000) NULL,
    [Rating]   INT             NULL,
    PRIMARY KEY CLUSTERED ([SourceId] ASC)
);



