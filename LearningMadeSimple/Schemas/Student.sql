use LearningMadeSimple;

drop table if exists Roster;
drop table if exists Student;

CREATE TABLE Student (
    studentId INT AUTO_INCREMENT,
    PRIMARY KEY (studentId),
    
    first_name VARCHAR(10),
    last_name VARCHAR(10)    
);

insert into 
	Student(first_name, last_name)
values 
	("Ben", "Benson"),
	("Laura", "Benson");

select * from Student;