SELECT u.Username AS Username,
       g.[Name] AS Game,
	   MAX(c.[Name]) AS [Character],
	   SUM([is].Strength) + MAX(gts.Strength) + MAX(cs.Strength) AS Strength,
	   SUM([is].Defence) + MAX(gts.Defence) + MAX(cs.Defence) AS Defence,
	   SUM([is].Speed) + MAX(gts.Speed) + MAX(cs.Speed) AS Speed,
	   SUM([is].Mind) + MAX(gts.Mind) + MAX(cs.Mind) AS Mind,
	   SUM([is].Luck) + MAX(gts.Luck) + MAX(cs.Luck) AS Luck
  FROM UsersGames AS ug
JOIN Characters AS c
ON c.Id = ug.CharacterId
JOIN [Statistics] AS cs
ON cs.Id = c.StatisticId
JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN Items AS i
ON i.Id = ugi.ItemId
JOIN [Statistics] AS [is]
ON [is].Id = i.StatisticId
JOIN Games AS g
ON g.Id = ug.GameId
JOIN GameTypes AS gt
ON gt.Id = g.GameTypeId
JOIN [Statistics] AS gts
ON gts.Id = gt.BonusStatsId
JOIN Users AS u
ON u.Id = ug.UserId
GROUP BY u.Username, g.[Name]
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC