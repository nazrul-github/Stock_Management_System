CREATE TABLE tbl_Items(
ItemID INT IDENTITY PRIMARY KEY,
ItemName NVARCHAR(50) UNIQUE NOT NULL,
ReorderLaebl INT NOT NULL,
CompanyId INT CONSTRAINT FK_tblCompany_CompanyId FOREIGN KEY (CompanyId)
        REFERENCES tbl_company (CompanyId),
CategoryId INT CONSTRAINT FK_tblCategory_CatgoryId FOREIGN KEY (CategoryId)
REFERENCES tbl_Category (CategoryID)
)