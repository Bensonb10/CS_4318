create database if not exists LearningMadeSimple; -- build
use LearningMadeSimple;

drop table if exists Roster;
drop table if exists Submission;
drop table if exists Assignment;
drop table if exists AssignmentType;
drop table if exists Section;
drop table if exists Class;
drop table if exists Student;
drop table if exists Degree;
drop table if exists Employee;
drop table if exists Department;

CREATE TABLE IF NOT EXISTS Department (
    department_id INT AUTO_INCREMENT,
    PRIMARY KEY (department_id),
    departmentName VARCHAR(255) not null,
    departmentDescription varchar(255) default "TBD"
);

CREATE TABLE IF NOT EXISTS Degree (
    degree_id INT AUTO_INCREMENT,
    PRIMARY KEY (degree_id),
    degreeName VARCHAR(255) not null,
    degreeDescription varchar(255) default "TBD",
    department_id INT not null,
    FOREIGN KEY (department_id)
        REFERENCES Department (department_id)
);

CREATE TABLE Student (
    student_id INT AUTO_INCREMENT NOT NULL,
    PRIMARY KEY (student_id),
    degree_id int,
    foreign key(degree_id) references Degree(degree_id),
    date_admitted date default "2000-01-01",
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    address VARCHAR(255) NOT NULL default "TBD",
    city VARCHAR(255) NOT NULL default "TBD",
    state VARCHAR(255) NOT NULL default "TBD",
    zip_code INT(5) NOT NULL default 77024,
    phone VARCHAR(25) NOT NULL default "TBD",
    email VARCHAR(255) NOT NULL,
    password VARCHAR(25) NOT NULL default "asdf"
);

CREATE TABLE Employee (
    employee_id INT AUTO_INCREMENT,
    PRIMARY KEY (employee_id),
    department_id INT,
    FOREIGN KEY (department_id)
        REFERENCES Department (department_id),
    manager_id INT,
    FOREIGN KEY (manager_id)
        REFERENCES Employee (employee_id),
    role enum("Admin", "Instructor") default "Instructor",
    salary INT(7) NOT NULL default 50000,
    date_hired DATE DEFAULT '2000-01-01',
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    address VARCHAR(255) NOT NULL default "TBD",
    city VARCHAR(255) NOT NULL default "TBD",
    state VARCHAR(255) NOT NULL default "TBD",
    zip_code INT(5) NOT NULL default 77024,
    phone VARCHAR(25) NOT NULL default "TBD",
    email VARCHAR(255) NOT NULL,
    password VARCHAR(25) NOT NULL default "asdf"
);

CREATE TABLE IF NOT EXISTS Semester (
    semester_id INT AUTO_INCREMENT,
    PRIMARY KEY (semester_id),
    semesterName varchar(25) not null,
    start_date date not null,
    end_date date not null
);

CREATE TABLE IF NOT EXISTS Class (
    class_id INT AUTO_INCREMENT,
    PRIMARY KEY (class_id),
    className VARCHAR(255) not null,
    classDescription varchar(255) default "TBD",
    degree_id INT,
    credit_hours int default 3,
    FOREIGN KEY (degree_id)
        REFERENCES Degree (degree_id)
);

CREATE TABLE IF NOT EXISTS Section (
    section_id INT AUTO_INCREMENT,
    PRIMARY KEY (section_id),
    
    semester_id INT,
    FOREIGN KEY (semester_id)
        REFERENCES Semester (semester_id),
        
    class_id INT,
    FOREIGN KEY (class_id)
        REFERENCES Class (class_id),
        
    employee_id INT,
    FOREIGN KEY (employee_id)
        REFERENCES Employee (employee_id),
        
    room VARCHAR(255) DEFAULT 'TBD',
    daysOfWeek VARCHAR(25) not null,
    start_time VARCHAR(255) DEFAULT 'TBD',
    end_time VARCHAR(255) DEFAULT 'TBD'
);

CREATE TABLE IF NOT EXISTS Roster (
    roster_id INT AUTO_INCREMENT,
    PRIMARY KEY (roster_id),
    
	student_id int,   
    FOREIGN KEY (student_id)
        REFERENCES Student (student_id),
        
    section_id INT,
    FOREIGN KEY (section_id)
        REFERENCES Section (section_id)
);

CREATE TABLE IF NOT EXISTS AssignmentType (
    assn_type_id INT AUTO_INCREMENT,
    PRIMARY KEY (assn_type_id),
    
    section_id INT,
    FOREIGN KEY (section_id)
        REFERENCES Section (section_id),
    
    type VARCHAR(25) not null,
    points_possible INT(3)    
);

CREATE TABLE IF NOT EXISTS Assignment (
    assn_id INT AUTO_INCREMENT,
    PRIMARY KEY (assn_id),
    assn_type_id INT,
    FOREIGN KEY (assn_type_id)
        REFERENCES AssignmentType (assn_type_id),
    section_id INT,
    FOREIGN KEY (section_id)
        REFERENCES Section (section_id),
    assignmentName VARCHAR(50) NOT NULL default 'TBD',
    assignmentDescription VARCHAR(255) DEFAULT 'TBD',
    date_due DATE
);

CREATE TABLE IF NOT EXISTS Submission (
    submission_id INT AUTO_INCREMENT,
    PRIMARY KEY (submission_id),
    submission VARCHAR(8000),
    date_submitted DATETIME DEFAULT CURRENT_TIMESTAMP,
    section_id INT,
    FOREIGN KEY (section_id)
        REFERENCES Section (section_id),
    assn_id INT,
    FOREIGN KEY (assn_id)
        REFERENCES Assignment (assn_id),
    student_id INT,
    FOREIGN KEY (student_id)
        REFERENCES Student (student_id)
);
