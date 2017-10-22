SELECT 
	   CONCAT(FirstName, ' ', LastName) AS [Name],
	   CONCAT(COUNT(r.CloseDate), '/', COUNT(
	   CASE
	   WHEN OpenDate IS NOT NULL AND CloseDate IS NULL
	   THEN 1
	   ELSE 0
	   END
	   )) AS [Closed Open Reports]
  FROM Employees AS e
JOIN Reports AS r
ON r.EmployeeId = e.Id
WHERE (DATEPART(YEAR, OpenDate) = 2016 AND CloseDate IS NULL)
   OR (DATEPART(YEAR, OpenDate) <= 2016 AND DATEPART(YEAR, CloseDate) = 2016)
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY [Name], e.Id