#!/bin/bash

# Step 1: Start Docker containers
echo "Starting Docker containers..."
docker compose up -d

# Step 2: Wait for PostgreSQL to be ready
echo "Waiting for PostgreSQL to start..."
sleep 10

# # Step 3: Copy the SQL script into the PostgreSQL container
# echo "Copying SQL script into the container..."
# docker cp myCS489BankDBScript.sql postgres_db:/myCS489BankDBScript.sql

# # Step 4: Execute the SQL script
# echo "Executing SQL script..."
# docker exec -i postgres_db psql -U bank_user -d bank_db -f /myCS489BankDBScript.sql

# Copy and execute the schema file
echo "Copying schema SQL script into the container..."
docker cp myCS489BankDBScript.sql postgres_db:/myCS489BankDBScript.sql
echo "Executing schema SQL script..."
docker exec -i postgres_db psql -U bank_user -d bank_db -f /myCS489BankDBScript.sql

# Copy and execute the data file
echo "Copying data SQL script into the container..."
docker cp myCS489BankDBDataPopScript.sql postgres_db:/myCS489BankDBDataPopScript.sql
echo "Executing data SQL script..."
docker exec -i postgres_db psql -U bank_user -d bank_db -f /myCS489BankDBDataPopScript.sql

# Step 5: Notify user of completion
echo "Database setup complete! You can access PGAdmin at http://localhost:8080"
echo "PostgreSQL is running on localhost:5432 with database 'bank_db', user 'bank_user', and password 'bank_password'."