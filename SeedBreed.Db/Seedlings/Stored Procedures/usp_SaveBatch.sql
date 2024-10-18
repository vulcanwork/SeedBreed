-- =============================================
-- Author:		JVawter
-- Create date: 7-3-2024
-- Description:	
-- =============================================
CREATE PROCEDURE Seedlings.usp_SaveBatch 
	@batchId int 
	,@sourceId int
	,@spawnId int
	,@isPurchased bit
	,@originalQuantity int
	,@quantityRemaining int
	,@seedId int
	,@purchaseDate datetime2
AS
BEGIN
	SET NOCOUNT ON;

	IF @batchId = 0 AND @spawnId > 0
		INSERT INTO [Seedlings].[Batch]
			   ([SourceId]
			   ,[IsPurchased]
			   ,[OriginalQuantity]
			   ,[QuantityRemaining]
			   ,[SeedId]
			   ,[PurchaseDate]
			   ,[SpawnId])
		 VALUES
			   (@sourceId
			   ,@isPurchased
			   ,@originalQuantity
			   ,@quantityRemaining
			   ,@seedId
			   ,@purchaseDate
			   ,@spawnId)
	ELSE IF @batchId = 0
	INSERT INTO [Seedlings].[Batch]
			   ([SourceId]
			   ,[IsPurchased]
			   ,[OriginalQuantity]
			   ,[QuantityRemaining]
			   ,[SeedId]
			   ,[PurchaseDate])
		 VALUES
			   (@sourceId
			   ,@isPurchased
			   ,@originalQuantity
			   ,@quantityRemaining
			   ,@seedId
			   ,@purchaseDate)
	ELSE if @spawnId > 0
		UPDATE [Seedlings].[Batch]
		   SET [SourceId] = @sourceId
			  ,[IsPurchased] = @isPurchased
			  ,[OriginalQuantity] = @originalQuantity
			  ,[QuantityRemaining] = @quantityRemaining
			  ,[SeedId] = @seedId
			  ,[PurchaseDate] = @purchaseDate
			  ,[SpawnId] = @spawnId
		 WHERE BatchId = @batchId
	ELSE
		UPDATE [Seedlings].[Batch]
		   SET [SourceId] = @sourceId
			  ,[IsPurchased] = @isPurchased
			  ,[OriginalQuantity] = @originalQuantity
			  ,[QuantityRemaining] = @quantityRemaining
			  ,[SeedId] = @seedId
			  ,[PurchaseDate] = @purchaseDate
		 WHERE BatchId = @batchId

END