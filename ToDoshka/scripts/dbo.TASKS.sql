CREATE TABLE [dbo].[TASKS]
(
	[ID]         INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [UserID]     INT            NOT NULL,
    [Task]       NVARCHAR (MAX) NOT NULL,
    [Time]       SMALLDATETIME  NULL,
    [Importance] INT            NULL,
    [IsWork]     BIT            NULL,
    [isCheck]    BIT            NULL,
    [CheckTime]  SMALLDATETIME  NULL,
    CONSTRAINT [FK__TASKS__UserID__3C69FB99] FOREIGN KEY ([UserID]) REFERENCES [dbo].[USERS] ([ID])
)
