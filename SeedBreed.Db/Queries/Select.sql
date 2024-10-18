SELECT [p].[PlantId], [p].[PlantDate], [p].[HarvestDate], [p].[HarvestInGrams], [p].[GerminateId], [p].[CloneId], [p].[Gifted], [g].[GerminateId], [g].[BatchId], [c].[CloneId], [b].[SeedId],s.Strain
	FROM Padawans.Plant p 
		LEFT JOIN Younglings.Germinate g 
			on p.GerminateId = g.GerminateId 
		LEFT JOIN Younglings.Clone c
			on p.CloneId = c.CloneId 
		LEFT JOIN Seedlings.Batch b 
			on b.BatchId = g.BatchId
		LEFT JOIN Seedlings.Seed S 
			on b.SeedId = s.SeedId