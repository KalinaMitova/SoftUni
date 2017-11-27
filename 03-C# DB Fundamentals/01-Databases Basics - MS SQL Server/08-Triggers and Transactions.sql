USE Bank
GO

--01. Create Table Logs
CREATE TABLE Logs(
	LogId INT IDENTITY PRIMARY KEY,
	AccountId INT,
	OldSum DECIMAL(15, 2),
	NewSum DECIMAL(15, 2)
)

CREATE TRIGGER tr_AccountLog 
            ON Accounts 
		   FOR UPDATE
			AS
   INSERT INTO Logs(AccountId, OldSum, NewSum)
        SELECT inserted.Id,  
	           deleted.Balance,
	           inserted.Balance
          FROM inserted
    INNER JOIN deleted
            ON deleted.Id = inserted.Id

--02. Create Table Emails
CREATE TABLE NotificationEmails(
	Id INT IDENTITY PRIMARY KEY,
	Recipient INT,
	[Subject] VARCHAR(100),
	Body VARCHAR(100)
)
GO
CREATE TRIGGER tr_NotificationEmail
            ON Logs
           FOR INSERT
            AS
   INSERT INTO NotificationEmails(Recipient, [Subject], Body)
        SELECT inserted.AccountId,
		       CONCAT('Balance change for account: ', inserted.AccountId),
			   CONCAT('On Sep ', GETDATE(), ' your balance was changed from ', inserted.OldSum, ' to ', inserted.NewSum, '.')
          FROM inserted

--03. Deposit Money
GO
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(10, 4))
AS 
BEGIN
	BEGIN TRANSACTION
	
	IF (@MoneyAmount <= 0)
	BEGIN
	    ROLLBACK
		RETURN;
	END
	
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId

	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT
END

--04. Withdraw Money Procedure
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(10, 4))
AS 
BEGIN
	BEGIN TRANSACTION
	
	IF (@MoneyAmount <= 0)
	BEGIN
	    ROLLBACK
		RETURN;
	END
	
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT
END

GO
--05. Money Transfer
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(10, 4))
AS
BEGIN
	BEGIN TRANSACTION
	IF (@Amount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE Accounts
	SET Balance -= @Amount
	WHERE Id = @SenderId

	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RETURN
	END

	UPDATE Accounts
	SET Balance += @Amount
	WHERE Id = @ReceiverId
	
	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT
END 

GO
USE Diablo
GO
--06. Trigger

--07. *Massive Shopping
DECLARE @UserId INT = (
	SELECT Id FROM Users
	 WHERE Username = 'Stamat'
)

DECLARE @GameId INT = (
	SELECT Id FROM Games
	 WHERE [Name] = 'Safflower'
)

DECLARE @UserGameId INT = (
	SELECT Id FROM UsersGames
	 WHERE UserId = @UserId
	   AND GameId = @GameId
)

DECLARE @Cash DECIMAL(15, 2) = (
	SELECT Cash FROM UsersGames
	WHERE Id = @UserGameId
)

BEGIN TRANSACTION
	DECLARE @FirstLevelRangeTotalPrice DECIMAL(15, 2) = (
		SELECT SUM(Price) FROM Items
		WHERE MinLevel BETWEEN 11 AND 12
	)

IF (@Cash - @FirstLevelRangeTotalPrice < 0)
BEGIN
	ROLLBACK
END
ELSE
BEGIN 
	UPDATE UsersGames
	SET Cash -= @FirstLevelRangeTotalPrice
	WHERE Id = @UserGameId

	INSERT INTO UserGameItems
	SELECT Id, @UserGameId FROM Items
	WHERE MinLevel BETWEEN 11 AND 12

	COMMIT
END



BEGIN TRANSACTION
	DECLARE @SecondLevelRangeTotalPrice DECIMAL(15, 2) = (
		SELECT SUM(Price) FROM Items
		WHERE MinLevel BETWEEN 19 AND 21
	)

IF (@Cash - @SecondLevelRangeTotalPrice < 0)
BEGIN
	ROLLBACK
END
ELSE
BEGIN
	UPDATE UsersGames
	SET Cash -= @SecondLevelRangeTotalPrice
	WHERE Id = @UserGameId

	INSERT INTO UserGameItems
	SELECT Id, @UserGameId FROM Items
	WHERE MinLevel BETWEEN 19 AND 21

	COMMIT
END

SELECT i.[Name] AS [Item Name] FROM UserGameItems AS ugi
INNER JOIN Items AS i ON i.Id = ugi.ItemId
INNER JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
INNER JOIN Games AS g ON g.Id = ug.GameId
WHERE g.Id = @GameId
ORDER BY i.[Name]
-----------------------------------

USE SoftUni
GO
--08. Employees with Three Projects
CREATE PROC usp_AssignProject(@emloyeeId INT , @projectID INT) 
AS
BEGIN
	BEGIN TRANSACTION
	
	IF ((SELECT COUNT(ProjectID) 
	       FROM EmployeesProjects as ep2
	      WHERE ep2.EmployeeID = @emloyeeId) >= 3)
	BEGIN
		RAISERROR('The employee has too many projects!', 16, 1)
		ROLLBACK
		RETURN
	END

	INSERT INTO EmployeesProjects VALUES
	(@emloyeeId, @projectID)

	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RETURN
	END
	
	COMMIT
END

--09. Delete Employees
CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY, 
	FirstName NVARCHAR(50), 
	LastName NVARCHAR(50), 
	MiddleName NVARCHAR(50), 
	JobTitle NVARCHAR(50), 
	DeparmentId INT, 
	Salary DECIMAL(15, 2)
) 

GO

CREATE TRIGGER tr_DeletedEmployees
             ON Employees
            FOR DELETE
             AS
    INSERT INTO Deleted_Employees
         SELECT d.FirstName, 
				d.LastName, 
				d.MiddleName, 
				d.JobTitle, 
				d.DepartmentID, 
				d.Salary
           FROM deleted AS d