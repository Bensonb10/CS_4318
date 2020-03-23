use LearningMadeSimple;

drop table if exists Roster;
drop table if exists Employee;

CREATE TABLE Employee (
    employeeId INT AUTO_INCREMENT,
    PRIMARY KEY (employeeId),
    
    first_name VARCHAR(10),
    last_name VARCHAR(10),
    
    departmentId int,
    foreign key(departmentId) references Department(departmentId)
);

insert into 
	Employee(first_name, last_name, departmentId)
values 
	("Mark", "Abbott", 1);

select * from Employee;