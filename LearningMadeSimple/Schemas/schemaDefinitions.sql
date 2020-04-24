drop table if exists Submission;
drop table if exists Roster;
drop table if exists Assignment;
drop table if exists AssignmentType;
drop table if exists Section;
drop table if exists Semester;
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


DROP PROCEDURE IF EXISTS insertDepartment;
DELIMITER $$
CREATE  PROCEDURE `insertDepartment` (IN name VARCHAR(255), IN descr VARCHAR(255))
BEGIN
INSERT INTO Department
VALUES (name, descr);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateDepartment;
DELIMITER $$
CREATE  PROCEDURE `updateDepartment` (IN id INT, IN name VARCHAR(255), IN descr VARCHAR(255))
BEGIN
UPDATE Department
SET departmentName = name, departmentDescription = descr
WHERE department_id = id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteDepartment;
DELIMITER $$
CREATE  PROCEDURE `deleteDepartment` (IN id INT)
BEGIN
DELETE FROM Department
WHERE department_id = id;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --


CREATE TABLE IF NOT EXISTS Degree (
    degree_id INT AUTO_INCREMENT,
    PRIMARY KEY (degree_id),
    degreeName VARCHAR(255) not null,
    degreeDescription varchar(255) default "TBD",
    department_id INT not null,
    FOREIGN KEY (department_id)
        REFERENCES Department (department_id)
);

DROP PROCEDURE IF EXISTS insertDegree;
DELIMITER $$
CREATE  PROCEDURE `insertDegree` (IN name VARCHAR(255), IN descr VARCHAR(255), IN dpt_id INT)
BEGIN
INSERT INTO Degree
VALUES (name, descr, dpt_id);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateDegree;
DELIMITER $$
CREATE  PROCEDURE `updateDegree` (IN id INT, IN name VARCHAR(255), IN descr VARCHAR(255), IN dpt_id INT)
BEGIN
UPDATE Degree
SET degreeName = name, degreeDescription = descr, department_id = dpt_id
WHERE degree_id = id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteDegree;
DELIMITER $$
CREATE  PROCEDURE `deleteDegree` (IN id INT)
BEGIN
DELETE FROM Degree
WHERE degree_id = id;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



CREATE TABLE IF NOT EXISTS Student (
    student_id INT AUTO_INCREMENT NOT NULL,
    PRIMARY KEY (student_id),
    degree_id int,
    foreign key(degree_id) references Degree(degree_id),
    date_admitted date default "2000-01-01",
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    address VARCHAR(255) default "TBD",
    city VARCHAR(255) default "TBD",
    state VARCHAR(255)  default "TBD",
    zip_code INT  default 77024,
    phone VARCHAR(255) default "TBD",
    email VARCHAR(255) NOT NULL,
    password VARCHAR(25)  default "asdf"
);

DROP PROCEDURE IF EXISTS insertStudent;
DELIMITER $$
CREATE  PROCEDURE `insertStudent` (IN DEGREE_ID INT, IN DATE_ADMITTED DATE, IN FIRST_NAME VARCHAR(255), IN LAST_NAME VARCHAR(255), IN ADDRES VARCHAR(255), IN CITY VARCHAR(255), IN STATE VARCHAR(255), IN ZIP_CODE INT, IN PHONE VARCHAR(255), IN EMAIL VARCHAR(255), IN PASSWORD VARCHAR(25))
BEGIN
INSERT INTO Student
VALUES (DEGREE_ID, DATE_ADMITTED, FIRST_NAME, LAST_NAME, ADDRES, CITY, STATE, ZIP_CODE, PHONE, EMAIL, PASSWORD);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateStudent;
DELIMITER $$
CREATE  PROCEDURE `updateStudent` (IN id INT, IN DEGREE_ID INT, IN DATE_ADMITTED DATE, IN FIRST_NAME VARCHAR(255), IN LAST_NAME VARCHAR(255), IN ADDRESS VARCHAR(255), IN CITY VARCHAR(255), IN STATE VARCHAR(255), IN ZIP_CODE INT, IN PHONE VARCHAR(255), IN EMAIL VARCHAR(255), IN PASSWORD VARCHAR(25))
BEGIN
UPDATE Student
SET degree_id = DEGREE_ID, date_admitted = DATE_ADMITTED, first_name = FIRST_NAME, last_name = LAST_NAME, address = ADDRESS, city = CITY, state = STATE, zip_code = ZIP_CODE, phone = PHONE, email = EMAIL, password = PASSWORD
WHERE student_id = id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteStudent;
DELIMITER $$
CREATE  PROCEDURE `deleteStudent` (IN id INT)
BEGIN
DELETE FROM Student
WHERE student_id = id;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



