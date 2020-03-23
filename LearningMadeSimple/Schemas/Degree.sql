use LearningMadeSimple;

create table if not exists Degree(
	degreeId int auto_increment,
    primary key(degreeId),
    
	degreeName varchar(10),
    
    departmentId int,
    foreign key(departmentId) references Department(departmentId)
);

insert into Degree(departmentId, degreeName) values (1,"Degree");

select * from Degree;