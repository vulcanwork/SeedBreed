CREATE TABLE [Padawans].[Plant] (
    [PlantId]        INT           IDENTITY (1, 1) NOT NULL,
    [PlantDate]      DATETIME2 (7) NULL,
    [HarvestDate]    DATETIME2 (7) NULL,
    [HarvestInGrams] INT           NULL,
    [GerminateId]    INT           NULL,
    [CloneId]        INT           NULL,
    [Gifted]         BIT           NULL,
    PRIMARY KEY CLUSTERED ([PlantId] ASC),
    CONSTRAINT [FK_Plant_Clone] FOREIGN KEY ([CloneId]) REFERENCES [Younglings].[Clone] ([CloneId]),
    CONSTRAINT [FK_Plant_Germenate] FOREIGN KEY ([GerminateId]) REFERENCES [Younglings].[Germinate] ([GerminateId])
);