CREATE TABLE IF NOT EXISTS Employee (
    employee_id INT AUTO_INCREMENT,
    PRIMARY KEY (employee_id),
    department_id INT,
    FOREIGN KEY (department_id)
        REFERENCES Department (department_id),
    manager_id INT,
    FOREIGN KEY (manager_id)
        REFERENCES Employee (employee_id),
    role enum("Admin", "Instructor") default "Instructor",
    salary INT NOT NULL default 50000,
    date_hired DATE DEFAULT '2000-01-01',
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    address VARCHAR(255) NOT NULL default "TBD",
    city VARCHAR(255) NOT NULL default "TBD",
    state VARCHAR(255) NOT NULL default "TBD",
    zip_code INT NOT NULL default 77024,
    phone VARCHAR(25) NOT NULL default "TBD",
    email VARCHAR(255) NOT NULL,
    password VARCHAR(25) NOT NULL default "asdf"
);

DROP PROCEDURE IF EXISTS insertEmployee;
DELIMITER $$
CREATE  PROCEDURE `insertEmployee` (IN DEPARTMENT_ID INT, IN MANAGER_ID INT, IN ROLE VARCHAR(255), IN SALARY INT, IN DATE_HIRED DATE, IN FIRST_NAME VARCHAR(255), IN LAST_NAME VARCHAR(255), IN ADDRES VARCHAR(255), IN CITY VARCHAR(255), IN STATE VARCHAR(255), IN ZIP_CODE INT, IN PHONE VARCHAR(255), IN EMAIL VARCHAR(255), IN PASSWORD VARCHAR(25))
BEGIN
INSERT INTO Student
VALUES (DEPARTMENT_ID, MANAGER_ID, ROLE, SALARY, DATE_HIRED, FIRST_NAME, LAST_NAME, ADDRES, CITY, STATE, ZIP_CODE, PHONE, EMAIL, PASSWORD);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateEmployee;
DELIMITER $$
CREATE  PROCEDURE `updateEmployee` (IN id INT, IN DEPARTMENT_ID INT, IN MANAGER_ID INT, IN ROLE VARCHAR(255), IN SALARY INT, IN DATE_HIRED DATE, IN FIRST_NAME VARCHAR(255), IN LAST_NAME VARCHAR(255), IN ADDRESS VARCHAR(255), IN CITY VARCHAR(255), IN STATE VARCHAR(255), IN ZIP_CODE INT, IN PHONE VARCHAR(255), IN EMAIL VARCHAR(255), IN PASSWORD VARCHAR(25))
BEGIN
UPDATE Employee
SET department_id = DEPARTMENT_ID, manager_id = MANAGER_ID, role = ROLE, salary = SALARY, date_hired = DATE_HIRED, first_name = FIRST_NAME, last_name = LAST_NAME, address = ADDRESS, city = CITY, state = STATE, zip_code = ZIP_CODE, phone = PHONE, email = EMAIL, password = PASSWORD
WHERE employee_id = id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteEmployee;
DELIMITER $$
CREATE  PROCEDURE `deleteEmployee` (IN id INT)
BEGIN
DELETE FROM Employee
WHERE employee_id = id;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



CREATE TABLE IF NOT EXISTS Semester (
    semester_id INT AUTO_INCREMENT,
    PRIMARY KEY (semester_id),
    semesterName varchar(25) not null,
    start_date date not null,
    end_date date not null
);

DROP PROCEDURE IF EXISTS insertSemester;
DELIMITER $$
CREATE  PROCEDURE `insertSemester` (IN name VARCHAR(255), IN d_start DATE, IN d_end DATE)
BEGIN
INSERT INTO Semester
VALUES (name, d_start, d_end);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateSemester;
DELIMITER $$
CREATE  PROCEDURE `updateSemester` (IN ID INT, IN name VARCHAR(255), IN d_start DATE, IN d_end DATE)
BEGIN
UPDATE Semester
SET semesterName = name, start_date = d_start, end_date = d_end
WHERE semester_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteSemester;
DELIMITER $$
CREATE  PROCEDURE `deleteSemester` (IN ID INT)
BEGIN
DELETE FROM Semester
WHERE semester_id = ID;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



