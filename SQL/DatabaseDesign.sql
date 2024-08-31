CREATE DATABASE IF NOT EXISTS ZapperExam;
USE ZapperExam;

CREATE TABLE IF NOT EXISTS Customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS Merchants (
    MerchantID INT AUTO_INCREMENT PRIMARY KEY,
    MerchantName VARCHAR(100) NOT NULL,
    ContactEmail VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15),
    Address VARCHAR(255),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS Transactions (
    TransactionID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT,
    MerchantID INT,
    TransactionDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Amount DECIMAL(10, 2) NOT NULL,
    Description TEXT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (MerchantID) REFERENCES Merchants(MerchantID)
);

-- Insert test data into Customers table
INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber)
VALUES 
('Carlo', 'Valdez', 'Carlo.Valdez@gmail.com', '555-1234'),
('John', 'Valdez', 'John.Valdez@gmail.com', '555-5678');

INSERT INTO Merchants (MerchantName, ContactEmail, PhoneNumber, Address)
VALUES 
('Jollibee Store', 'Jollibee@gmail.com', '555-9876', '123 Street Manila Philippines'),
('TimTams', 'TimTams@gmail.com', '555-4321', '456 Street, Brisbane, Australia');

INSERT INTO Transactions (CustomerID, MerchantID, TransactionDate, Amount, Description)
VALUES 
(1, 1, '2024-08-15 14:32:00', 99.99, 'Purchase of laptop'),
(2, 2, '2024-08-16 09:15:00', 5.50, 'Coffee and pastry');

SELECT 
    c.FirstName AS CustomerFirstName, 
    c.LastName AS CustomerLastName, 
    c.Email AS CustomerEmail, 
    m.MerchantID, 
    m.MerchantName, 
    t.TransactionDate, 
    t.Amount, 
    t.Description
FROM Transactions t 
INNER JOIN Customers c ON c.CustomerID = t.CustomerID 
INNER JOIN Merchants m ON m.MerchantID = t.MerchantID;

SELECT 
    m.MerchantID,
    m.MerchantName,
    SUM(t.Amount) AS TotalAmountReceived
FROM Transactions t
INNER JOIN Merchants m ON t.MerchantID = m.MerchantID
GROUP BY m.MerchantID, m.MerchantName;
