CREATE TABLE [dbo].[tblPlayerData] (
  [id] INT IDENTITY PRIMARY KEY,
  [nome] VARCHAR(max),
  [ranking] VARCHAR(max) NOT NULL,
  [score] FLOAT NOT NULL
)
