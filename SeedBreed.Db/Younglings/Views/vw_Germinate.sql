CREATE VIEW [Younglings].[vw_Germinate]
	AS
	Select [g].[GerminateId],[g].[GerminationDate], [g].[DidNotGerminate], [b].[BatchId], [b].[SourceId], [b].[IsPurchased], [b].[OriginalQuantity], [b].[QuantityRemaining],  [b].[PurchaseDate], [b].[SpawnId], [s].[SeedId], [s].[Strain], [s].[IndicaPercentage], [s].[SativaPercentage], [s].[THCPercentage], [s].[IsMedical], [s].[IsFeminized] 
		From Younglings.Germinate g
			join Seedlings.Batch b 
				on g.BatchId = b.BatchId 
			join Seedlings.Seed s 
				on s.SeedId = b.SeedId
