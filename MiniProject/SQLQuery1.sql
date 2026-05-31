create database TrainProj;
use TrainProj;

create table Users(
	Userid int identity(1,1) primary key,
	Username varchar(50) unique,
	UserPassword varchar(50),
	Role varchar(10)
);

create table Train(
    TrainNo int primary key,
    TrainName varchar(50),
    FromStation varchar(50),
    ToStation varchar(50),
    SleeperSeats int,
    SleeperFare decimal(10,2),

    AC3Seats int,
    AC3Fare decimal(10,2),

    AC2Seats int,
    AC2Fare decimal(10,2),

    IsDeleted bit default 0
);

CREATE TABLE Passenger
(
    PassengerId INT IDENTITY PRIMARY KEY,
    BookingId INT,
    Name VARCHAR(50),
    Age INT,
    Gender VARCHAR(10),
    IdType VARCHAR(20),
    IdNumber VARCHAR(20),
    SeatNumber int,
    FOREIGN KEY (BookingId) REFERENCES Booking(BookingId)
);


Create table Booking(
	BookingId int primary key,
	BookingDate datetime,
	TravelDate datetime,
	TrainNo int,
	TrainClass varchar(10),
	PassengerCount int check(PassengerCount<=3),
	Amount decimal(10,2),
	Userid int,

	foreign key(TrainNo) references Train(TrainNo)
);

create table TrainCancellation(
	CancelId int primary key,
    BookingId int,
    CancelDate datetime,
    RefundAmount decimal(10,2),
    foreign key (BookingId) references Booking(BookingId)
);
INSERT INTO Users VALUES(1,'admin','Admin@123','Admin');
ALTER TABLE Booking ADD CancelledTickets INT DEFAULT 0;



ALTER TABLE Train
ADD DepartureTime DATETIME, ArrivalTime DATETIME;



select * from train
update  train set FromStation='Hyderabad' where FromStation='Hyderabad Deccan'

USE TrainProj;

CREATE USER [INFICS\vishnupriyaa] FOR LOGIN [INFICS\vishnupriyaa];

ALTER ROLE db_owner ADD MEMBER [INFICS\vishnupriyaa];


ALTER TABLE Train
ALTER COLUMN DepartureTime TIME;

ALTER TABLE Train
ALTER COLUMN ArrivalTime TIME;

select * from Users;

INSERT INTO Users (Username, UserPassword, Role)
VALUES ('admin', 'Admin@123', 'Admin');




SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Passenger';
UPDATE Passenger SET IsCancelled = 0 WHERE IsCancelled IS NULL;
UPDATE Train SET DepartureTime = '18:00' WHERE DepartureTime IS NULL;