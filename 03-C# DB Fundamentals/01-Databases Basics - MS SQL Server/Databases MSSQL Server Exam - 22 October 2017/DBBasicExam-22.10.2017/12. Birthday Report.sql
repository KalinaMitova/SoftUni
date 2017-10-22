SELECT DISTINCT c.[Name] 
 FROM Reports AS r
JOIN Users AS u
ON u.Id = r.UserId
JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.BirthDate)
  AND DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.BirthDate)
ORDER BY c.[Name]