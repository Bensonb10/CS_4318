use learningmadesimple;

drop table if exists Assignment;
CREATE TABLE IF NOT EXISTS Assignment (
    assnId INT AUTO_INCREMENT,
    PRIMARY KEY (assnId),
    
    name varchar(10),
    description varchar(50),
    points_possible int,
    date_due date,
    
    typeId int,
    foreign key(typeId) references AssignmentType(typeId)
);

insert into Assignment(typeId) values (1);

select * from Assignment;