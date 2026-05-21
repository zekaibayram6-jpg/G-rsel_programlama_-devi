CREATE DATABASE PorscheDealershipDB;
GO

USE PorscheDealershipDB;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    IsAdmin BIT NOT NULL DEFAULT 0
);
GO

INSERT INTO Users (Username, Password, FullName, IsAdmin) VALUES ('admin', 'admin', 'Sistem Yöneticisi', 1);
GO


CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Model NVARCHAR(100) NOT NULL,
    Year INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    OTV DECIMAL(5,2) NOT NULL,
    KDV DECIMAL(5,2) NOT NULL,
    Stock INT NOT NULL,
    ImagePath NVARCHAR(MAX)
);
GO

CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES Users(Id),
    CarId INT FOREIGN KEY REFERENCES Cars(Id),
    TotalPrice DECIMAL(18,2) NOT NULL,
    OrderDate DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL
);
GO

INSERT INTO Cars (Model, Year, Price, OTV, KDV, Stock, ImagePath) 
VALUES
('Porsche 911 Carrera', 2024, 6000000.00, 2.20, 0.20, 5, 'car1.jpg'),
('Porsche Taycan 4S', 2024, 4500000.00, 0.40, 0.20, 3, 'car2.jpg'),
('Porsche Macan GTS', 2024, 5500000.00, 2.20, 0.20, 7, 'car3.jpg');
GO

USE PorscheDealershipDB;
GO


ALTER TABLE Users ADD IsAdmin BIT NOT NULL DEFAULT 0;
GO

INSERT INTO Users (Username, Password, FullName, IsAdmin) 
VALUES ('admin', 'admin', 'Sistem Yöneticisi', 1);
GO
