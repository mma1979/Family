CREATE TABLE [dbo].[Women] (
    [WomanId]   INT            IDENTITY (1, 1) NOT NULL,
    [WomanName] NVARCHAR (250) NULL,
    [WomanAge]  INT            NOT NULL,
    [IsAlive]   BIT            NOT NULL default 1,
    [HasbundId] INT            NULL,
    CONSTRAINT [PK_dbo.Women] PRIMARY KEY CLUSTERED ([WomanId] ASC),
    CONSTRAINT [FK_dbo.Women_dbo.Men_ManId] FOREIGN KEY  ([HasbundId]) REFERENCES [dbo].[Men] ([ManId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Man_ManId]
    ON [dbo].[Women]([HasbundId] ASC);

