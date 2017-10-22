SELECT [Category Name],
       Waitings + InProgress AS [Reports Number],
	   CASE
	   WHEN Waitings > InProgress
	   THEN 'waiting'
	   WHEN Waitings < InProgress
	   THEN 'in progress'
	   ELSE 'equal'
	   END AS [Main Status]
  FROM
(SELECT c.[Name] AS [Category Name], 
       COUNT(CASE WHEN StatusId = 1 THEN 1 ELSE NULL END) AS [Waitings],
       COUNT(CASE WHEN StatusId = 2 THEN 1 ELSE NULL END) AS [InProgress]
  FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE StatusId IN (
	SELECT Id 
	  FROM [Status] 
	 WHERE Label IN ('waiting', 'in progress')
)
GROUP BY r.CategoryId, c.[Name]) AS Temp
ORDER BY [Category Name], [Reports Number], [Main Status]