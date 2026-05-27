create database FOMSDB
use FOMSDB;

create table MenuItems (
    MenuId int identity(1,1) primary key,
    ItemName nvarchar(100),
    Category nvarchar(50),
    FoodType nvarchar(20),
    Price decimal(10,2),
    AvailableQuantity int,
    IsAvailable bit,
    CreatedDate datetime default getdate()
);

select * from MenuItems;
