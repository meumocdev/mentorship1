Create database NewsDev
use NewsDev

CREATE TABLE [Provider] (
  [ProviderId] INT PRIMARY KEY IDENTITY(1, 1),
  [ProviderName] NVARCHAR(255),
  [ProviderSource] NVARCHAR(255)
)
GO

CREATE TABLE [Category] (
  [CategoryId] INT PRIMARY KEY IDENTITY(1, 1),
  [CategoryName] NVARCHAR(255),
  [ProviderId] INT,
  [CategorySource] NVARCHAR(255),
  [Categoryttl] INT,
  [Categorygenerator] NVARCHAR(255),
  [Categorydocs] NVARCHAR(255)
)
GO

CREATE TABLE [Item] (
  [ItemId] INT PRIMARY KEY IDENTITY(1, 1),
  [ItemTitle] NVARCHAR(255),
  [ItemLink] NVARCHAR(255),
  [ItemGuid] NVARCHAR(255),
  [ItemPubDate] DATETIME,
  [ItemImage] NVARCHAR(255),
  [CategoryId] INT,
  [Itemauthor] NVARCHAR(255),
  [Itemsummary] NVARCHAR(MAX),
  [Itemcomments] NVARCHAR(255)
)
GO

CREATE TABLE [Tag] (
  [TagId] INT PRIMARY KEY IDENTITY(1, 1),
  [TagName] NVARCHAR(255),
  [Tagdescription] NVARCHAR(255)
)
GO

CREATE TABLE [NewTag] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1),
  [NewId] INT,
  [TagId] INT
)
GO

CREATE TABLE [User] (
  [UserId] INT PRIMARY KEY IDENTITY(1, 1),
  [UserName] NVARCHAR(255),
  [UserPassword] varchar(255)
)
GO

CREATE TABLE [UserCategory] (
  [UserCategoryId] INT PRIMARY KEY IDENTITY(1, 1),
  [UserId] INT,
  [CategoryId] INT
)
GO

CREATE TABLE [UserTag] (
  [UserTagId] INT PRIMARY KEY IDENTITY(1, 1),
  [UserId] INT,
  [TagId] INT
)
GO

CREATE TABLE [TableConfig] (
  [TableConfigId] INT PRIMARY KEY IDENTITY(1, 1),
  [UserId] INT,
  [TableConfigMostLiked] INT,
  [TableConfigMostRead] INT,
  [TableConfigMostTagged] INT,
  [TableConfigFavoriteCategory] INT
)
GO

ALTER TABLE [Category] ADD FOREIGN KEY ([ProviderId]) REFERENCES [Provider] ([ProviderId])
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId])
GO

ALTER TABLE [UserTag] ADD FOREIGN KEY ([TagId]) REFERENCES [Tag] ([TagId])
GO

ALTER TABLE [UserTag] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [NewTag] ADD FOREIGN KEY ([TagId]) REFERENCES [Tag] ([TagId])
GO

ALTER TABLE [UserCategory] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
GO

ALTER TABLE [UserCategory] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([CategoryId])
GO

ALTER TABLE [TableConfig] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
GO
