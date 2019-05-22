CREATE TABLE [dbo].[SUBTASKS]
(
	[ID]      INT            IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [TaskID]  INT            NULL,
    [Subtask] NVARCHAR (MAX) NULL,
    [isCheck] BIT            NULL,
    CONSTRAINT [FK_SUBTASKS_TASKS] FOREIGN KEY ([TaskID]) REFERENCES [dbo].[TASKS] ([ID])
)
