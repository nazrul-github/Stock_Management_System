CREATE TABLE tbl_company (
CompanyId INT IDENTITY PRIMARY KEY,
CompanyName NVARCHAR(50) UNIQUE NOT NULL
);
SELECT * FROM tbl_company WHERE CompanyName = 'A'

DELETE FROM tbl_company WHERE CompanyName = 'A';

INSERT INTO tbl_company VALUES('A');