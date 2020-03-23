use LearningMadeSimple;

drop table if exists AssignmentType;
CREATE TABLE IF NOT EXISTS AssignmentType (
    typeId INT AUTO_INCREMENT,
    PRIMARY KEY (typeId),
    type varchar(10),
    weight int,
    sectionId INT,
    FOREIGN KEY (sectionId)
        REFERENCES Section (sectionId)
);

insert into 
	AssignmentType(sectionId, type, weight) 
values 
	(1, "quiz", 10);
    
SELECT * FROM AssignmentType;
