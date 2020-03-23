create database if not exists LearningMadeSimple;
use LearningMadeSimple;

drop table if exists Roster;
drop table if exists Section;
drop table if exists Class;
drop table if exists Degree;
drop table if exists Employee;
drop table if exists Department;

create table if not exists Department(
	departmentId int auto_increment,
    primary key(departmentId),
    
    departmentName varchar(10)    
);

insert into Department(departmentName) values ("Department");

select * from Department;