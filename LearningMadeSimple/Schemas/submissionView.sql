CREATE OR REPLACE VIEW `submissionV` AS
    SELECT 
        sub.submission_id,
        sub.submission,
        sub.date_submitted,
        sub.points_earned,
        stud.student_id,
        stud.first_name AS Student_first_name,
        stud.last_name AS Student_last_name,
        assn.assn_id,
        assn.section_id,
        assn.assignmentName,
        assn.assignmentDescription,
        assn.date_due,
        assnT.assn_type_id,
        assnT.type,
        assnT.points_possible
    FROM
        Roster ros
            LEFT JOIN
        Student stud ON ros.student_id = stud.student_id
            LEFT JOIN
        Submission sub ON sub.roster_id = ros.roster_id
            LEFT JOIN
        Section sec ON ros.roster_id = sec.section_id
                    LEFT JOIN
        Assignment assn ON sub.assn_id = assn.assn_id
            LEFT JOIN
        AssignmentType assnT ON assn.assn_type_id = assnT.assn_type_id
    ORDER BY section_id;

DROP PROCEDURE IF EXISTS submissionByStudent;
DELIMITER $$
CREATE  PROCEDURE `submissionByStudent` (IN ID INT)
BEGIN
SELECT * FROM submissionV
WHERE student_id = ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS submissionBySectionStudent;
DELIMITER $$
CREATE  PROCEDURE `submissionBySectionStudent` (IN ID1 INT, IN ID2 INT)
BEGIN
SELECT * FROM submissionV
WHERE section_id = ID1 AND student_id = ID2;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS gradesByStudent;
DELIMITER $$
CREATE  PROCEDURE `gradesByStudent` (IN ID1 INT)
BEGIN
SELECT 
    section_id,
    sum(points_possible) as possible,
    format(sum(points_possible * (points_earned / 100)), 2) as earned,
    format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) as Grade,
    CASE
		WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 90 THEN 'A'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 80 THEN 'B'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 70 THEN 'C'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 60 THEN 'D'
		ELSE 'F'
    END as letter
FROM submissionV
WHERE student_id = ID1
GROUP BY section_id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS gradesBySectionStudent;
DELIMITER $$
CREATE  PROCEDURE `gradesBySectionStudent` (IN ID1 INT, IN ID2 INT)
BEGIN
SELECT 
    section_id,
    sum(points_possible) as possible,
    format(sum(points_possible * (points_earned / 100)), 2) as earned,
    format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) as Grade,
    CASE
		WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 90 THEN 'A'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 80 THEN 'B'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 70 THEN 'C'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 60 THEN 'D'
		ELSE 'F'
    END as letter
FROM submissionV
WHERE section_id = ID1 AND student_id = ID2;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS assignmentTypegradesBySectionStudent;
DELIMITER $$
CREATE  PROCEDURE `assignmentTypegradesBySectionStudent` (IN ID1 INT, IN ID2 INT)
BEGIN
SELECT 
    section_id,
    type,
    sum(points_possible) as possible,
    format(sum(points_possible * (points_earned / 100)), 2) as earned,
    format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) as Grade,
    CASE
		WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 90 THEN 'A'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 80 THEN 'B'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 70 THEN 'C'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 60 THEN 'D'
		ELSE 'F'
    END as letter
FROM submissionV
WHERE section_id = ID1 AND student_id = ID2
GROUP BY type;
END$$
DELIMITER ;


DROP PROCEDURE IF EXISTS assignmentTypeGradesBySection;
DELIMITER $$
CREATE  PROCEDURE `assignmentTypeGradesBySection` (IN ID1 INT)
BEGIN
SELECT 
    section_id,
    type,
    sum(points_possible) as possible,
    format(sum(points_possible * (points_earned / 100)), 2) as earned,
    format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) as Grade,
    CASE
		WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 90 THEN 'A'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 80 THEN 'B'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 70 THEN 'C'
        WHEN format((sum(points_possible * (points_earned / 100))  * 100 / sum(points_possible)), 2) >= 60 THEN 'D'
		ELSE 'F'
    END as letter
FROM submissionV
WHERE section_id = ID1
GROUP BY type;
END$$
DELIMITER ;


call submissionByStudent(2);
