CREATE TABLE [dbo].[Fixture]
(
	[fixtureID] INT IDENTITY(1,1) NOT NULL,
	[managerID] INT NOT NULL,
	[Team] NVARCHAR(100) NOT NULL,
	[teamManager] NVARCHAR(100) NOT NULL,
	[fixtureDateTime] DATETIME	NOT NULL,
	[Venue] NVARCHAR(100) NOT NULL,
	[Spent] MONEY NULL,
	CONSTRAINT PK_fixtureID PRIMARY KEY ([fixtureID]),
	CONSTRAINT FK_managerID FOREIGN KEY (managerID) REFERENCES Manager (managerID)

)
