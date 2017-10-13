--01. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT [FirstName],
       [LastName]
  FROM Employees
 WHERE Salary > 35000

 GO

--02. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Input DECIMAL(18, 4))
AS
SELECT [FirstName],
       [LastName]
  FROM Employees
 WHERE Salary >= @Input

GO

--03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith(@StartStr NVARCHAR(10))
AS
SELECT [Name]
  FROM Towns
 WHERE LEFT([Name], LEN(@StartStr)) = @StartStr

GO

--04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown(@TownName NVARCHAR(20))
AS
SELECT [FirstName],
       [LastName]
  FROM [Employees] As e
INNER JOIN [Addresses] AS a
ON a.[AddressID] = e.[AddressID]
INNER JOIN [Towns] AS t
ON t.[TownID] = a.[TownID]
WHERE t.[Name] = @TownName

GO

--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
BEGIN
	DECLARE @SalaryLevel NVARCHAR(10);

    IF (@Salary < 30000)
	BEGIN
		SET @SalaryLevel = 'Low'
	END
	ELSE IF (@Salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @Salarylevel =  'Average'
	END
	ELSE
	BEGIN
		SET @SalaryLevel = 'High'
	END

	RETURN @SalaryLevel;
END

GO

--06. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(10))
AS
SELECT [FirstName],
       [LastName]
  FROM Employees
 WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel 
 
GO

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(20), @word NVARCHAR(20))
RETURNS BIT
BEGIN
    DECLARE @output BIT = 1;
    DECLARE @cnt INT = 1;

	WHILE @cnt <= LEN(@word)
	BEGIN
		DECLARE @currentChar CHAR(1) = SUBSTRING(@word, @cnt, 1)

	    IF(CHARINDEX(@currentChar, @setOfLetters) = 0)
		BEGIN
		    SET @output = 0;
			BREAK;
		END
	    SET @cnt = @cnt + 1;
	END;

	RETURN @output;
END

GO
--08. Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

ALTER TABLE Employees
ALTER COLUMN ManagerID INT NULL

ALTER TABLE Employees
ALTER COLUMN DepartmentID INT NULL

UPDATE Employees
SET ManagerID = NULL, DepartmentID = NULL
WHERE Employees.DepartmentID = @departmentId

UPDATE Departments
SET ManagerID = NULL
WHERE Departments.DepartmentID = @departmentId

DELETE FROM Departments
WHERE Departments.DepartmentID = @departmentId

DELETE FROM Employees
WHERE Employees.DepartmentID = @departmentId

SELECT COUNT(*) FROM Employees
WHERE DepartmentID = @departmentId

USE Bank
GO
--09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
SELECT FirstName + ' ' + LastName
    AS [Full Name]
  FROM AccountHolders
  
GO
--10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Amount DECIMAL(15, 2))
AS
SELECT FirstName, 
       LastName
  FROM Accounts AS a
INNER JOIN AccountHolders AS ah
ON ah.Id = a.AccountHolderId
GROUP BY FirstName, LastName
HAVING SUM(Balance) > @Amount

GO
--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@I MONEY, @R FLOAT, @T INT)
RETURNS MONEY
BEGIN
	DECLARE @FV MONEY = @I * POWER((1 + @R), @T)

	RETURN @FV
END

GO
--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount @AccountID INT, @InterestRate FLOAT
AS
SELECT ah.Id AS [Account Id],
       ah.FirstName,
	   ah.LastName,
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
FROM Accounts AS a
INNER JOIN AccountHolders AS ah
ON ah.Id = a.AccountHolderId
WHERE a.Id = @AccountId

USE Diablo
GO
--13. *Cash in User Games Odd Rows
CREATE FUNCTION dbo.ufn_CashInUsersGames (@GameName NVARCHAR(30))
RETURNS TABLE
AS
RETURN
(
	SELECT SUM(Cash) AS [SumCash]
      FROM 
		   (
		   SELECT *,
		   		  ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS [Row]
		   	 FROM UsersGames AS ug
		   	WHERE ug.GameId IN ((SELECT g.Id FROM Games AS g WHERE [Name] = @GameName))
		   ) AS TempTable
	 WHERE [Row] % 2 = 1
)