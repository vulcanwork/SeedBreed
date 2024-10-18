CREATE TABLE [Spawns].[Pollen]
(
	[PollenId] INT NOT NULL IDENTITY PRIMARY KEY,
	[PlantId] INT NOT NULL, 
    CONSTRAINT [FK_Pollen_PlantId] FOREIGN KEY ([PlantId]) REFERENCES [Padawans].[Plant]([PlantId]),	

)
