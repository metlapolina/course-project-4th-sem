CREATE TABLE [dbo].[ATTACHMENTS] (
    [ID]        INT             IDENTITY (1, 1) NOT NULL,
    [UserID]    INT             NULL,
    [TaskID]    INT             NULL,
    [SubtaskID] INT             NULL,
    [ImagePath] NVARCHAR (100)   NULL,
    [Image]     VARBINARY (MAX) NULL,
    [FilePath]  NVARCHAR (100)   NULL,
    [File]      VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ATTACHMENTS_SUBTASKS] FOREIGN KEY ([SubtaskID]) REFERENCES [dbo].[SUBTASKS] ([ID]),
    CONSTRAINT [FK_ATTACHMENTS_USERS] FOREIGN KEY ([UserID]) REFERENCES [dbo].[USERS] ([ID]),
    CONSTRAINT [FK_ATTACHMENTS_TASKS] FOREIGN KEY ([TaskID]) REFERENCES [dbo].[TASKS] ([ID])
);

