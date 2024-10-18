CREATE PROCEDURE [Padawans].[usp_SavePlant]
	@plantId int,
	@cloneId int,
	@germinateId int,
	@plantDate datetime2,
	@harvestDate datetime2,
	@harvestInGrams int
AS
BEGIN

	SET NOCOUNT ON;

	If @plantId = 0 AND @germinateId > 0 
		INSERT INTO [Padawans].[Plant]
				   ([GerminateId]
				   ,[PlantDate]
				   ,[HarvestDate]
				   ,[HarvestInGrams])
			 VALUES( @germinateId
				   ,@plantDate
				   ,'1-1-1800'
				   ,@harvestInGrams)
	ELSE If @plantId = 0 AND @cloneId > 0 
		INSERT INTO [Padawans].[Plant]
				   (CloneId
				   ,[PlantDate]
				   ,[HarvestDate]
				   ,[HarvestInGrams])
			 VALUES( @cloneId
				   ,@plantDate
				   ,'1-1-1800'
				   ,@harvestInGrams)
	ELSE If @cloneId > 0
		UPDATE [Padawans].[Plant]
			   SET [CloneId] = @cloneId			
				  ,[PlantDate] = @plantDate
				  ,[HarvestDate] = @harvestDate
				  ,[HarvestInGrams] = @harvestInGrams
			 WHERE PlantId = @plantId
	ELSE If @germinateId > 0
		UPDATE [Padawans].[Plant]
			   SET [GerminateId] = @germinateId			
				  ,[PlantDate] = @plantDate
				  ,[HarvestDate] = @harvestDate
				  ,[HarvestInGrams] = @harvestInGrams
			 WHERE PlantId = @plantId

END
RETURN 0
