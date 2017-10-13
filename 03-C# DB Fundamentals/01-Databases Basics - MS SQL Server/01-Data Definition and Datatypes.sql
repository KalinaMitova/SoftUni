--04. Insert Records in Both Tables
INSERT INTO Towns([Id], [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions([Id], [Name], [Age], [TownId]) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', Null, 2)

--07. Create Table People
CREATE TABLE People(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(15, 2),
	[Weight] DECIMAL(15, 2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NTEXT 
)

INSERT INTO People([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography]) VALUES
('Gosho', NULL, 195.32, 95.66, 'm', '01.02.2002', 'I am GECATAAAA!'),
('Pesho', NULL, 195.32, 95.66, 'm', '01.02.1991', 'I am Pesho!'),
('Ivan', NULL, 195.32, 95.66, 'm', '01.02.2000', 'I am VANKATAAAA!'),
('Mariyka', NULL, 160.32, 55.66, 'f', '01.02.1995', 'I am MARA!'),
('Pepi', NULL, 220.32, 168.66, 'f', '01.02.1989', 'I am PEPA!')

--08. Create Table Users
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(900),
	LastLoginTime DATETIME2,
	IsDeleted BIT DEFAULT 0
)

INSERT INTO Users([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) VALUES
('ruskovweb', '123456Dr', NULL, GETDATE(), 0),
('gergi', '123456gergi', NULL, GETDATE(), 1),
('bojo', 'bojkata', NULL, GETDATE(), 0),
('siska', 'sisinka', NULL, GETDATE(), 1),
('neshtosi', 'nqmaparola', NULL, GETDATE(), 1)

--13. Movies Database
CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NTEXT 
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NTEXT 
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NTEXT 
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyRightYear INT,
	[Length] INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating INT,
	Notes NTEXT
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Michael Bay', NULL),
('Ivanov', 'Nqmam mnogo belejki'),
('Draganov', NULL),
('Simeonov', NULL),
('Spas', NULL)

INSERT INTO Categories(CategoryName, Notes) VALUES
('sd', NULL),
('3d', 'Nqmam mnogo belejki'),
('HD', NULL),
('DVD-R', NULL),
('Blu-ray', NULL)

INSERT INTO Genres(GenreName, Notes) VALUES
('Action', NULL),
('Comedy', 'Nqmam mnogo belejki'),
('Psycho', NULL),
('Triller', NULL),
('Erotic', NULL)

INSERT INTO Movies(Title, DirectorId, CopyRightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('Transformers', 1, 2000, 186, 1, 5, 5, NULL),
('Titanic', 5, 1967, 1896, 5, 5, 2, NULL),
('Fast And The Furious', 4, 1998, 186, 4, 3, 3, NULL),
('Never Back Down', 3, 1553, 186, 3, 2, 3, NULL),
('Transporter', 2, 2001, 186, 2, 4, 4, NULL)

--14. Car Rental Database
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(15, 2) NOT NULL,
	WeeklyRate DECIMAL(15, 2) NOT NULL,
	MonthlyRate DECIMAL(15, 2) NOT NULL,
	WeekendRate DECIMAL(15, 2) NOT NULL
)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors SMALLINT NOT NULL,
	Picture VARBINARY(MAX),
	Condition NTEXT,
	Available BIT NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NTEXT
)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(500) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NTEXT
)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel SMALLINT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate Date NOT NULL,
	EndDate Date NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied INT NOT NULL,
	TaxRate DECIMAL(15, 2) NOT NULL,
	OrderStatus BIT NOT NULL,
	Notes NTEXT
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('asd', 10, 50, 100, 60),
('sss', 20, 60, 120, 40),
('ddd', 30, 70, 110, 50)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('H9133AM', 'Ford', 'Mondeo', 1995, 2, 4, NULL, NULL, 1),
('H9666AM', 'BMW', '320', 2006, 1, 2, NULL, NULL, 0),
('OB4444AP', 'Mercedes', 'S-Classe', 2016, 3, 3, NULL, NULL, 1)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Dimitar', 'Ruskov', 'seller', NULL),
('Vladimir', 'Damyanovski', 'BIGBOSS', NULL),
('Svetlin', 'NAKOV', 'MEGAHIPERTRANSCOSMOSBOSSSSSS', NULL)


INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
(123654, 'Bat Gergi', 'KOMSOMOLSKA 23', 'Sofia', 5000, NULL),
(123654, 'Bat Sasho', 'KOMSOMOLSKA 24', 'Plovdiv', 5001, NULL),
(123654, 'Bat Kubrat', 'KOMSOMOLSKA 25', 'Varna', 5002, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 40, 123, 543, 321, '01.01.2017', '01.05.2017', 365, 1, 15, 1, NULL),
(2, 2, 2, 50, 222, 444, 222, '01.03.2017', '01.04.2017', 35, 1, 15, 1, NULL),
(3, 3, 3, 60, 333, 555, 222, '01.02.2017', '01.05.2017', 65, 1, 15, 1, NULL)

--15. Hotel Database
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NTEXT
)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(50) NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber VARCHAR(50) NOT NULL,
	Notes NTEXT
)

