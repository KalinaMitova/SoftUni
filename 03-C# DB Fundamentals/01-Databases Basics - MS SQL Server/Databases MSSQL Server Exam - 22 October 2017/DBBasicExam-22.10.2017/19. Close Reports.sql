CREATE TRIGGER tr_CompleteStatus ON Reports
FOR UPDATE
AS
BEGIN
	DECLARE @CloseDate DATETIME2;
	SET @CloseDate = (SELECT TOP 1 CloseDate FROM inserted)

	IF(@CloseDate IS NOT NULL)
	BEGIN
		UPDATE Reports
		SET StatusId = 3
		WHERE Id = (SELECT TOP 1 Id FROM inserted)
	END
END
