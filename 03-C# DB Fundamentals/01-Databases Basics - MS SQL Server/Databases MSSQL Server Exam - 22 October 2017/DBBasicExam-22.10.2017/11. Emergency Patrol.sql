SELECT r.OpenDate,
       r.[Description],
	   u.Email
  FROM Reports AS r
JOIN Users AS u
ON u.Id = r.UserId
WHERE r.CloseDate IS NULL
  AND (LEN(r.[Description]) > 20 AND r.[Description] LIKE '%str%')
  AND r.CategoryId IN (
	SELECT Id FROM Categories
	  WHERE DepartmentId IN (
		SELECT Id FROM Departments
		WHERE [Name] IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
	  )
  )
ORDER BY OpenDate, u.Email, r.Id
