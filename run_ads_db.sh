#!/bin/bash

# Step 1: Start Docker containers
echo "Starting Docker containers..."
docker compose up -d

# Step 2: Wait for PostgreSQL to be ready
echo "Waiting for PostgreSQL to start..."
sleep 10

# Step 3: Copy the SQL script into the PostgreSQL container
echo "Copying SQL script into the container..."
docker cp myADSDentalSurgeryDBScript.sql postgres_db:/myADSDentalSurgeryDBScript.sql

# Step 4: Execute the SQL script
echo "Executing SQL script..."
docker exec -i postgres_db psql -U ads_user -d ads_dental_db -f /myADSDentalSurgeryDBScript.sql

# Step 5: Notify user of completion
echo "Database setup complete! You can access PGAdmin at http://localhost:8080"
echo "PostgreSQL is running on localhost:5432 with database 'ads_dental_db', user 'ads_user', and password 'ads_password'."