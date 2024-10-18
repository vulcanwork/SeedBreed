CREATE PROCEDURE [dbo].[usp_SaveSpawn]
	@spawnId int,
	@hybrid bit,
	@direct bit,
	@inBreed bit,
	@plantId int,
	@pollenId int
AS
BEGIN
SET NOCOUNT ON;
	If @spawnId = 0
		INSERT INTO [Spawns].[Spawn]
					([Hybrid]
					,[Direct]
					,[InBreed]
					,[PlantId]
					,[PollenId])
				VALUES( @hybrid
					,@direct
					,@inBreed
					,@plantId
					,@pollenId)
	ELSE
		UPDATE [Spawns].[Spawn]
				SET [Hybrid] = @hybrid
					,[Direct] = @direct
					,[InBreed] = @inBreed
					,[PlantId] = @plantId
					,[PollenId] = @pollenId
				WHERE SpawnId = @spawnId
END
RETURN 0
