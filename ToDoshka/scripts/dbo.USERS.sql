CREATE TABLE [dbo].[USERS]
(
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [User] NVARCHAR(20) NOT NULL, 
    [Password] NVARCHAR(20) NOT NULL, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Surname] NVARCHAR(20) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(20) NULL, 
    [Contact] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(100) NULL
)
