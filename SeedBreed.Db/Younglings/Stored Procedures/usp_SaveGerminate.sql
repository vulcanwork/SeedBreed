CREATE PROCEDURE [Younglings].[usp_SaveGerminate]
	@germinateId int,
	@batchId int,
	@germinationDate datetime2,
	@didNotGerminate bit
AS
BEGIN

	SET NOCOUNT ON;

	If @germinateId = 0
		INSERT INTO [Younglings].[Germinate]
				   ([BatchId]
				   ,[GerminationDate]
				   ,[DidNotGerminate])
			 VALUES
				   (@batchId
				   ,@germinationDate
				   ,@didNotGerminate)
	ELSE
		UPDATE [Younglings].[Germinate]
			   SET [BatchId] = @batchId
				  ,[GerminationDate] = @germinationDate
				  ,[DidNotGerminate] = @didNotGerminate
			 WHERE GerminateId = @germinateId
	UPDATE [Seedlings].[Batch]
		Set QuantityRemaining = QuantityRemaining - 1
	Where BatchId = @batchId

END
