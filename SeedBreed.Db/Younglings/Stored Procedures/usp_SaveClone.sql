CREATE PROCEDURE [Younglings].[usp_SaveClone]
	@cloneId int,
	@germinateId int,
	@cloneDate datetime2,
	@Quantity int
AS
BEGIN
	SET NOCOUNT ON;
		If @cloneId = 0
			INSERT INTO [Younglings].[Clone]
					   ([GerminateId]
					   ,[CloneDate]
					   ,[Quantity])
				 VALUES
					   (@germinateId
					   ,@cloneDate
					   ,@Quantity)
		ELSE
			UPDATE [Younglings].[Clone]
				   SET [GerminateId] = @germinateId
					  ,[CloneDate] = @cloneDate
					  ,[Quantity] = @Quantity
				 WHERE CloneId = @cloneId
	END