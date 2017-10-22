SELECT d.[Name] AS [Department Name], 
       c.[Name] AS [Category Name],
	   CAST(ROUND(
	   (COUNT(*) / 
	   CAST(
	   (
			SELECT COUNT(*) FROM Reports AS r
			JOIN Categories AS c
			ON c.Id = r.CategoryId
			WHERE DepartmentId = d.Id
			GROUP BY DepartmentId
		) AS DECIMAL(15, 2)) * 100), 0) AS INT) AS [Percentage]
 FROM Departments AS d
JOIN Categories AS c
ON c.DepartmentId = d.Id
JOIN Reports AS r
ON r.CategoryId = c.Id
GROUP BY d.Id, d.Name, c.Id, c.Name
ORDER BY [Department Name], [Category Name], [Percentage]
