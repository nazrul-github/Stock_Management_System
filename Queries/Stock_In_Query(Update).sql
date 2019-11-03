UPDATE tbl_Items
SET StockIn = @Quantity
WHERE CompanyId = @CompanyId AND ItemID = @ItemID;