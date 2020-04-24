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
	Class(department_id, className)
VALUES	
	(4, "Intro to Python"),
	(4, "Introduction to Software Engineering"),
	(4, "Database Management Systems"),
	(4, "Discrete Mathematics I"),
	(4, "Linear Algebra I");

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
	(1,1), -- 1
	(1,2), -- 2
	(1,3), -- 3
	(1,4), -- 4
	(1,5), -- 5
	(2, 2), -- 6
	(2, 3), -- 7
	(3, 2),  -- 8
	(3, 3); -- 9
    
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
	Submission(submission, roster_id, assn_id)
VALUES
	("Submission", 1, 1),
	("Submission", 1, 2),
	("Submission", 1, 3),

	("Submission", 2, 4),
	("Submission", 2, 5),
	("Submission", 2, 6),

	("Submission", 3, 7),
	("Submission", 3, 8),
	("Submission", 3, 9),

	("Submission", 4, 10),
	("Submission", 4, 11),
	("Submission", 4, 12),

	("Submission", 5, 13),
	("Submission", 5, 14),
	("Submission", 5, 15),

	("Submission", 6, 4),
	("Submission", 6, 5),
	("Submission", 6, 6),

	("Submission", 7, 7),
	("Submission", 7, 8),
	("Submission", 7, 9),

	("Submission", 8, 4),
	("Submission", 8, 5),
	("Submission", 8, 6),

	("Submission", 9, 7),
	("Submission", 9, 8),
	("Submission", 9, 9);