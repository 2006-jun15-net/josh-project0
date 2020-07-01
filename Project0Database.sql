CREATE TABLE Product 
(
	productId int PRIMARY KEY IDENTITY,
	productDescription nvarchar(25) NOT NULL,
	productPrice decimal
);

CREATE TABLE Customer 
(
	customerId int PRIMARY KEY IDENTITY,
	firstName nvarchar(25) NOT NULL,
	lastName nvarchar(30) NOT NULL
);

CREATE TABLE Store
(
	storeId int PRIMARY KEY IDENTITY,
	storeName nvarchar(30) NOT NULL,
	storeAddress nvarchar(50) NULL
);

CREATE TABLE StoreInventory (
	storeInvId int PRIMARY KEY IDENTITY,
	storeId int,
	productId int,
	CONSTRAINT FK_STORE FOREIGN KEY (storeId) References Store(storeId),
	CONSTRAINT FK_PRODUCT FOREIGN KEY (productId) References Product(productId)
);

CREATE TABLE Order {

};

CREATE TABLE OrderHistory (
	OrderHistoryId int PRIMARY KEY IDENTITY,
	storeId int,
	customerId int,
	orderId int,
	productId int,
	CONSTRAINT FK_STORE_ID FOREIGN KEY (storeId) References Store(storeId),
	CONSTRAINT FK_CUSTOMER_ID FOREIGN KEY (customerId) References Customer(customerId),
	CONSTRAINT FK_PRODUCT_ID FOREIGN KEY (productId) References Product(productId)
);


INSERT INTO Product (productDescription, productPrice) VALUES ('Pencil', 0.50);

INSERT INTO Product (productDescription, productPrice) VALUES (
	{'Eraser', 0.75},
	{'Laptop', 599.00},
	{'Charging Cable', 75.00},
	{'Software', 139.99}	
);