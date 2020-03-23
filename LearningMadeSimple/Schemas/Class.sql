use LearningMadeSimple;

create table if not exists Class(
	classId int auto_increment,
    primary key(classId),
        
    className varchar(10),
    
    degreeId int,
    foreign key(degreeId) references Degree(degreeId)
);

insert into Class(degreeId, className) values (1,"Class");

select * from Class;