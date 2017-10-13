USE SoftUni

--01. Find Names of All Employees by First Name
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

GO

--02. Find Names of All Employees by Last Name
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

GO

--03. Find First Names of All Employess
SELECT FirstName FROM Employees
WHERE DepartmentID IN(3, 10) AND 
DATENAME(YEAR, HireDate) BETWEEN '1995' AND '2005'

GO

--04. Find All Employees Except Engineers
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

GO

--05. Find Towns with Name Length
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN(5, 6)
ORDER BY [Name]

GO

--06. Find Towns Starting With
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

GO

--07. Find Towns Not Starting With
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

GO

--08. Create View Employees Hired After
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE DATENAME(YEAR, HireDate) > 2000

GO

--09. Length of Last Name
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

GO

USE Geography

--10. Countries Holding 'A'
SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

GO

--11. Mix of Peak and River Names
SELECT Peaks.PeakName, 
       Rivers.RiverName, 
	   LOWER(STUFF(Peaks.PeakName, LEN(Peaks.PeakName), 1, Rivers.RiverName)) AS Mix
  FROM Peaks, 
       Rivers
WHERE RIGHT(Peaks.PeakName, 1) = LEFT(Rivers.RiverName, 1)
ORDER BY Mix

GO

USE Diablo

GO

--12. Games From 2011 and 2012 Year
SELECT TOP 50 [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE DATENAME(YEAR, [Start]) IN(2011, 2012)
ORDER BY [Start], [Name]

GO

--13. User Email Providers
SELECT Username, 
       SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider] 
  FROM Users
ORDER BY [Email Provider], Username

GO

--14. Get Users with IPAddress Like Pattern
SELECT Username, IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

GO

--15. Show All Games with Duration
SELECT [Name], 
  CASE 
  WHEN DATENAME(HH, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
  WHEN DATENAME(HH, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
  WHEN DATENAME(HH, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
  END AS [Part of the Day],
  CASE
  WHEN [Duration] <= 3 THEN 'Extra Short'
  WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
  WHEN [Duration] > 3 THEN 'Long'
  ELSE 'Extra Long'
  END AS [Duration]
  FROM Games
ORDER BY [Name], Duration, [Part of the Day] 

GO

USE Orders

--16. Orders Table
SELECT ProductName,
       OrderDate, 
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
  FROM Orders
  
GO

USE Demo

GO

--17. People Table
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)

GO

INSERT INTO People VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

GO

SELECT [Name],
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
       DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
       DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
  FROM People