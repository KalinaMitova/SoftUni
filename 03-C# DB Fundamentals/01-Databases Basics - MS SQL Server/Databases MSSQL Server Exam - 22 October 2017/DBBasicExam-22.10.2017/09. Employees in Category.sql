SELECT c.[Name],
	   COUNT(e.Id)
  FROM Employees AS e
JOIN Departments AS d
ON d.Id = e.DepartmentId
JOIN Categories AS c
ON c.DepartmentId = d.Id
GROUP BY c.Id, c.[Name]
ORDER BY c.Name