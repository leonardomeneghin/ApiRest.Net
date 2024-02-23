CREATE TABLE [dbo].[tblBooks] (
  [id] INT IDENTITY PRIMARY KEY,
  [author] VARCHAR(max),
  [launch_date] DATETIME2 NOT NULL,
  [price] FLOAT NOT NULL,
  [title] VARCHAR(max)
)
