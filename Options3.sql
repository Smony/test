--выбор базы
USE info
GO

--вывод данных
SELECT * 
FROM Options
WHERE (id % 3) = 0
GO