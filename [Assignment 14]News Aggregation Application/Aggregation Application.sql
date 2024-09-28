CREATE TABLE [User] (
  [UserID] UUID PRIMARY KEY,
  [Username] string UNIQUE,
  [UserPassword] string,
  [Email] string UNIQUE,
  [Role] string,
  [Preferences] JSON,
  [Created_At] datetime,
  [Updated_At] datetime,
  [Last_Login] datetime
)
GO

CREATE TABLE [News] (
  [NewsID] UUID PRIMARY KEY,
  [Title] string,
  [Description] text,
  [Tag] JSON,
  [Created_At] datetime,
  [Updated_At] datetime,
  [CategoryID] UUID,
  [Author] string,
  [Image_URL] string,
  [Language] string,
  [Content] text,
  [Views] int,
  [Likes] int,
  [SourceID] UUID,
  [Status] string
)
GO

CREATE TABLE [RSS] (
  [SourceID] UUID PRIMARY KEY,
  [SourceName] string,
  [URL] string,
  [Fetch_Interval] int,
  [Created_At] datetime,
  [Updated_At] datetime,
  [Status] string,
  [Language] string,
  [Country] string
)
GO

CREATE TABLE [Category] (
  [CategoryID] UUID PRIMARY KEY,
  [CategoryName] string,
  [Description] text,
  [Created_At] datetime,
  [Updated_At] datetime
)
GO

CREATE TABLE [Comments] (
  [CommentID] UUID PRIMARY KEY,
  [UserID] UUID,
  [NewsID] UUID,
  [Content] text,
  [Created_At] datetime,
  [Updated_At] datetime,
  [Likes] int,
  [Status] string
)
GO

CREATE TABLE [Likes] (
  [LikeID] UUID PRIMARY KEY,
  [UserID] UUID,
  [NewsID] UUID,
  [Liked_At] datetime
)
GO

CREATE TABLE [Views] (
  [ViewID] UUID PRIMARY KEY,
  [UserID] UUID,
  [NewsID] UUID,
  [Viewed_At] datetime,
  [IP_Address] string
)
GO

CREATE TABLE [Notification] (
  [NotificationID] UUID PRIMARY KEY,
  [UserID] UUID,
  [Type] string,
  [Message] string,
  [Is_Read] boolean,
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
