Create database newsaggregation
drop database newsaggregation
use newsaggregation
use BanHang
CREATE TABLE [User] (
  [UserID] int PRIMARY KEY,
  [Username] nvarchar UNIQUE,
  [UserPassword] nvarchar,
  [Email] nvarchar UNIQUE,
  [Role] nvarchar,
  [Preferences] nvarchar,
  [Created_At] datetime,
  [Updated_At] datetime,
  [Last_Login] datetime
)
GO

CREATE TABLE [News] (
  [NewsID] int PRIMARY KEY,
  [Title] nvarchar,
  [Description] text,
  [Tag] nvarchar,
  [Created_At] datetime,
  [Updated_At] datetime,
  [CategoryID] int,
  [Author] nvarchar,
  [Image_URL] nvarchar,
  [Language] nvarchar,
  [Content] text,
  [Views] int,
  [Likes] int,
  [SourceID] int,
  [Status] nvarchar
)
GO

CREATE TABLE [RSS] (
  [SourceID] int PRIMARY KEY,
  [SourceName] nvarchar,
  [URL] nvarchar,
  [Fetch_Interval] int,
  [Created_At] datetime,
  [Updated_At] datetime,
  [Status] nvarchar,
  [Language] nvarchar,
  [Country] nvarchar
)
GO

CREATE TABLE [Category] (
  [CategoryID] int PRIMARY KEY,
  [CategoryName] nvarchar,
  [Description] text,
  [Created_At] datetime,
  [Updated_At] datetime
)
GO

CREATE TABLE [Comments] (
  [CommentID] int PRIMARY KEY,
  [UserID] int,
  [NewsID] int,
  [Content] text,
  [Created_At] datetime,
  [Updated_At] datetime,
  [Likes] int,
  [Status] nvarchar
)
GO

CREATE TABLE [Likes] (
  [LikeID] int PRIMARY KEY,
  [UserID] int,
  [NewsID] int,
  [Liked_At] datetime
)
GO

CREATE TABLE [Views] (
  [ViewID] int PRIMARY KEY,
  [UserID] int,
  [NewsID] int,
  [Viewed_At] datetime,
  [IP_Address] nvarchar
)
GO

CREATE TABLE [Notification] (
  [NotificationID] int PRIMARY KEY,
  [UserID] int,
  [Type] nvarchar,
  [Message] nvarchar,
  [Is_Read] bit,
  [Created_At] datetime
)
GO

ALTER TABLE [News] ADD FOREIGN KEY ([CategoryID]) REFERENCES [Category] ([CategoryID])
GO

ALTER TABLE [News] ADD FOREIGN KEY ([SourceID]) REFERENCES [RSS] ([SourceID])
GO

ALTER TABLE [Comments] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID])
GO

ALTER TABLE [Comments] ADD FOREIGN KEY ([NewsID]) REFERENCES [News] ([NewsID])
GO

ALTER TABLE [Likes] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID])
GO

ALTER TABLE [Likes] ADD FOREIGN KEY ([NewsID]) REFERENCES [News] ([NewsID])
GO

ALTER TABLE [Views] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID])
GO

ALTER TABLE [Views] ADD FOREIGN KEY ([NewsID]) REFERENCES [News] ([NewsID])
GO

ALTER TABLE [Notification] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID])
GO
