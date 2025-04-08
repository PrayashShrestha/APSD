-- Create AccountType table
CREATE TABLE AccountType (
    accountTypeId INT PRIMARY KEY,
    accountTypeName VARCHAR(50) NOT NULL
);

-- Create Customer table
CREATE TABLE Customer (
    customerId INT PRIMARY KEY,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    telephoneNumber VARCHAR(20)
);

-- Create Account table with foreign key to AccountType
CREATE TABLE Account (
    accountId BIGINT PRIMARY KEY,
    accountNumber VARCHAR(20) NOT NULL UNIQUE,
    dateOpened DATE NOT NULL,
    status VARCHAR(20) NOT NULL,
    balance DECIMAL(15,2) NOT NULL,
    accountTypeId INT NOT NULL,
    FOREIGN KEY (accountTypeId) REFERENCES AccountType(accountTypeId)
);

-- Create Transaction table with foreign key to Account
CREATE TABLE Transaction (
    transactionId INT PRIMARY KEY,
    transactionNumber VARCHAR(20) NOT NULL UNIQUE,
    description VARCHAR(100) NOT NULL,
    valueAmount DECIMAL(15,2) NOT NULL,
    transactionDate DATE NOT NULL,
    transactionTime TIME NOT NULL,
    transactionType VARCHAR(20),
    accountId BIGINT NOT NULL,
    FOREIGN KEY (accountId) REFERENCES Account(accountId)
);

-- Create Customer_Account junction table for many-to-many relationship
CREATE TABLE Customer_Account (
    customerId INT,
    accountId BIGINT,
    PRIMARY KEY (customerId, accountId),
    FOREIGN KEY (customerId) REFERENCES Customer(customerId),
    FOREIGN KEY (accountId) REFERENCES Account(accountId)
);

