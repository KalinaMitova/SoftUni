CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN 
	BEGIN TRANSACTION
	DECLARE @EmployeeDepartmentId INT
	SET @EmployeeDepartmentId = (
		SELECT DepartmentId FROM Employees
		WHERE Id = @employeeId
	)

	DECLARE @CategoryDepartmentId INT;
	SET @CategoryDepartmentId = (
		SELECT DepartmentId FROM Categories
		WHERE Id = (
			SELECT CategoryId FROM Reports
			WHERE Id = @reportId
		)
	)

	IF(@EmployeeDepartmentId <> @CategoryDepartmentId)
	BEGIN
		--THROW 51000, 'Employee doesn''t belong to the appropriate department!', 1;  
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		ROLLBACK
		RETURN
	END

	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId

	COMMIT
END