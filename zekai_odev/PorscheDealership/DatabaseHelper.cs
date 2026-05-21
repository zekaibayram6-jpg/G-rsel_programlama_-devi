using System;
using System.Data.SqlClient;
using System.IO;

namespace PorscheDealership
{
    public static class DatabaseHelper
    {
        private const string MasterConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;";
        public const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PorscheDealershipDB;Integrated Security=true;";

        public static void InitializeDatabase()
        {
            try
            {
                using (var conn = new SqlConnection(MasterConnectionString))
                {
                    conn.Open();
                    string checkDbQuery = "SELECT database_id FROM sys.databases WHERE Name = 'PorscheDealershipDB'";
                    using (var cmd = new SqlCommand(checkDbQuery, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            string createDbQuery = "CREATE DATABASE PorscheDealershipDB";
                            using (var createCmd = new SqlCommand(createDbQuery, conn))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Create Users table
                    string createUsers = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                        CREATE TABLE Users (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Username NVARCHAR(50) UNIQUE NOT NULL,
                            Password NVARCHAR(50) NOT NULL,
                            FullName NVARCHAR(100) NOT NULL,
                            IsAdmin BIT NOT NULL DEFAULT 0
                        )";
                    new SqlCommand(createUsers, conn).ExecuteNonQuery();

                    // Migration for existing table
                    string alterUsers = @"
                        IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Users') AND name = 'IsAdmin')
                        BEGIN
                            ALTER TABLE Users ADD IsAdmin BIT NOT NULL DEFAULT 0;
                        END";
                    new SqlCommand(alterUsers, conn).ExecuteNonQuery();

                    // Create admin user if not exists
                    string createAdmin = @"
                        IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin')
                        BEGIN
                            INSERT INTO Users (Username, Password, FullName, IsAdmin) VALUES ('admin', 'admin', 'Sistem Yöneticisi', 1);
                        END";
                    new SqlCommand(createAdmin, conn).ExecuteNonQuery();

                    // Create Cars table
                    string createCars = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')
                        CREATE TABLE Cars (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Model NVARCHAR(100) NOT NULL,
                            Year INT NOT NULL,
                            Price DECIMAL(18,2) NOT NULL,
                            OTV DECIMAL(5,2) NOT NULL,
                            KDV DECIMAL(5,2) NOT NULL,
                            Stock INT NOT NULL,
                            ImagePath NVARCHAR(MAX)
                        )";
                    new SqlCommand(createCars, conn).ExecuteNonQuery();

                    // Create Orders table
                    string createOrders = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' AND xtype='U')
                        CREATE TABLE Orders (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            UserId INT FOREIGN KEY REFERENCES Users(Id),
                            CarId INT FOREIGN KEY REFERENCES Cars(Id),
                            TotalPrice DECIMAL(18,2) NOT NULL,
                            OrderDate DATETIME NOT NULL,
                            Status NVARCHAR(50) NOT NULL
                        )";
                    new SqlCommand(createOrders, conn).ExecuteNonQuery();

                    // Seed Cars Data if empty
                    string checkCars = "SELECT COUNT(*) FROM Cars";
                    int count = (int)new SqlCommand(checkCars, conn).ExecuteScalar();
                    if (count == 0)
                    {
                        string insertCars = @"
                            INSERT INTO Cars (Model, Year, Price, OTV, KDV, Stock, ImagePath) VALUES
                            ('Porsche 911 Carrera', 2024, 6000000, 2.20, 0.20, 5, 'car1.jpg'),
                            ('Porsche Taycan 4S', 2024, 4500000, 0.40, 0.20, 3, 'car2.jpg'),
                            ('Porsche Macan GTS', 2024, 5500000, 2.20, 0.20, 7, 'car3.jpg')";
                        new SqlCommand(insertCars, conn).ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // In a real app we might log this, for now we will throw so we can see the issue.
                throw new Exception("Database initialization failed. Please ensure LocalDB is installed or update ConnectionString. Error: " + ex.Message);
            }
        }
    }
}
