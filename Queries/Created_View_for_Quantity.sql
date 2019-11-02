SELECT itm.ItemID, itm.ItemName, itm.ReorderLabel, itm.CompanyId, SUM(SI.Quantity - SO.Quantity) AS Quantity
FROM     dbo.tbl_items AS itm INNER JOIN
                  dbo.tbl_StockIn AS SI ON itm.ItemID = SI.ItemId INNER JOIN
                  dbo.tbl_StockOut AS SO ON itm.ItemID = SO.ItemId
GROUP BY itm.ItemID, itm.ItemName, itm.ReorderLabel, itm.CompanyId