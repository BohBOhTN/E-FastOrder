-- Use the database
USE EFastOrderDB;
GO
-- Insert data into Roles table
INSERT INTO Roles (RoleName)
VALUES
    ('Admin'), -- Role for administrators
    ('User'); -- Role for regular users
GO

-- Insert data into Users table
INSERT INTO Users (Username, PasswordHash, Email, RoleId)
VALUES
    ('admin', 'hashed_password', 'admin@example.com', 1), -- Admin user
    ('user1', 'hashed_password1', 'user1@example.com', 2), -- Regular user
    ('user2', 'hashed_password2', 'user2@example.com', 2); -- Regular user
GO

-- Insert data into MenuItems table
INSERT INTO MenuItems (Name, Description, Price, Category)
VALUES
    ('Burger', 'Juicy grilled beef burger', 7.99, 'Main Course'),
    ('Pizza', 'Cheese and tomato pizza', 8.99, 'Main Course'),
    ('Fries', 'Crispy French fries', 3.99, 'Side Dish'),
    ('Salad', 'Fresh garden salad', 4.99, 'Appetizer'),
    ('Brownie', 'Chocolate brownie dessert', 5.49, 'Dessert');
GO

-- Insert data into Orders table
INSERT INTO Orders (UserId, OrderDate, TotalPrice, OrderStatus)
VALUES
    (2, GETDATE(), 11.98, 'On Cue'), -- User1's order
    (3, GETDATE(), 13.99, 'On Cue'); -- User2's order
GO

-- Insert data into OrderDetails table
INSERT INTO OrderDetails (OrderId, MenuItemId, Quantity, Price)
VALUES
    (1, 1, 1, 7.99), -- 1 Burger for Order 1
    (1, 3, 1, 3.99), -- 1 Fries for Order 1
    (2, 2, 1, 8.99), -- 1 Pizza for Order 2
    (2, 4, 1, 4.99); -- 1 Salad for Order 2
GO

-- Insert data into FavoriteMenuItems table
INSERT INTO FavoriteMenuItems (UserId, MenuItemId)
VALUES
    (2, 1), -- User1's favorite menu item: Burger
    (3, 2); -- User2's favorite menu item: Pizza
GO
