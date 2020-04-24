CREATE OR REPLACE VIEW `studentView` AS
SELECT * 
FROM Student
NATURAL JOIN Degree
NATURAL JOIN Department;

DROP PROCEDURE IF EXISTS selectStudentV;
DELIMITER $$
CREATE  PROCEDURE `selectStudentV` (IN ID INT)
BEGIN
SELECT * FROM studentView
WHERE student_id = ID;
END$$
DELIMITER ;

call selectStudentV(1);

--
--

CREATE OR REPLACE VIEW `admin_studentView` AS
SELECT department_id, degree_id, student_id, date_admitted, first_name, last_name, address, city, state, zip_code, phone, email, degreeName, degreeDescription, departmentName, departmentDescription
FROM studentView;

DROP PROCEDURE IF EXISTS selectAdminStudentV;
DELIMITER $$
CREATE  PROCEDURE `selectAdminStudentV` ()
BEGIN
SELECT * FROM admin_studentView;
END$$
DELIMITER ;

call selectAdminStudentV;


--
--


CREATE OR REPLACE VIEW `instr_studentView` AS
SELECT department_id, degree_id, student_id, first_name, last_name,  email
FROM studentView;

DROP PROCEDURE IF EXISTS selectInstrStudentView;
DELIMITER $$
CREATE  PROCEDURE `selectInstrStudentView` ()
BEGIN
SELECT * FROM instr_studentView;
END$$
DELIMITER ;

call selectInstrStudentView;