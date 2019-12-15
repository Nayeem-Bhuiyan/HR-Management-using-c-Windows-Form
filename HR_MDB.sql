create database HR_MDB;
use HR_MDB;
go
create table tblGender
(
	genderId int primary key identity,
	genderName varchar(50) not null
);
select * from tblGender;
go
create table tblReligion
(
	religionId int primary key identity,
	religionName varchar(50) not null
);
select * from tblReligion;
go
create table tblSection
(
	sectionId int primary key identity,
	sectionName varchar(50) not null
);
select * from tblSection;
go
create table tblDepartment
(
	departmentId int primary key identity,
	departmentName varchar(50) not null
);
select * from tblDepartment;
go
create table tblCountry
(
	countryId int primary key identity,
	countryName varchar(50) not null
);
select * from tblCountry;
go
create table tblCity
(
	cityId int primary key identity,
	cityName varchar(50) not null,
	countryId int foreign key references tblCountry(countryId)
);
select * from tblCity;
go
create table tblDesignation
(
	designationId int primary key identity,
	designationName varchar(50) not null,
	departmentId int foreign key references tblDepartment(departmentId)
);
select * from tblDesignation;
go
create table tblEmployee
(
	employeeId int primary key identity,
	employeeName varchar(50) not null,
	employeeAddress varchar(200),
	employeeDOB date not null,
	employeePhone varchar(11) not null,
	employeeEmail varchar(50),
	employeeCurrentSalary money not null,
	employeeJoiningDate date not null,
	designationId int foreign key references tblDesignation(designationId),
	sectionId int foreign key references tblSection(sectionId),
	departmentId int foreign key references tblDepartment(departmentId),
	genderId int foreign key references tblGender(genderId),
	religionId int foreign key references tblReligion(religionId),
	cityId int foreign key references tblCity(cityId),
	countryId int foreign key references tblCountry(countryId),
);
select * from tblEmployee;
go
select * from tblReligion
GO
Delete tblReligion where religionId=10
GO
select * from tblEmployee where employeeId=1





select * from tblEmployee

Update tblEmployee
SET employeeName='Munna',employeeAddress='dsgfdg',employeeCurrentSalary=50500,employeeDOB='1/1/1993',employeeEmail='mn@gmail.com',employeeJoiningDate='1/1/2018',employeePhone='017342344',departmentId=1,sectionId=1,designationId=1,genderId=1,religionId=1,countryId=1,cityId=1 where employeeId=1
GO
select * from tblCountry
delete from tblEmployee where employeeId=3
Insert Into tblEmployee Values('Nayeem','Narail','2/2/1993','01746651367','na@gmail.com',50000,'2/2/2018',1,1,1,1,1,9,1)







---------------------------loginPart------------------

CREATE TABLE tblUser
(
	id int primary key identity,
	userName varchar(50) NOT NULL,
	email varchar(30) NOT NULL,
	password varchar(50) NOT NULL,
	contactNo varchar(20) NOT NULL,
	
)
GO

SELECT * FROM tblUser

INSERT INTO tblUser VALUES('Munna','na@gmail.com','123','019824354')

SELECT * FROM tblUser WHERE	userName='nayeem' AND password='123456'

delete from tblUser where id=3