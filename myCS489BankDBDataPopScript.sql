
-- Insert dummy data 

-- Insert into AccountType
INSERT INTO AccountType (accountTypeId, accountTypeName) VALUES
(1, 'Checking'),
(2, 'Savings'),
(3, 'Loan');

-- Insert into Customer
INSERT INTO Customer (customerId, firstName, lastName, telephoneNumber) VALUES
(1, 'Daniel', 'Agar', NULL),
(2, 'Bernard', 'Shaw', '(641) 472-1234'),
(3, 'Carly', 'DeFiori', NULL);

-- Insert into Account
INSERT INTO Account (accountId, accountNumber, dateOpened, status, balance, accountTypeId) VALUES
(1, 'CK1089', '2021-10-15', 'Active', 105945.50, 2),
(2, 'SV1104', '2019-06-22', 'Active', 197750.00, 1),
(3, 'SV2307', '2014-02-27', 'Dormant', 842000.75, 1),
(4, 'LN4133', '2005-11-07', 'Active', 674500.00, 3);

-- Insert into Customer_Account
INSERT INTO Customer_Account (customerId, accountId) VALUES
(3, 1),    -- Account 1 owned by Customer 3
(1, 2),    -- Account 2 owned by Customers 1 and 2
(2, 2),
(3, 3),    -- Account 3 owned by Customer 3
(3, 4);    -- Account 4 owned by Customer 3

-- Insert into Transaction (assuming transactionId is assigned sequentially)
INSERT INTO Transaction (transactionId, transactionNumber, description, valueAmount, transactionDate, transactionTime, transactionType, accountId) VALUES
(1, 'D0187-175', 'Deposit to Savings', 100000.00, '2021-10-15', '12:15:00', 'Deposit', 2),
(2, 'W1736-142', 'Teller counter withdrawal', 550.00, '2022-08-24', '10:05:00', 'Withdrawal', 1),
(3, 'D0001-142', 'Direct deposit - wage', 2475.75, '2014-03-01', '05:00:00', 'Direct deposit', 1),
(4, 'P162-0017', 'Merch purchase online', 150.95, '2019-12-15', '14:19:00', 'Purchase', 1);