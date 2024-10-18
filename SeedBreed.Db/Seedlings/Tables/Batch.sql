CREATE TABLE [Seedlings].[Batch] (
    [BatchId]           INT           IDENTITY (1, 1) NOT NULL,
    [SourceId]          INT           NOT NULL,
    [IsPurchased]       BIT           DEFAULT ((1)) NOT NULL,
    [OriginalQuantity]  INT           NOT NULL,
    [QuantityRemaining] INT           NULL,
    [SeedId]            INT           NOT NULL,
    [PurchaseDate]      DATETIME2 (7) NULL,
    [SpawnId]		  INT           NULL,
    PRIMARY KEY CLUSTERED ([BatchId] ASC),
    CONSTRAINT [FK_Batch_Seed] FOREIGN KEY ([SeedId]) REFERENCES [Seedlings].[Seed] ([SeedId]),
    CONSTRAINT [FK_Batch_Source] FOREIGN KEY ([SourceId]) REFERENCES [Seedlings].[Source] ([SourceId]),
    CONSTRAINT [FK_Batch_Inbreed] FOREIGN KEY ([SpawnId]) REFERENCES [Spawns].[Spawn] ([SpawnId])
);

