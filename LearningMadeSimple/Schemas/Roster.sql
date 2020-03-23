use LearningMadeSimple;

create table if not exists Roster (
	rosterId int auto_increment,
    primary key(rosterId),
    
    studentId int,
    foreign key(studentId) references Student(studentId),    
    sectionId int,
    foreign key(sectionId) references Section(sectionId)
);

insert into 
	Roster(studentId, sectionId) 
values 
	(1, 1),
	(2, 1);

SELECT 
    Class.className AS className,
    Section.sectionName AS sectionName,
    Degree.degreeName AS degreeName,
    Department.departmentName AS departmentName,
    Employee.first_name AS emp_first_name,
    Employee.last_name AS emp_last_name
FROM
    Roster
        INNER JOIN
    Section ON Roster.sectionId = Section.sectionId
		INNER JOIN
	Employee ON Section.employeeId = Employee.employeeId
        INNER JOIN
    Class ON Section.classId = Class.classId
		INNER JOIN
	Degree ON Class.degreeId = Degree.degreeId
		INNER JOIN
	Department ON Degree.departmentId = Department.departmentId
WHERE
    Roster.studentId = 1;