CREATE TABLE RoomStatus(
	RoomStatus INT PRIMARY KEY NOT NULL,	
	Notes NTEXT
)

CREATE TABLE RoomTypes(
	RoomType INT PRIMARY KEY NOT NULL,	
	Notes NTEXT
)

CREATE TABLE BedTypes(
	BedType INT PRIMARY KEY NOT NULL,	
	Notes NTEXT
)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType INT FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate INT,
	RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NTEXT
)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATETIME DEFAULT GETDATE() NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL(15, 2),
	TaxRate DECIMAL(15, 2),
	TaxAmount DECIMAL(15, 2),
	PaymentTotal DECIMAL(15, 2),
	Notes NTEXT
)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE DEFAULT GETDATE() NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied BIT NOT NULL,
	PhoneCharge BIT NOT NULL,
	Notes NTEXT
)

INSERT INTO Employees VALUES
('Dimitar', 'Ruskov', 'Ekspert', NULL),
('Hristo', 'Ivanov', 'Glaven Ekspert', NULL),
('Tihomir', 'Mihov', 'Ekspert', NULL)


INSERT INTO Customers VALUES
(1, 'Dimitar', 'Ruskov', '0895369852', 'Dimitar', '0895369852', NULL),
(2, 'Hristo', 'Ivanov', '0887542325', 'Hristo', '0887542325', NULL),
(3, 'Tihomir', 'Mihov', '0897565414', 'Tihomir', '0897565414', NULL)

INSERT INTO RoomStatus VALUES
(1, 'Zaeta'),
(2, 'Svobodna'),
(3, NULL)


INSERT INTO RoomTypes VALUES
(1, 'Dvoina'),
(2, 'Troina'),
(3, 'Apartament')

INSERT INTO BedTypes VALUES
(1, 'Edinichno'),
(2, 'Dvoino'),
(3, 'Troino')

INSERT INTO Rooms VALUES
(1, 1, 3, 3, 2, null),
(2, 2, 2, 4, 1, null),
(3, 3, 2, 5, 3, null)

INSERT INTO Payments VALUES
(1, GETDATE(), 1, '2017.05.01', '2017.05.25', 25, 5000.00, 30.50, 30.50, 61, NULL),
(2, GETDATE(), 3, '2017.06.01', '2017.06.25', 25, 4000.00, 20.50, 10.50, 31, NULL),
(3, GETDATE(), 2, '2017.07.01', '2017.07.25', 25, 3000.00, 20.50, 10.50, 31, NULL)

INSERT INTO Occupancies VALUES
(1, GETDATE(), 1, 1, 1, 1, NULL),
(2, GETDATE(), 3, 2, 0, 0, NULL),
(3, GETDATE(), 2, 3, 1, 1, NULL)

--19. Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20. Basic Select All Fields and Order Them
  SELECT * 
    FROM Towns
ORDER BY [Name]
  SELECT * 
    FROM Departments
ORDER BY [Name]
  SELECT * 
    FROM Employees
ORDER BY Salary DESC

--21. Basic Select Some Fields
  SELECT [Name] 
    FROM Towns
ORDER BY [Name]
  SELECT [Name] 
    FROM Departments
ORDER BY [Name]
  SELECT FirstName, 
         LastName, 
		 JobTitle, 
		 Salary 
    FROM Employees
ORDER BY Salary DESC

--22. Increase Employees Salary
UPDATE Employees
   SET Salary *= 1.1
SELECT Salary 
  FROM Employees

--23. Decrease Tax Rate
UPDATE Payments
   SET TaxRate /= 0.97
SELECT TaxRate 
  FROM Payments

--24. Delete All Records
DELETE FROM Occupancies