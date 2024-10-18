CREATE TABLE [Spawns].[Spawn]
(
	[SpawnId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Hybrid] BIT NOT NULL,
	[Direct] BIT NOT NULL,
	[InBreed] BIT NOT NULL,
	[PlantId] INT NOT NULL, 
	[PollenId] INT NOT NULL,
	CONSTRAINT [FK_Hybrid_Pollen] FOREIGN KEY ([PollenId]) REFERENCES [Spawns].[Pollen]([PollenId]),
	CONSTRAINT [FK_Hybrid_Plant] FOREIGN KEY ([PlantId]) REFERENCES [Padawans].[Plant]([PlantId]),
)

