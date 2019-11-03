CREATE VIEW tbl_ItemsAvailableQuantity
AS
SELECT IT.ItemID,IT.ItemName,IT.ReorderLabel,SUM(IT.StockIn - IT.StockOut) AS Quantity FROM tbl_Items AS IT
GROUP BY IT.ItemID,IT.ItemName,IT.ReorderLabel;

SELECT * FROM tbl_ItemsAvailableQuantity;

SELECT StockIn FROM tbl_Items WHERE CompanyId = 1 AND ItemID = 1;

INSERT INTO tbl_Items (StockIn) VALUES(15)  CompanyId = 1 AND ItemID = 1;



