use LearningMadeSimple;

create table if not exists Section(
	sectionId int auto_increment,
    primary key(sectionId),
    
    sectionName varchar(10),      
    
    classId int,
    foreign key(classId) references Class(classId),    
    employeeId int,
    foreign key(employeeId) references Employee(employeeId)
);

insert into Section(classId, sectionName, employeeId) values (1,"Section", 1);

select * from Section;