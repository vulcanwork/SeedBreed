-- =============================================
-- Author:		JVawter
-- Create date: 7-2-2024
-- Description:	
-- =============================================
CREATE PROCEDURE [Seedlings].[usp_SaveSeeds] 
	-- Add the parameters for the stored procedure here
	@seedId int , 
	@strain nvarchar(100),
	@indicaPercentage int,
	@sativaPercentage int,
	@thcPercentage int,
	@isMedical bit,
	@isFeminized bit
AS
BEGIN

	SET NOCOUNT ON;
	If @seedId = 0

		INSERT INTO [Seedlings].[Seed]
				   ([Strain]
				   ,[IndicaPercentage]
				   ,[SativaPercentage]
				   ,[THCPercentage]
				   ,[IsMedical]
				   ,[IsFeminized])
			 VALUES
				   (@strain
				   ,@indicaPercentage
				   ,@sativaPercentage
				   ,@thcPercentage
				   ,@isMedical
				   ,@isFeminized)
	ELSE

		UPDATE [Seedlings].[Seed]
		   SET [Strain] = @strain
			  ,[IndicaPercentage] = @indicaPercentage
			  ,[SativaPercentage] = @sativaPercentage
			  ,[THCPercentage] = @thcPercentage
			  ,[IsMedical] = @isMedical
			  ,[IsFeminized] = @isFeminized
		 WHERE  SeedId = @seedId

END
