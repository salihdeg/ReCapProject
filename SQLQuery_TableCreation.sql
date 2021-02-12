--Creating Database
	--First step: Execute create database function
	--Second Step: Execute other codes under the create database function

create database ReCapProjectDB -- Execute first!


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
CarDescription nvarchar(250),
IsAvailable bit
)

--****************TABLES FOR DAY 10 HOMEWORK****************************
--
create table Users(
Id int primary key identity(1,1),
FirstName nvarchar(50),
LastName nvarchar(50),
Email nvarchar(250),
UserPassword nvarchar(50) 
)

create table Customers(
Id int primary key identity(1,1),
UserId int foreign key references Users(Id),
CompanyName nvarchar(100)
)

--Create other tables first!!!
create table Rentals(
Id int primary key identity(1,1),
CarId int foreign key references Cars(Id),
CustomerId int foreign key references Customers(Id),
RentDate date not null,
ReturnDate date,
)