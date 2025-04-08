-- Create Tables
CREATE TABLE Dentist (
    dentist_id SERIAL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone VARCHAR(15),
    email VARCHAR(100),
    specialization VARCHAR(100)
);

CREATE TABLE Patient (
    patient_id VARCHAR(10) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone VARCHAR(15),
    email VARCHAR(100),
    address TEXT,
    dob DATE
);

CREATE TABLE Surgery (
    surgery_no VARCHAR(10) PRIMARY KEY,
    name VARCHAR(100),
    address TEXT,
    phone VARCHAR(15)
);

CREATE TABLE Appointment (
    appointment_id SERIAL PRIMARY KEY,
    dentist_id INT REFERENCES Dentist(dentist_id),
    patient_id VARCHAR(10) REFERENCES Patient(patient_id),
    surgery_no VARCHAR(10) REFERENCES Surgery(surgery_no),
    appointment_date DATE,
    appointment_time TIME
);

CREATE TABLE Bill (
    bill_id SERIAL PRIMARY KEY,
    patient_id VARCHAR(10) REFERENCES Patient(patient_id),
    amount DECIMAL(10, 2),
    status VARCHAR(20) DEFAULT 'unpaid'
);

-- Insert Dummy Data
-- Dentists
INSERT INTO Dentist (first_name, last_name, phone, email, specialization) VALUES
('Tony', 'Smith', '123-456-7890', 'tony.smith@ads.com', 'General Dentistry'),
('Helen', 'Pearson', '234-567-8901', 'helen.pearson@ads.com', 'Orthodontics'),
('Robin', 'Plevin', '345-678-9012', 'robin.plevin@ads.com', 'Endodontics');

-- Patients
INSERT INTO Patient (patient_id, first_name, last_name, phone, email, address, dob) VALUES
('P100', 'Gillian', 'White', '456-789-0123', 'gillian.white@email.com', '123 Main St', '1985-05-15'),
('P105', 'Jill', 'Bell', '567-890-1234', 'jill.bell@email.com', '456 Oak St', '1990-03-22'),
('P108', 'Ian', 'MacKay', '678-901-2345', 'ian.mackay@email.com', '789 Pine St', '1978-11-10'),
('P110', 'John', 'Walker', '789-012-3456', 'john.walker@email.com', '101 Elm St', '1982-07-30');

-- Surgeries
INSERT INTO Surgery (surgery_no, name, address, phone) VALUES
('S10', 'Southwest Dental', '111 Dental Ave', '555-0101'),
('S13', 'City Dental', '222 Dental Rd', '555-0102'),
('S15', 'Downtown Dental', '333 Dental Blvd', '555-0103');

-- Appointments (from the provided table)
INSERT INTO Appointment (dentist_id, patient_id, surgery_no, appointment_date, appointment_time) VALUES
((SELECT dentist_id FROM Dentist WHERE first_name = 'Tony' AND last_name = 'Smith'), 'P100', 'S15', '2013-09-12', '10:00:00'),
((SELECT dentist_id FROM Dentist WHERE first_name = 'Tony' AND last_name = 'Smith'), 'P105', 'S15', '2013-09-12', '12:00:00'),
((SELECT dentist_id FROM Dentist WHERE first_name = 'Helen' AND last_name = 'Pearson'), 'P108', 'S10', '2013-09-12', '10:00:00'),
((SELECT dentist_id FROM Dentist WHERE first_name = 'Helen' AND last_name = 'Pearson'), 'P108', 'S10', '2013-09-14', '14:00:00'),
((SELECT dentist_id FROM Dentist WHERE first_name = 'Robin' AND last_name = 'Plevin'), 'P105', 'S15', '2013-09-14', '16:30:00'),
((SELECT dentist_id FROM Dentist WHERE first_name = 'Robin' AND last_name = 'Plevin'), 'P110', 'S13', '2013-09-15', '18:00:00');

-- Bills (Dummy Data for Constraints)
INSERT INTO Bill (patient_id, amount, status) VALUES
('P100', 150.00, 'paid'),
('P105', 200.00, 'unpaid'),
('P108', 120.00, 'paid'),
('P110', 180.00, 'unpaid');

-- -- SQL Queries for the Lab Assignment
-- -- Query 1: List of all Dentists, sorted by last name
-- SELECT * FROM Dentist ORDER BY last_name ASC;

-- -- Query 2: List of all Appointments for a given Dentist (e.g., dentist_id = 1)
-- SELECT a.*, p.first_name AS patient_first_name, p.last_name AS patient_last_name
-- FROM Appointment a
-- JOIN Patient p ON a.patient_id = p.patient_id
-- WHERE a.dentist_id = 1;

-- -- Query 3: List of all Appointments at a Surgery Location (e.g., surgery_no = 'S15')
-- SELECT a.*, d.first_name AS dentist_first_name, d.last_name AS dentist_last_name, p.first_name AS patient_first_name, p.last_name AS patient_last_name
-- FROM Appointment a
-- JOIN Dentist d ON a.dentist_id = d.dentist_id
-- JOIN Patient p ON a.patient_id = p.patient_id
-- WHERE a.surgery_no = 'S15';

-- -- Query 4: Appointments for a given Patient on a given Date (e.g., patient_id = 'P105' on '2013-09-14')
-- SELECT a.*, d.first_name AS dentist_first_name, d.last_name AS dentist_last_name
-- FROM Appointment a
-- JOIN Dentist d ON a.dentist_id = d.dentist_id
-- WHERE a.patient_id = 'P105' AND a.appointment_date = '2013-09-14';