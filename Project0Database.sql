CREATE TABLE Product 
(
	productId nvarchar(10) PRIMARY KEY,
	productDescription nvarchar(25) NOT NULL,
	productPrice decimal
);

CREATE TABLE Customer 
(
	customerId nvarchar(10) PRIMARY KEY,
	firstName nvarchar(25) NOT NULL,
	lastName nvarchar(30) NOT NULL
);

CREATE TABLE Store
(
	storeId nvarchar(10) PRIMARY KEY,
	storeName nvarchar(30) NOT NULL,
	storeAddress nvarchar(50) NULL
);