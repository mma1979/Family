CREATE TABLE [dbo].[Children] (
    [ChildId]   INT            IDENTITY (1, 1) NOT NULL,
    [ChildName] NVARCHAR (250) NULL,
    [ChildAge]  INT            NOT NULL,
    [IsAlive]   BIT            NOT NULL default 1,
    [FatherId]     INT            NOT NULL,
    [MotherId]   INT            NOT NULL,
    CONSTRAINT [PK_dbo.Children] PRIMARY KEY CLUSTERED ([ChildId] ASC),
    CONSTRAINT [FK_dbo.Children_dbo.Men_ManId] FOREIGN KEY ([FatherId]) REFERENCES [dbo].[Men] ([ManId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Children_dbo.Women_WomanId] FOREIGN KEY ([MotherId]) REFERENCES [dbo].[Women] ([WomanId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ManId]
    ON [dbo].[Children]([FatherId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_WomanId]
    ON [dbo].[Children]([MotherId] ASC);

