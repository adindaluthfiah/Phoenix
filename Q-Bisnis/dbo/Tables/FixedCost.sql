CREATE TABLE [dbo].[FixedCost] (
    [id]       INT            IDENTITY (1, 1) NOT NULL,
    [Kategori] NVARCHAR (50)  NOT NULL,
    [Nominal]  NUMERIC (18)   NOT NULL,
    [Note]     NVARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

