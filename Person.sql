--выбор базы
USE info
GO

--создание таблицы
IF NOT EXISTS(  
 SELECT name
 FROM sys.tables
 WHERE name = 'Person'
)
CREATE TABLE Person (
 id INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
 name NVARCHAR(50) NOT NULL,
 surname NVARCHAR(50) NOT NULL, 
 age INT, 
 work NVARCHAR(50)
)
GO

--вставляем данные
INSERT INTO Person(name, surname, age, work) VALUES
(N'Антон', N'Антонов', 41, N'Бухгалтер')
GO