﻿CREATE TABLE [dbo].[Login]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] VARCHAR(30) NOT NULL UNIQUE, 
    [Password] VARBINARY(30) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL UNIQUE
)
