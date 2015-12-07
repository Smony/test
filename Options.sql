--выбор базы
USE info
GO

--создание таблицы
IF NOT EXISTS(  
 SELECT name
 FROM sys.tables
 WHERE name = 'Options'
)
CREATE TABLE Options (
 id INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
 name NVARCHAR(50) NOT NULL, 
 value INT
)
GO

--вставляем данные
INSERT INTO Options(name, value) VALUES
(N'ааа', 1),
(N'ббб', 2),
(N'ввв', 3),
(N'ггг', 4),
(N'ддд', 5),
(N'еее', 6),
(N'ёёё', 7),
(N'жжж', 8),
(N'ззз', 9),
(N'иии', 10),
(N'ййй', 11),
(N'ккк', 12),
(N'ллл', 13),
(N'ммм', 14),
(N'ннн', 15)
GO