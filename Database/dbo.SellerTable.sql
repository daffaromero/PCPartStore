CREATE TABLE [dbo].[SellerTable] (
    [SellerID]    INT           NOT NULL,
    [SellerPwd]   NVARCHAR (30) NOT NULL,
    [SellerName]  NVARCHAR (20) NOT NULL,
    [SellerPhone] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([SellerID] ASC)
);

