CREATE TABLE [dbo].[Books]
(
	[BookId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NOT NULL, 
    [Author] VARCHAR(50) NOT NULL, 
    [Publisher] VARCHAR(50) NULL, 
    [Year] VARCHAR(50) NULL, 
    [ISBN] VARCHAR(50) NULL, 
    [Type] VARCHAR(50) NULL, 
    [Copies] INT NULL, 
    [Available] INT NULL,
    [Checkedout] VARCHAR(50) NOT NULL
)

