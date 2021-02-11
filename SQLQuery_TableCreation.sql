--Creating Database
	--First step: Execute create database function
	--Second Step: Execute other codes under the create database function
create database ReCapProjectDB
use ReCapProjectDB --use this database for codes under this line
set dateformat dmy
--Colors Table
Create table Colors(
ColorId int primary key identity(1,1),
ColorName nvarchar(50) not null
)
--Brands Table
create table Brands(
BrandId int primary key identity(1,1),
BrandName nvarchar(50) not null
)
--Cars Table
create table Cars(
Id int primary key identity(1,1),
BrandId int foreign key references Brands(BrandId),
ColorId int foreign key references Colors(ColorId),
ModelYear date,
DailyPrice money not null,
CarDescription nvarchar(250)
)