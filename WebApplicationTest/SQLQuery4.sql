﻿
USE info
GO

CREATE TABLE test(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
name NVARCHAR(50) NOT NULL,
age INT
)
GO

INSERT INTO test(name, age) VALUES
(N'nameONe',12)
GO 