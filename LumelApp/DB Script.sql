CREATE TABLE [Customers] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Name] nvarchar(100) NOT NULL,
	[Email] nvarchar(250) NOT NULL UNIQUE,
	[Address] nvarchar(500) NOT NULL,
	[Age] int,
	[Gender] nvarchar(20) NOT NULL,
	[IsActive] bit NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Products] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Description] nvarchar(500) NOT NULL,
	[ProductCategoryId] int NOT NULL,
	[AvailableQuantity] float(53) NOT NULL,
	[IsActive] bit NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [ProductCategories] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Code] nvarchar(50) NOT NULL,
	[Description] nvarchar(250) NOT NULL,
	[IsActive] bit NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [Orders] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[CustomerId] int NOT NULL,
	[NoOfItems] int NOT NULL,
	[Value] float(53) NOT NULL,
	[PaymentMethodId] int NOT NULL,
	[DateOfSale] datetime NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [PaymentMethods] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Code] nvarchar(10) NOT NULL,
	[Description] nvarchar(100) NOT NULL,
	[IsActive] bit NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [OrderItems] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[OrderId] int NOT NULL,
	[ProductId] int NOT NULL,
	[Quantity] int NOT NULL,
	[UnitPrice] float(53) NOT NULL,
	[DiscountTypeId] int NOT NULL,
	[DiscountValue] float(53) NOT NULL,
	[ShipmentCost] float(53) NOT NULL,
	[EstimatedDeliveryDate] datetime NOT NULL,
	[ActualDeliveryDate] datetime NOT NULL,
	[OrderStausId] int NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [OrderStatuses] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Code] nvarchar(10) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[IsActive] bit NOT NULL,
	PRIMARY KEY ([Id])
);

CREATE TABLE [DiscountTypes] (
	[Id] int IDENTITY(1,1) NOT NULL UNIQUE,
	[Code] nvarchar(10) NOT NULL,
	[Description] nvarchar(100) NOT NULL,
	[IsActive] bit NOT NULL,
	PRIMARY KEY ([Id])
);


ALTER TABLE [Products] ADD CONSTRAINT [Products_fk2] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategories]([Id]);

ALTER TABLE [Orders] ADD CONSTRAINT [Orders_fk1] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id]);

ALTER TABLE [Orders] ADD CONSTRAINT [Orders_fk4] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods]([Id]);

ALTER TABLE [OrderItems] ADD CONSTRAINT [OrderItems_fk1] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]);

ALTER TABLE [OrderItems] ADD CONSTRAINT [OrderItems_fk2] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]);

ALTER TABLE [OrderItems] ADD CONSTRAINT [OrderItems_fk5] FOREIGN KEY ([DiscountTypeId]) REFERENCES [DiscountTypes]([Id]);

ALTER TABLE [OrderItems] ADD CONSTRAINT [OrderItems_fk10] FOREIGN KEY ([OrderStausId]) REFERENCES [OrderStatuses]([Id]);

