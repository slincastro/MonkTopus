CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS "Transactions" (
    "Id" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),  -- Uses the uuid_generate_v4() function
    "CardNumber" VARCHAR(255),
    "ExpirationDate" VARCHAR(10),
    "HolderName" VARCHAR(255),
    "SecurityCode" VARCHAR(4),
    "Amount" DECIMAL(10, 2),           -- Added Amount column
    "Currency" VARCHAR(3),             -- Added Currency column
    "TransactionDate" TIMESTAMP,       -- Added TransactionDate column
    "Status" VARCHAR(50) DEFAULT 'Pending' -- Added Status column with default value 'Pending'
);

