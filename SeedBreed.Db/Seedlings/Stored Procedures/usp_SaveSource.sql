-- =============================================
-- Author:		JVawter
-- Create date: 7-2-2024
-- Description:	
-- =============================================
CREATE PROCEDURE [Seedlings].[usp_SaveSource]
	@sourceId int , 
	@source nvarchar(100),
	@website nvarchar(1000),
	@rating int
AS
BEGIN

	SET NOCOUNT ON;
	If @sourceId = 0

		INSERT INTO [Seedlings].[Source]
				   ([Source]
				   ,[Website]
				   ,[Rating])
			 VALUES
				   (@source
				   ,@website
				   ,@rating)
	ELSE
		UPDATE [Seedlings].[Source]
		   SET [Source] = @source
			  ,[Website] = @website
			  ,[Rating] = @rating
		 WHERE SourceId = @sourceId

END
