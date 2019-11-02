DELETE FROM tbl_Category;

DBCC CHECKIDENT ('tbl_Category', RESEED, 0);
GO

