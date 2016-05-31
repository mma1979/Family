CREATE TABLE [dbo].[Men] (
    [ManId]   INT            IDENTITY (1, 1) NOT NULL,
    [ManName] NVARCHAR (250) NULL,
    [ManAge]  INT            NOT NULL,
    [IsAlive] BIT            NOT NULL default 1,
    CONSTRAINT [PK_dbo.Men] PRIMARY KEY CLUSTERED ([ManId] ASC)
);

