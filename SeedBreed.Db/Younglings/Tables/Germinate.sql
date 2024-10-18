CREATE TABLE [Younglings].[Germinate] (
    [GerminateId]     INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]          INT            NOT NULL,
    [GerminationDate] DATETIME       NOT NULL,
    [DidNotGerminate] DECIMAL (5, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([GerminateId] ASC), 
    CONSTRAINT [FK_Germinate_Batch] FOREIGN KEY ([BatchId]) REFERENCES [Seedlings].[Batch]([BatchId])
);

