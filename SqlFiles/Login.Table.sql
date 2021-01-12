CREATE TABLE [Login].[Table]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [Username] TEXT NOT NULL UNIQUE, 
    [Password] TEXT NOT NULL, 
    [Email] TEXT NOT NULL UNIQUE
)
