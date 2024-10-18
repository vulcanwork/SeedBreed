CREATE VIEW [Seedlings].[vw_Batches]
	AS Select [b].[BatchId], [b].[SourceId], [b].[IsPurchased], [b].[OriginalQuantity], [b].[QuantityRemaining], [b].[SeedId], [b].[PurchaseDate], [b].[SpawnId],  [so].[Source], [so].[Website], [so].[Rating], [s].[Strain], [s].[IndicaPercentage], [s].[SativaPercentage], [s].[THCPercentage], [s].[IsMedical], [s].[IsFeminized] 
		From Seedlings.Batch b 
			join Seedlings.Source so 
				on so.SourceId = b.SourceId 
			join Seedlings.Seed s 
				on s.SeedId = b.SeedId
