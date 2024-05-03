-- Create database
CREATE DATABASE EFastOrderDB;
GO

-- Use the database
USE EFastOrderDB;
GO

-- Create Roles table
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);
GO

-- Create Users table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    RoleId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);
GO

-- Create MenuItems table
CREATE TABLE MenuItems (
    MenuItemId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(250),
    Price DECIMAL(10,2) NOT NULL,
    Category NVARCHAR(50)
);
GO

-- Create Orders table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalPrice DECIMAL(10,2) NOT NULL,
    OrderStatus NVARCHAR(50) NOT NULL, -- Status values: "On Cue", "Under Preparation", "On Its Way", "Delivered"
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    MenuItemId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (MenuItemId) REFERENCES MenuItems(MenuItemId)
);
GO

-- Create FavoriteMenuItems table
CREATE TABLE FavoriteMenuItems (
    FavoriteMenuItemId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    MenuItemId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (MenuItemId) REFERENCES MenuItems(MenuItemId)
);
GO
