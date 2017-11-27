--01. DDL
CREATE TABLE Clients (
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics (
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(255) NOT NULL
)

CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Vendors (
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Parts (
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber NVARCHAR(50) UNIQUE NOT NULL,
	[Description] NVARCHAR(255),
	Price DECIMAL(10, 2) NOT NULL,
	VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL,
	CHECK (Price > 0)
)

CREATE TABLE Jobs (
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId),
	[Status] NVARCHAR(11) NOT NULL DEFAULT 'Pending',
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId),
	MechanicId INT NULL FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE,
	CHECK ([Status] IN ('Pending', 'In Progress', 'Finished'))
)

CREATE TABLE Orders (
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)


CREATE TABLE PartsNeeded (
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 NOT NULL,
	PRIMARY KEY (JobId, PartId),
	CHECK (Quantity > 0)
)

CREATE TABLE OrderParts (
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1 NOT NULL,
	PRIMARY KEY (OrderId, PartId),
	CHECK (Quantity > 0)
)
Go
--02. Insert
INSERT INTO Clients VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2, 2),
('W10780048', 'Suspension Rod', 42.81, 1, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3, 3)

--03. Update
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE [Status] = 'Pending'

--04. Delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--05. Clients by Name
SELECT FirstName,
       LastName,
	   Phone
  FROM Clients
ORDER BY LastName,
         ClientId

--06. Job Status
SELECT [Status],
       IssueDate
  FROM Jobs
WHERE [Status] IN ('Pending', 'In Progress')
ORDER BY IssueDate, JobId


--07. Mechanic Assignments
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic],
       j.[Status],
	   IssueDate
  FROM Jobs AS j
INNER JOIN Mechanics AS m
ON m.MechanicId = j.MechanicId
ORDER BY j.MechanicId, IssueDate, JobId

--08. Current Clients
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [Client],
       DATEDIFF(DAY, j.IssueDate, '2017.04.24') AS [Days going],
	   j.[Status]       
  FROM Jobs AS j
INNER JOIN Clients AS c
ON c.ClientId = j.ClientId
WHERE j.[Status] <> 'Finished'
ORDER BY [Days going] DESC, j.ClientId 

--09. Mechanic Performance
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic],
       [Average Days]
  FROM (SELECT MechanicId,
       AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS [Average Days]
  FROM Jobs
WHERE [Status] = 'Finished'
GROUP BY MechanicId) AS j
INNER JOIN Mechanics AS m
ON m.MechanicId = j.MechanicId
ORDER BY j.MechanicId

--10. Hard Earners
SELECT TOP 3
       CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic],
       j.[Jobs]
  FROM (
	  SELECT MechanicId, 
			 COUNT(MechanicId) AS [Jobs] FROM Jobs
	  WHERE [Status] <> 'Finished'
	  GROUP BY MechanicId
  ) AS j
INNER JOIN Mechanics AS m
ON m.MechanicId = j.MechanicId
WHERE j.[Jobs] > 1
ORDER BY j.[Jobs] DESC, j.MechanicId

GO
--11. Available Mechanics
SELECT CONCAT(FirstName, ' ', LastName) AS Available 
  FROM Mechanics
WHERE MechanicId NOT IN (SELECT DISTINCT MechanicId FROM Jobs)
   OR MechanicId NOT IN (SELECT MechanicId FROM Jobs WHERE [Status] = 'In Progress')
ORDER BY MechanicId

--12. Parts Cost
SELECT ISNULL(SUM(op.Quantity * p.Price), 0) AS [Parts Total] FROM OrderParts AS op
LEFT JOIN Orders AS o
ON o.OrderId = op.OrderId
LEFT JOIN Parts AS p
ON p.PartId = op.PartId
WHERE o.IssueDate BETWEEN DATEADD(WEEK, -3, '2017.04.24') AND '2017.04.24'

--13. Past Expenses
SELECT j.JobId,
       ISNULL(SUM(op.Quantity * p.Price), 0) AS Total
  FROM Jobs AS j
LEFT JOIN Orders AS o
ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op
ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p
ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, JobId

--14. Model Repair Time
SELECT j.ModelId,
       m.[Name], 
       CONCAT([AST], ' ', 'days') AS [Average Service Time]
  FROM (
	SELECT j.ModelId,
		   AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [AST]
	  FROM Jobs AS j
	WHERE FinishDate IS NOT NULL
	GROUP BY j.ModelId
) AS j
INNER JOIN Models AS m
ON m.ModelId = j.ModelId
ORDER BY [AST]

--15. Faultiest Model
SELECT m.[Name] AS [Model],
       [Times Serviced],
	   [Parts Total]
  FROM (
	SELECT j.ModelId, 
		   COUNT(DISTINCT j.JobId) AS [Times Serviced], 
		   ISNULL(SUM(op.Quantity * p.Price), 0) AS [Parts Total],
		   DENSE_RANK() OVER(ORDER BY COUNT(DISTINCT j.JobId) DESC) AS [Rank]
	  FROM Jobs AS j
	LEFT OUTER JOIN Orders AS o
	ON j.JobId = o.JobId
	LEFT OUTER JOIN OrderParts AS op
	ON op.OrderId = o.OrderId
	LEFT OUTER JOIN Parts AS p
	ON p.PartId = op.PartId
	GROUP BY j.ModelId
) AS Temp
INNER JOIN Models AS m
ON m.ModelId = Temp.ModelId
WHERE [Rank] = 1

--16. Missing Parts
SELECT pn.PartId,
       p.[Description],
	   pn.Quantity AS [Required],
	   p.StockQty AS [In Stock],
	   ISNULL(op.Quantity, 0) AS [Ordered]
  FROM PartsNeeded AS pn
