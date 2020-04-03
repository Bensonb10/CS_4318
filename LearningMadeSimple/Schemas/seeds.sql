use LearningMadeSimple;

insert into 
	Department(departmentName) 
values 
	("College of Business"),
	("Colleges of Humanities & Social Sciences"),
	("College of Public Services"),
	("College of Sciences & Technologies"),
	("Administration");

--

insert into 
	Degree(department_id, degreeName) 
values 
	(1,"Business"),
	(4,"Computer Science"),
	(4,"Mathematatics"),
	(4,"Applied Statistics"),
	(4,"Data Science"),
	(4,"Biology"),
	(4,"Biotechnology"),
	(4,"Chemistry"),
	(4, "Geosciences");

--

insert into 
	Student(degree_id, first_name, last_name, email)
values 
	(2, "Benjamin", "Benson", "bBenson@uhd.edu"),
	(2, "Paul", "Davis", "pDavis@uhd.edu"),
	(2, "Kaleab", "Teka", "pDavis@uhd.edu");

--

insert into 
	Employee(role, department_id, salary, first_name, last_name, email)
values 
	("Admin", 5, 10000, "Juan", "Muñoz", "uhdpresident@uhd.edu"); 

--

insert into 
	Employee(department_id, manager_id, first_name, last_name, email)
values 
	(4, 1, "Kevin", "Abbott", "mAbbott@uhd.edu"), 
	(4, 1, "John", "Henderson", "jHenderson@uhd.edu"), 
	(4, 1, "Yuchou", "Chang", "yChang@uhd.edu"), 
	(4, 1, "Shengli", "Yuan", "sYuan@uhd.edu"), 
	(4, 1, "Mitsue", "Nakamura", "mNakamura@uhd.edu"); 
    
--

insert into 
	Semester(semesterName, start_date, end_date) 
values 
	("Fall 2019", "2019-08-19", "2019-12-11"),
	("Spring 2020", "2020-01-13", "2020-05-07"),
	("Summer 2020 May Mini", "2020-05-11", "2020-05-30"),
	("Summer 2020 Session 1", "2020-06-01", "2020-07-02"),
	("Fall 2020", "2020-08-24", "2020-12-16");

--    

insert into
	Class(degree_id, className)
VALUES	
	(2, "Intro to Python"),
	(2, "Introduction to Software Engineering"),
	(2, "Database Management Systems"),
	(3, "Discrete Mathematics I"),
	(3, "Linear Algebra I");

--

insert into 
	Section(semester_id, class_id, employee_id, room, start_time, end_time, daysOfWeek) 
values 
	(2, 1, 3, "RM 612", "10:00", "11:15", "T/TH"),
	(2, 2, 4, "RM 612", "16:00", "17:15", "M"),
	(2, 3, 5, "RM 612", "11:30", "12:45", "M/W"),
	(2, 4, 2, "RM 612", "13:00", "14:15", "M/W"),
	(2, 5, 6, "RM 612", "11:30", "12:45", "T/TH");

--

insert into 
	Roster(student_id, section_id) 
values 
	(1,1),
	(1,2),
	(1,3),
	(1,4),
	(1,5),
	(2, 2),
	(2, 3),
	(3, 2), 
	(3, 3);
    
--

insert into 
	AssignmentType(section_id, type, points_possible) 
values 
	(1, "quiz", 20), -- 1
	(1,"test", 100), -- 2
	(1, "homework", 10), -- 3
	(2, "quiz", 20), -- 4
	(2,"test", 100), -- 5
	(2, "homework", 10), -- 6
	(3, "quiz", 20), -- 7
	(3,"test", 100), -- 8
	(3, "homework", 10), -- 9
	(4, "quiz", 20), -- 10
	(4,"test", 100), -- 11
	(4, "homework", 10), -- 12
	(5, "quiz", 20), -- 13
	(5,"test", 100), -- 14
	(5, "homework", 10); -- 15
    
--
    
insert into 
	Assignment(assn_type_id, section_id, date_due) 
values 
	(1, 1, "2020-04-25"), -- 1
	(2, 1, "2020-04-25"), -- 2
	(3, 1, "2020-04-25"), -- 3
	(4, 2, "2020-04-25"), -- 4
	(5, 2, "2020-04-25"), -- 5
	(6, 2, "2020-04-25"), -- 6
	(7, 3, "2020-04-25"), -- 7
	(8, 3, "2020-04-25"), -- 8
	(9, 3, "2020-04-25"), -- 9
	(10, 4, "2020-04-25"), -- 10
	(11, 4, "2020-04-25"), -- 11
	(12, 4, "2020-04-25"), -- 12
	(13, 5, "2020-04-25"), -- 13
	(14, 5, "2020-04-25"), -- 14
	(15, 5, "2020-04-25"); -- 15

--

insert INTO	
	Submission(submission, section_id, assn_id, student_id)
VALUES
	("SUBMISSION", 1, 1, 1),
	("SUBMISSION", 1, 2, 1),
	("SUBMISSION", 1, 3, 1),
	("SUBMISSION", 2, 4, 1),
	("SUBMISSION", 2, 5, 1),
	("SUBMISSION", 2, 6, 1),
	("SUBMISSION", 3, 7, 1),
	("SUBMISSION", 3, 8, 1),
	("SUBMISSION", 3, 9, 1),
	("SUBMISSION", 4, 10, 1),
	("SUBMISSION", 4, 11, 1),
	("SUBMISSION", 4, 12, 1),
	("SUBMISSION", 5, 13, 1),
	("SUBMISSION", 5, 14, 1),
	("SUBMISSION", 5, 15, 1),
	("SUBMISSION", 2, 4, 2),
	("SUBMISSION", 2, 5, 2),
	("SUBMISSION", 2, 6, 2),
	("SUBMISSION", 3, 7, 2),
	("SUBMISSION", 3, 8, 2),
	("SUBMISSION", 3, 9, 2),
	("SUBMISSION", 2, 4, 3),
	("SUBMISSION", 2, 5, 3),
	("SUBMISSION", 2, 6, 3),
	("SUBMISSION", 3, 7, 3),
	("SUBMISSION", 3, 8, 3),
	("SUBMISSION", 3, 9, 3);

SELECT 
    *
FROM
    Assignment;