CREATE TABLE [Seedlings].[Seed] (
    [SeedId]           INT            IDENTITY (1, 1) NOT NULL,
    [Strain]           NVARCHAR (100) NOT NULL,
    [IndicaPercentage] INT            DEFAULT ((50)) NULL,
    [SativaPercentage] INT            DEFAULT ((50)) NULL,
    [THCPercentage]    INT            NULL,
    [IsMedical]        BIT            DEFAULT ((0)) NULL,
    [IsFeminized]      BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([SeedId] ASC)
);

