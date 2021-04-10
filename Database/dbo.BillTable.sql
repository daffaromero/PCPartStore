CREATE TABLE [dbo].[BillTable] (
    [BillID]      INT           NOT NULL,
    [SellerName]  NVARCHAR (25) NOT NULL,
    [BillDate]    NVARCHAR (25) NOT NULL,
    [TotalAmount] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([BillID] ASC)
);

