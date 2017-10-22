CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT) 
RETURNS INT
AS
BEGIN
	DECLARE @Counter INT;
	SET @Counter = (
		SELECT COUNT(*) FROM Reports
		WHERE EmployeeId = @employeeId AND StatusId = @statusId
	)
	RETURN @Counter
END