LEFT JOIN Jobs AS j
ON j.JobId = pn.JobId
LEFT JOIN Parts AS p
ON p.PartId = pn.PartId
LEFT JOIN Orders AS o
ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op
ON op.OrderId = o.OrderId
WHERE j.[Status] <> 'Finished' 
  AND p.StockQty - pn.Quantity < 0
ORDER BY PartId
GO
--17. Cost of Order
CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(15, 2)
BEGIN
	DECLARE @TotalCost DECIMAL(15, 2);
	SET @TotalCost = (
		SELECT ISNULL(SUM(p.Price), 0)
		  FROM Orders AS o
		LEFT JOIN OrderParts AS op
		ON op.OrderId = o.OrderId
		INNER JOIN Parts AS p
		ON p.PartId = op.PartId
		WHERE JobId = @JobId
	)
	RETURN @TotalCost
END

--18. Place Order
GO
CREATE PROC usp_PlaceOrder @JobId INT, @PartSerialNumber NVARCHAR(50), @Quantity INT 
AS
BEGIN

	--	The quantity cannot be zero or negative; error message ID 50012 "Part quantity must be more than zero!"
	IF (@Quantity <= 0)
	BEGIN
		RAISERROR('Part quantity must be more than zero!', 16, 1);
		RETURN;
	END

	DECLARE @JobIdSelected INT = (
		SELECT j.JobId FROM Jobs AS j
	     WHERE j.JobId = @JobId
	)
	
	--	The job with given ID must exist in the database; error message ID 50013 "Job not found!"
	IF (@JobIdSelected IS NULL)
	BEGIN
		RAISERROR('Job not found!', 16, 1);
		RETURN;
	END

	--	An order cannot be placed for a job that is Finished; error message ID 50011 "This job is not active!"
	DECLARE @IsJobActive INT = (
		SELECT j.JobId FROM Jobs AS j
	     WHERE j.JobId = @JobId
		   AND j.[Status] <> 'Finished'
	)
	IF (@IsJobActive IS NULL)
	BEGIN
		RAISERROR('This job is not active!', 16, 1);
		RETURN;
	END

	DECLARE @PartId INT = (
		SELECT PartId FROM Parts
		WHERE SerialNumber = @PartSerialNumber
	)

	--	The part with given serial number must exist in the database ID 50014 "Part not found!"
	IF (@PartId IS NULL)
	BEGIN
		RAISERROR('Part not found!', 16, 1);
		RETURN;
	END

	DECLARE @OrderId INT = (
		SELECT o.OrderId FROM OrderParts AS op
		JOIN Orders AS o ON o.OrderId = op.OrderId
		JOIN Jobs AS j ON j.JobId = o.JobId
		WHERE op.PartId = @PartId
		  AND o.JobId = @JobId
		  AND o.IssueDate IS NULL
	)
		
	IF (@OrderId IS NULL)
	BEGIN
		-- Order Not Exist
		INSERT INTO Orders (JobId, IssueDate) VALUES
		(@JobId, NULL)

		INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
		(IDENT_CURRENT('Orders'), @PartId, @Quantity)
	END
	ELSE
	BEGIN	
		-- Order exist
		DECLARE @IsPartExist INT = (
			SELECT @@ROWCOUNT FROM OrderParts
			 WHERE OrderId = @OrderId AND PartId = @PartId
		)

		IF (@IsPartExist IS NOT NULL)
		BEGIN
			-- Part Exist
			UPDATE OrderParts
			   SET Quantity += @Quantity
			 WHERE OrderId = @OrderId
		  	   AND PartId = @PartId
		END
		ELSE
		BEGIN
			-- Part Not Exist
			INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
			(@OrderId, @PartId, @Quantity)
		END
	END
END

--19. Detect Delivery
GO
CREATE TRIGGER tr_AddQuantity ON Orders
FOR UPDATE
AS
	DECLARE @OldDelivery BIT = (SELECT Delivered FROM deleted);
	DECLARE @NewDelivery BIT = (SELECT Delivered FROM inserted);
	
	IF (@OldDelivery = 0 AND @NewDelivery = 1)
	BEGIN
		UPDATE Parts
		SET StockQty += op.Quantity
		FROM Parts AS p
		JOIN OrderParts AS op ON op.PartId = p.PartId
		WHERE op.OrderId = (
				SELECT OrderId FROM inserted
			 )
		  AND p.PartId = op.PartId
	END
	
--20. Vendor Preference
GO
WITH CTE_MechanicsVendors
AS
(
	  SELECT m.MechanicId, 
	   	     v.VendorId, 
		     SUM(op.Quantity) AS Parts
	    FROM Mechanics AS m
	    JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	    JOIN Orders AS o ON o.JobId = j.JobId
	    JOIN OrderParts AS op ON op.OrderId = o.OrderId
	    JOIN Parts AS p ON p.PartId = op.PartId
  	    JOIN Vendors AS v ON v.VendorId = p.VendorId
	GROUP BY m.MechanicId, v.VendorId
)

SELECT m.FirstName + ' ' + LastName AS Mechanic,
       v.[Name] AS Vendor,
	   mv1.Parts,
       CAST(CAST(CAST(mv1.Parts AS DECIMAL(6, 4)) / (
	   SELECT SUM(mv2.Parts)
	     FROM CTE_MechanicsVendors AS mv2
	     WHERE mv1.MechanicId = mv2.MechanicId
	   ) * 100 AS INT) AS VARCHAR(10)) + '%' AS Preference
  FROM CTE_MechanicsVendors AS mv1
JOIN Mechanics AS m ON m.MechanicId = mv1.MechanicId
JOIN Vendors AS v ON v.VendorId = mv1.VendorId
ORDER BY [Mechanic],  [Parts] DESC, v.[Name]



