CREATE PROCEDURE
@CompanyId INT,
@CategoryId INT
AS
BEGIN
INSERT INTO tbl_Items VALUES(@ItemName,@ReorderLabel,@CompanyId,@CategoryId)
END;

SELECT ItemID,ItemName FROM tbl_items;