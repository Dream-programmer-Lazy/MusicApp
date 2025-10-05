CREATE TABLE [User] (
  [UserID] int PRIMARY KEY IDENTITY(1, 1),
  [UserName] nvarchar(100),
  [Password] nvarchar(100),
  [Email] nvarchar(100)
)
GO

CREATE TABLE [Song] (
  [SongID] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(200),
  [Artist] nvarchar(100),
  [Album] nvarchar(100),
  [Genre] nvarchar(50),
  [Duration] int,
  [FilePath] nvarchar(255),
  [ReleaseYear] int
)
GO

CREATE TABLE [Playlist] (
  [PlaylistID] int PRIMARY KEY IDENTITY(1, 1),
  [PlaylistName] nvarchar(100),
  [CreateDate] datetime,
  [UserID] int
)
GO

CREATE TABLE [Playlist_Song] (
  [PlaylistID] int,
  [SongID] int,
  [AddedDate] datetime,
  PRIMARY KEY ([PlaylistID], [SongID])
)
GO

CREATE TABLE [PlaybackHistory] (
  [HistoryID] int PRIMARY KEY IDENTITY(1, 1),
  [UserID] int,
  [SongID] int,
  [PlayDate] datetime
)
GO

ALTER TABLE [Playlist] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID])
GO

ALTER TABLE [Playlist_Song] ADD FOREIGN KEY ([PlaylistID]) REFERENCES [Playlist] ([PlaylistID])
GO

ALTER TABLE [Playlist_Song] ADD FOREIGN KEY ([SongID]) REFERENCES [Song] ([SongID])
GO

ALTER TABLE [PlaybackHistory] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID])
GO

ALTER TABLE [PlaybackHistory] ADD FOREIGN KEY ([SongID]) REFERENCES [Song] ([SongID])
GO
