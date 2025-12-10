DROP DATABASE IF EXISTS library_db;
CREATE DATABASE library_db;
USE library_db;

-- Tabla Books (Libros) [cite: 35]
CREATE TABLE Books (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(200) NOT NULL,
    Author VARCHAR(150) NOT NULL,
    ISBN VARCHAR(20) NOT NULL UNIQUE, -- El ISBN debe ser único [cite: 41]
    Stock INT NOT NULL,
    CreatedAt DATETIME NOT NULL
);

-- Tabla Loans (Préstamos) [cite: 37]
CREATE TABLE Loans (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    BookId INT NOT NULL,
    StudentName VARCHAR(150) NOT NULL,
    LoanDate DATETIME NOT NULL,
    ReturnDate DATETIME NULL,
    Status VARCHAR(20) NOT NULL, -- 'Active', 'Returned'
    CreatedAt DATETIME NOT NULL,
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);

-- Insertar datos de prueba (Opcional, pero recomendado para probar luego)
INSERT INTO Books (Title, Author, ISBN, Stock, CreatedAt) VALUES 
('Cien Años de Soledad', 'Gabriel Garcia Marquez', '978-0307474728', 5, NOW()),
('Clean Code', 'Robert C. Martin', '978-0132350884', 2, NOW());