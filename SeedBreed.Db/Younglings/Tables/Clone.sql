CREATE TABLE [Younglings].[Clone] (
    [CloneId]     INT            IDENTITY (1, 1) NOT NULL,
    [GerminateId] INT            NOT NULL,
    [CloneDate]   DATETIME       NOT NULL,
    [CloneRate]   DECIMAL (5, 2) NOT NULL,
    [Quantity]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CloneId] ASC),
    CONSTRAINT [FK_Clone_Germinate] FOREIGN KEY ([GerminateId]) REFERENCES [Younglings].[Germinate] ([GerminateId])
);