CREATE TABLE IF NOT EXISTS Class (
    class_id INT AUTO_INCREMENT,
    PRIMARY KEY (class_id),
    className VARCHAR(255) not null,
    classDescription varchar(255) default "TBD",
    department_id INT,
    credit_hours int default 3,
    FOREIGN KEY (department_id)
        REFERENCES Department (department_id)
);

DROP PROCEDURE IF EXISTS insertClass;
DELIMITER $$
CREATE  PROCEDURE `insertClass` (IN NAME VARCHAR(255), IN DESCR VARCHAR(255), IN DPT_ID INT, IN CREDIT_HOURS INT)
BEGIN
INSERT INTO Class
VALUES (NAME, DESCR, DPT_ID, CREDIT_HOURS);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateClass;
DELIMITER $$
CREATE  PROCEDURE `updateClass` (IN ID INT, IN NAME VARCHAR(255), IN DESCR VARCHAR(255), IN DPT_ID INT, IN CREDIT_HOURS INT)
BEGIN
UPDATE Class
SET className = NAME, classDescription = DESCR, department_id = DPT_ID, credit_hours = CREDIT_HOURS
WHERE class_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteClass;
DELIMITER $$
CREATE  PROCEDURE `deleteClass` (IN ID INT)
BEGIN
DELETE FROM Class
WHERE class_id = ID;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



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
    daysOfWeek VARCHAR(255) not null,
    start_time VARCHAR(255) DEFAULT 'TBD',
    end_time VARCHAR(255) DEFAULT 'TBD'
);

DROP PROCEDURE IF EXISTS insertSection;
DELIMITER $$
CREATE  PROCEDURE `insertSection` (IN SEMSTER_ID INT, IN CLASS_ID INT, IN EMPLOYEE_ID INT, IN ROOM VARCHAR(255), IN DAYSOFWEEK VARCHAR(255), IN START_TIME VARCHAR(255), IN END_TIME VARCHAR(255))
BEGIN
INSERT INTO Section
VALUES (SEMESTER_ID, CLASS_ID, EMPLOYEE_ID, ROOM, DAYSOFWEEK, START_TIME, END_TIME);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateSection;
DELIMITER $$
CREATE  PROCEDURE `updateSection` (IN ID INT, IN SEMSTER_ID INT, IN CLASS_ID INT, IN EMPLOYEE_ID INT, IN ROOM VARCHAR(255), IN DAYSOFWEEK VARCHAR(255), IN START_TIME VARCHAR(255), IN END_TIME VARCHAR(255))
BEGIN
UPDATE Section
SET semester_id = SEMESTER_ID, class_id = CLASS_ID, employee_id = EMPLOYEE_ID, room = ROOM, daysOfWeek = DAYSOFWEEK, start_time = START_TIME, end_time = END_TIME
WHERE section_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteSection;
DELIMITER $$
CREATE  PROCEDURE `deleteSection` (IN ID INT)
BEGIN
DELETE FROM Section
WHERE section_id = ID;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



CREATE TABLE IF NOT EXISTS Roster (
    roster_id INT AUTO_INCREMENT,
    PRIMARY KEY (roster_id),

    final_grade int,
    credits_earned int,
    letter_grade CHAR(1),
    
	student_id int,   
    FOREIGN KEY (student_id)
        REFERENCES Student (student_id),
        
    section_id INT,
    FOREIGN KEY (section_id)
        REFERENCES Section (section_id)
);

DROP PROCEDURE IF EXISTS insertRoster;
DELIMITER $$
CREATE  PROCEDURE `insertRoster` (IN STUDENT_ID INT, IN SECTION_ID INT)
BEGIN
INSERT INTO Roster
VALUES (STUDENT_ID, SECTION_ID);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateRoster;
DELIMITER $$
CREATE  PROCEDURE `updateRoster` (IN ID INT, IN FINAL_GRADE INT, IN CREDITS_EARNED INT, IN LETTER_GRADE CHAR(1))
BEGIN
UPDATE Roster
SET final_grade = FINAL_GRADE, credits_earned = CREDITS_EARNED, letter_grade = LETTER_GRADE
WHERE roster_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteRoster;
DELIMITER $$
CREATE  PROCEDURE `deleteRoster` (IN ID INT)
BEGIN
DELETE FROM Roster
WHERE roster_id = ID;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



