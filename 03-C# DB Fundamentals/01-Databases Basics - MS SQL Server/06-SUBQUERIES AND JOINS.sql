USE SoftUni
--01. Employee Address
    SELECT TOP (5)
	       e.EmployeeID,
	       e.JobTitle,
		   a.AddressID,
		   a.AddressText
      FROM Employees AS e
INNER JOIN Addresses AS a 
        ON a.AddressID = e.AddressID 
  ORDER BY a.AddressID

--02. Addresses with Towns
    SELECT TOP (50)
           e.FirstName,
           e.LastName,
	       t.[Name] AS Town,
	       a.AddressText
      FROM Employees AS e
INNER JOIN Addresses AS a
        ON a.AddressID = e.AddressID
INNER JOIN Towns AS t
        ON t.TownID = a.TownID
  ORDER BY FirstName, LastName

--03. Sales Employees
    SELECT e.EmployeeID,
	       e.FirstName,
		   e.LastName,
		   d.[Name] AS DepartmentName
      FROM Employees AS e
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
     WHERE d.[Name] = 'Sales'
  ORDER BY e.EmployeeID

--04. Employee Departments
    SELECT TOP (5)
	       e.EmployeeID,
	       e.FirstName,
		   e.Salary,
		   d.[Name] AS DepartmentName
      FROM Employees AS e
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
     WHERE e.Salary > 15000
  ORDER BY d.DepartmentID

--05. Employees Without Projects
         SELECT TOP (3) 
                e.EmployeeID, 
                e.FirstName 
           FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep
             ON ep.EmployeeID = e.EmployeeID
          WHERE ep.ProjectID IS NULL
       ORDER BY e.EmployeeID

--06. Employees Hired After
    SELECT e.FirstName, 
           e.LastName, 
           e.HireDate, 
           d.[Name] AS DeptName
      FROM Employees AS e
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
	   AND e.HireDate > '1.1.1999'
       AND d.[Name] IN ('Sales', 'Finance')
  ORDER BY e.HireDate

--07. Employees With Project
    SELECT TOP (5)
	       e.EmployeeID,
	       e.FirstName,
		   p.[Name]
      FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
        ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
        ON p.ProjectID = ep.ProjectID
	   AND p.StartDate > '2002.08.13'
	   AND p.EndDate IS NULL
  ORDER BY e.EmployeeID

--08. Employee 24
    SELECT e.EmployeeID,
	       e.FirstName,
      CASE
      WHEN p.StartDate >= '2005'
	  THEN NULL
	  ELSE p.[Name]
	   END AS ProjectName
      FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
        ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
        ON p.ProjectID = ep.ProjectID
	 WHERE e.EmployeeID = 24
	
--09. Employee Manager
    SELECT e.EmployeeID,
	       e.FirstName,
	       m.EmployeeID AS ManagerID,
	       m.FirstName AS ManagerName
      FROM Employees AS e
INNER JOIN Employees AS m
        ON m.EmployeeID = e.ManagerID
	 WHERE m.EmployeeID IN (3, 7)
  ORDER BY e.EmployeeID

--10. Employees Summary
    SELECT TOP (50)
           e.EmployeeID,
	       e.FirstName + ' ' + e.LastName AS EmployeeName,
	       m.FirstName + ' ' + m.LastName AS ManagerName,
	       d.[Name] AS DepartmentName
      FROM Employees AS e
INNER JOIN Employees AS m
        ON m.EmployeeID = e.ManagerID
INNER JOIN Departments AS d
        ON d.DepartmentID = e.DepartmentID
  ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT MIN(AvgSalary) AS MinAverageSalary
  FROM (SELECT AVG(Salary) AS AvgSalary FROM Employees
GROUP BY DepartmentID) AS AverageSalaries

USE Geography
--12. Highest Peaks in Bulgaria
    SELECT c.CountryCode,
	       m.MountainRange,
	       p.PeakName,
	       p.Elevation
      FROM MountainsCountries AS c
INNER JOIN Mountains AS m
        ON m.Id = c.MountainId
INNER JOIN Peaks AS p
        ON p.MountainId = m.Id
     WHERE c.CountryCode = 'BG'
       AND p.Elevation > 2835
  ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
    SELECT c.CountryCode,
	       COUNT(m.MountainRange)
      FROM MountainsCountries AS c
INNER JOIN Mountains AS m
        ON m.Id = c.MountainId
     WHERE CountryCode IN ('BG', 'RU','US')
  GROUP BY CountryCode

--14. Countries With or Without Rivers
         SELECT TOP (5)
                CountryName,
                RiverName
           FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr
             ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers AS r
             ON r.Id = cr.RiverId
          WHERE c.ContinentCode = 'AF'
       ORDER BY c.CountryName

--15. Continents and Currencies
  SELECT ContinentCode,
         CurrencyCode,
	     CurrencyUsage
    FROM (
    	SELECT ContinentCode,
    		   CurrencyCode,
    		   CurrencyUsage,
    		   DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS [Rank]
    	  FROM (
    		  SELECT ContinentCode, 
    				 CurrencyCode, 
    				 COUNT(CurrencyCode) AS CurrencyUsage
    			FROM Countries
    		GROUP BY ContinentCode, CurrencyCode
    	) AS Currencies
    ) AS RankedCurrencies
   WHERE [Rank] = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode

--16. Countries without any Mountains
SELECT COUNT(CountryCode) AS [CountryCode]
  FROM Countries
 WHERE CountryCode NOT IN (
	SELECT CountryCode 
	  FROM MountainsCountries
)

--17. Highest Peak and Longest River by Country
SELECT TOP (5)
       CountryName, 
	   HighestPeakElevation, 
	   LongestRiverLength
  FROM (
         SELECT c.CountryName, 
		        p.Elevation AS HighestPeakElevation, 
				r.[Length] AS LongestRiverLength,
				DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY p.Elevation DESC) 
			 AS [ElevationRank],
			    DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY r.[Length] DESC) 
			 AS [LengthRank]
		   FROM Countries 
		     AS c
LEFT OUTER JOIN MountainsCountries 
             AS mc
             ON mc.CountryCode = c.CountryCode
LEFT OUTER JOIN Peaks 
             AS p
             ON p.MountainId = mc.MountainId
LEFT OUTER JOIN CountriesRivers 
             AS cr
             ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers 
             AS r
             ON r.Id = cr.RiverId
) AS ElevationLength
WHERE ElevationRank = 1 AND LengthRank = 1
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName

--18. Highest Peak Name and Elevation by Country
SELECT TOP (5)
       [Country],
  CASE
  WHEN [Highest Peak Name] IS NULL
  THEN '(no highest peak)'
  ELSE [Highest Peak Name]
  END,
  CASE
  WHEN [Highest Peak Elevation] IS NULL
  THEN 0
  ELSE [Highest Peak Elevation]
  END,
  CASE
  WHEN [Mountain] IS NULL
  THEN '(no mountain)'
  ELSE [Mountain]
  END
FROM (
         SELECT c.CountryName AS [Country],
		        p.PeakName AS [Highest Peak Name],
				p.Elevation AS [Highest Peak Elevation],
				m.MountainRange AS [Mountain],
		        DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
           FROM Countries
             AS c
LEFT OUTER JOIN MountainsCountries 
             AS mc
             ON mc.CountryCode = C.CountryCode
LEFT OUTER JOIN Mountains
             AS m
			 ON m.Id = mc.MountainId
LEFT OUTER JOIN Peaks
             AS p
			 ON p.MountainId = mc.MountainId
) AS TempTable
WHERE [Rank] = 1
ORDER BY Country, [Highest Peak Name]