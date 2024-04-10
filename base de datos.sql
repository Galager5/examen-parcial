CREATE DATABASE EmpresaDB;
GO

USE EmpresaDB;
GO

CREATE TABLE Trabajadores(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellidos NVARCHAR(50),
    SueldoBruto DECIMAL(18, 2),
    Categoria NVARCHAR(1),
    MontoAumento AS CASE
        WHEN SueldoBruto <= 1000 THEN SueldoBruto * 0.10
        WHEN SueldoBruto <= 2000 THEN SueldoBruto * 0.20
        WHEN SueldoBruto <= 4000 THEN SueldoBruto * 0.30
        ELSE SueldoBruto * 0.40
    END,
    SueldoNeto AS SueldoBruto + MontoAumento
);
GO