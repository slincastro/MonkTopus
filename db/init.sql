
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS "Items" (
    "Id" UUID PRIMARY KEY DEFAULT uuid_generate_v4(),  -- Uses the uuid_generate_v4() function
    "CardNumber" VARCHAR(255),
    "ExpirationMonth" VARCHAR(2),
    "ExpirationYear" VARCHAR(4),
    "HolderName" VARCHAR(255),
    "SecurityCode" VARCHAR(4)
);
