CREATE VIEW tbl_SalesSheet
AS
SELECT IT.ItemID, IT.ItemName, SL.Quantity,SL.StockOutTime FROM tbl_items AS IT JOIN
 tbl_Sales AS SL ON IT.ItemID = SL.ItemId;

 SELECT * FROM tbl_SalesSheet WHERE StockOutTime BETWEEN @Time AND @Time;