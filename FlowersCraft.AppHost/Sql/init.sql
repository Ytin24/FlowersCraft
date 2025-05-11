/*──────────────────────────────────────────────
  0.  Создание БД и переход в неё
──────────────────────────────────────────────*/
IF DB_ID(N'FlowersCraft') IS NULL
    CREATE DATABASE FlowersCraft
      COLLATE Cyrillic_General_100_CS_AS_SC_UTF8; 
GO
USE FlowersCraft;
GO

/*──────────────────────────────────────────────
  1.  Справочники (Lookup tables)
──────────────────────────────────────────────*/
CREATE TABLE dbo.ProductCategories
(
    Id   INT           IDENTITY(1,1)  PRIMARY KEY,
    Name VARCHAR(100)  NOT NULL UNIQUE
);
GO

INSERT dbo.ProductCategories (Name) VALUES
  (N'Букеты'), (N'Комнатные растения'), (N'Сопутствующие товары');
GO

CREATE TABLE dbo.OrderStatuses
(
    Code VARCHAR(20) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO

INSERT dbo.OrderStatuses (Code, Name) VALUES
  ('New',        N'Новый'),
  ('Paid',       N'Оплачен'),
  ('Shipped',    N'Отправлен'),
  ('Cancelled',  N'Отменён');
GO

CREATE TABLE dbo.ChatSenders
(
    Code VARCHAR(20) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

INSERT dbo.ChatSenders (Code, Name) VALUES
  ('Assistant', N'Нейросеть'),
  ('System',    N'Система'),
  ('Tool',      N'ИИ инструмент'),
  ('User',      N'Клиент');
GO

/*──────────────────────────────────────────────
  2.  Основные сущности
──────────────────────────────────────────────*/
CREATE TABLE dbo.Users
(
    Id               BIGINT        IDENTITY(1,1)   NOT NULL,
    Platform         VARCHAR(50)   NOT NULL,
    PlatformUserId   BIGINT        NOT NULL,
    FirstName        NVARCHAR(100) NULL,
    LastName         NVARCHAR(100) NULL,
    PhoneNumber      VARCHAR(20)   NULL,
    RegistrationDate DATETIME2(3)  NOT NULL  DEFAULT SYSUTCDATETIME(),
    IsActive         BIT           NOT NULL  DEFAULT 1,
    CONSTRAINT PK_Users              PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT UQ_Users_PlatformUser UNIQUE (Platform, PlatformUserId)
);
GO

CREATE TABLE dbo.Products
(
    Id            INT            IDENTITY(1,1)  NOT NULL,
    Name          NVARCHAR(255)  NOT NULL,
    CategoryId    INT            NOT NULL,
    Price         DECIMAL(10,2)  NOT NULL,
    IsAvailable   BIT            NOT NULL  DEFAULT 1,
    CreatedDate   DATETIME2(3)   NOT NULL  DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Products            PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Products_Category   FOREIGN KEY (CategoryId)
                                         REFERENCES dbo.ProductCategories(Id),
    CONSTRAINT CK_Products_Price      CHECK (Price >= 0)
);
GO
CREATE INDEX IX_Products_CategoryId ON dbo.Products(CategoryId);

CREATE TABLE dbo.Orders
(
    Id            INT            IDENTITY(1,1)  NOT NULL,
    UserId        BIGINT         NOT NULL,
    Status        VARCHAR(20)    NOT NULL
                                 CONSTRAINT FK_Orders_Status
                                   REFERENCES dbo.OrderStatuses(Code),
    Comments      NVARCHAR(MAX)  NULL,
    CreatedDate   DATETIME2(3)   NOT NULL  DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Orders            PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Orders_User       FOREIGN KEY (UserId)
                                      REFERENCES dbo.Users(Id)
                                      ON DELETE CASCADE
);
GO
CREATE INDEX IX_Orders_UserId_CreatedDate ON dbo.Orders(UserId, CreatedDate DESC);

CREATE TABLE dbo.OrderItems
(
    Id            INT            IDENTITY(1,1)  NOT NULL,
    OrderId       INT            NOT NULL,
    ProductId     INT            NOT NULL,
    ProductName   NVARCHAR(255)  NOT NULL,
    Price         DECIMAL(10,2)  NOT NULL,
    Quantity      INT            NOT NULL,
    CONSTRAINT PK_OrderItems         PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_OrderItems_Order   FOREIGN KEY (OrderId)
                                        REFERENCES dbo.Orders(Id)
                                        ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_Product FOREIGN KEY (ProductId)
                                        REFERENCES dbo.Products(Id),
    CONSTRAINT CK_OrderItems_Price      CHECK (Price >= 0),
    CONSTRAINT CK_OrderItems_Quantity   CHECK (Quantity > 0)
);
GO
CREATE INDEX IX_OrderItems_OrderId   ON dbo.OrderItems(OrderId);
CREATE INDEX IX_OrderItems_ProductId ON dbo.OrderItems(ProductId);

CREATE TABLE dbo.ChatMessages
(
    Id          INT            IDENTITY(1,1)  NOT NULL,
    UserId      BIGINT         NOT NULL,
    [Content]   NVARCHAR(MAX)  NULL,
    Sender      VARCHAR(20)    NOT NULL
                              CONSTRAINT FK_ChatMessages_Sender
                                REFERENCES dbo.ChatSenders(Code),
    [Timestamp] DATETIME2(3)   NOT NULL  DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_ChatMessages     PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_ChatMessages_User FOREIGN KEY (UserId)
                                       REFERENCES dbo.Users(Id)
                                       ON DELETE CASCADE
);
GO
CREATE INDEX IX_ChatMessages_UserId_Timestamp ON dbo.ChatMessages(UserId, [Timestamp] DESC);