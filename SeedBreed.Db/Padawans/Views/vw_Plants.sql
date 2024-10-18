CREATE VIEW [Padawans].[vw_Plants]
	AS
	SELECT [p].[PlantId], [p].[PlantDate], [p].[HarvestDate], [p].[HarvestInGrams],[p].[Gifted],  [g].[GerminationDate], [g].[DidNotGerminate], [c].[CloneId], [c].[GerminateId], [c].[CloneDate], [c].[CloneRate], [c].[Quantity], [b].[BatchId], [b].[SourceId], [b].[IsPurchased], [b].[OriginalQuantity], [b].[QuantityRemaining],  [b].[PurchaseDate], [b].[SpawnId], [S].[SeedId], [S].[Strain], [S].[IndicaPercentage], [S].[SativaPercentage], [S].[THCPercentage], [S].[IsMedical], [S].[IsFeminized]
	FROM Padawans.Plant p 
		LEFT JOIN Younglings.Germinate g 
			on p.GerminateId = g.GerminateId 
		LEFT JOIN Younglings.Clone c
			on p.CloneId = c.CloneId 
		LEFT JOIN Seedlings.Batch b 
			on b.BatchId = g.BatchId
		LEFT JOIN Seedlings.Seed S 
			on b.SeedId = s.SeedId