CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS "Transactions" (
    "Id" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    "TransactionId" UUID DEFAULT uuid_generate_v4(),
    "CardNumber" VARCHAR(255),
    "ExpirationDate" VARCHAR(10),
    "HolderName" VARCHAR(255),
    "SecurityCode" VARCHAR(4),
    "Amount" DECIMAL(10, 2),
    "Currency" VARCHAR(3),
    "TransactionDate" TIMESTAMP,
    "Status" VARCHAR(50) DEFAULT 'Pending'
);

