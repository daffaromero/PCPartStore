CREATE TABLE [dbo].[ProdTable] (
    [ProdID]    INT           NOT NULL,
    [ProdName]  NVARCHAR (30) NOT NULL,
    [ProdQty]   INT           NOT NULL,
    [ProdPrice] INT           NOT NULL,
    [ProdCat]   NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProdID] ASC)
);