CREATE TABLE IF NOT EXISTS AssignmentType (
    assn_type_id INT AUTO_INCREMENT,
    PRIMARY KEY (assn_type_id),
    
    section_id INT,
    FOREIGN KEY (section_id)
        REFERENCES Section (section_id),
    
    type VARCHAR(25) not null,
    points_possible INT
);

DROP PROCEDURE IF EXISTS insertAssignmentType;
DELIMITER $$
CREATE  PROCEDURE `insertAssignmentType` (IN SECTION_ID INT, IN TYPE VARCHAR(25), IN POSSIBLE INT)
BEGIN
INSERT INTO AssignmentType
VALUES (SECTION_ID, TYPE, POSSIBLE);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateAssignmentType;
DELIMITER $$
CREATE  PROCEDURE `updateAssignmentType` (IN ID INT, IN SECTION_ID INT, IN TYPE VARCHAR(25), IN POSSIBLE INT)
BEGIN
UPDATE AssignmentType
SET section_id = SECTION_ID, type = TYPE, points_possible = POSSIBLE
WHERE assn_type_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteAssignmentType;
DELIMITER $$
CREATE  PROCEDURE `deleteAssignmentType` (IN ID INT)
BEGIN
DELETE FROM AssignmentType
WHERE assn_type_id = ID;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



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


DROP PROCEDURE IF EXISTS insertAssignment;
DELIMITER $$
CREATE  PROCEDURE `insertAssignment` (IN ASSN_TYPE_ID INT, IN SECTION_ID INT, IN ASSIGN_NAME VARCHAR(25), IN ASSN_DESCR VARCHAR(25), IN DATE_DUE DATE)
BEGIN
INSERT INTO AssignmentType
VALUES (ASSN_TYPE_ID, SECTION_ID, ASSIGN_NAME, ASSN_DESCR, DATE_DUE);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateAssignment;
DELIMITER $$
CREATE  PROCEDURE `updateAssignment` (IN ID INT, IN ASSN_TYPE_ID INT, IN SECTION_ID INT, IN ASSIGN_NAME VARCHAR(25), IN ASSN_DESCR VARCHAR(25), IN DATE_DUE DATE)
BEGIN
UPDATE AssignmentType
SET assn_type_id = ASSN_TYPE_ID, section_id = SECTION_ID, assignmentName = ASSIGN_NAME, assignmentDescription = ASSN_DESCR, date_due = DATE_DUE
WHERE assn_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteAssignment;
DELIMITER $$
CREATE  PROCEDURE `deleteAssignment` (IN ID INT)
BEGIN
DELETE FROM Assignment
WHERE assn_id = ID;
END$$
DELIMITER ;


-- -- --
-- -- --
-- -- --
-- -- --



CREATE TABLE IF NOT EXISTS Submission (
    submission_id INT AUTO_INCREMENT,
    PRIMARY KEY (submission_id),
    submission VARCHAR(8000),
    date_submitted DATETIME DEFAULT CURRENT_TIMESTAMP,
    points_earned INT default 90,
    roster_id INT,
    FOREIGN KEY (roster_id)
        REFERENCES Roster (roster_id),
    assn_id INT,
    FOREIGN KEY (assn_id)
        REFERENCES Assignment (assn_id)
);


DROP PROCEDURE IF EXISTS insertSubmission;
DELIMITER $$
CREATE  PROCEDURE `insertSubmission` (IN SUB VARCHAR(8000), IN EARNED INT, IN ROSTER_ID INT, IN ASSN_ID INT)
BEGIN
INSERT INTO Submission (submission, points_earned, roster_id, assn_id)
VALUES (SUB, EARNED, ROSTER_ID, ASSN_ID);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS updateSubmission;
DELIMITER $$
CREATE  PROCEDURE `updateSubmission` (IN ID INT, IN SUB VARCHAR(8000), IN EARNED INT, IN ROSTER_ID INT, IN ASSN_ID INT)
BEGIN
UPDATE Submission
SET submission = SUB, points_earned = EARNED, roster_id = ROSTER_ID, assn_id = ASSN_ID
WHERE submission_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteSubmission;
DELIMITER $$
CREATE  PROCEDURE `deleteSubmission` (IN ID INT)
BEGIN
DELETE FROM Submission
WHERE submission_id = ID;
END$$
DELIMITER ;
