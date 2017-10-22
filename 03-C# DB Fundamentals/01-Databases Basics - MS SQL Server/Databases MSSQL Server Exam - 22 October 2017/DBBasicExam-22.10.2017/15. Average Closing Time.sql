SELECT [Name] AS [Department Name],
       CASE
	   WHEN AVG(Duration) > 1
	   THEN CAST(AVG(Duration) AS NVARCHAR(10))
	   ELSE 'no info'
	   END AS 'Average Duration'
  FROM (
  SELECT d.[Name],
       (
			SELECT DATEDIFF(DAY, OpenDate, CloseDate)
			FROM Reports
			WHERE CloseDate IS NOT NULL AND Id = r.Id
		) AS Duration
  FROM Departments AS d
LEFT JOIN Categories AS c
ON c.DepartmentId = d.Id
JOIN Reports AS r
ON r.CategoryId = c.Id) AS Temp
GROUP BY [Name]
ORDER BY [Name]