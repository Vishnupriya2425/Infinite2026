create database bookdetails
use bookdetails
drop table Books;
create table Books(
    id int primary key,
    title varchar(50),
    author varchar(50),
    isbn bigint unique,
    published_date datetime
);
insert into Books values (1, 'My First SQL book', 'Mary Parker',98148302927,'2012-02-22 12:08:17');
insert into Books values (2, 'My Second SQL book', 'John Mayer',857300923713,'1972-07-03 09:22:45');
insert into Books values (3, 'My Third SQL book', 'Cary Flint',523120967812,'2015-10-18 14:05:44');


select * from books where author like '%er';

create table reviews(
    id int primary key,
    book_id int,
    reviewer_name varchar(50),
    content varchar(50),
    rating int,
    published_date datetime,

    foreign key(book_id) references Books(id));

    insert into reviews values (1,1,'John Smith','My First review',4,'2017-12-10 05:50:11');
    insert into reviews values (2,2,'John SMith','My Second review',5,'2017-10-13 15:05:12');
    insert into reviews values (3,3,'Alice Walker','My Third review',1,'2017-10-22 23:47:10');

    select 
      b.title,
      b.author,
      r.reviewer_name
    from Books b
    join Reviews r
    on b.id=r.book_id;

    select  reviewer_name from reviews
    group by reviewer_name having count(distinct book_id)>1;
    
    
    create table customer(
    id int primary key,
    name varchar(50),
    age int,
    address varchar(30),
    salary decimal(10,2));

    insert into customer values(1,'Ramesh',32,'Ahmedabad',2000.00);
    insert into customer values(2,'Khilan',25,'Delhi',1500.00);
    insert into customer values(3,'Kaushik',23,'Kota',2000.00);
    insert into customer values(4,'Chaitali',25,'Mumbai',6500.00);
    insert into customer values(5,'Hardik',27,'Bhopal',8500.00);
    insert into customer values(6,'Komal',22,'MP',4500.00);
    insert into customer values(7,'Muffy',24,'Indore',10000.00);

    select name
    from customer
    where address like '%o%'
    and address in(
        select address 
        from customer
        group by address 
        having count(*)>1);

        create table orders(
        oid int primary key,
        date datetime,
        customer_id int,
        amount int);

        insert into orders values(102,'2009-10-08 00:00:00',3,3000);
        insert into orders values(100,'2009-10-08 00:00:00',3,1500);
        insert into orders values(101,'2009-11-20 00:00:00',2,1560);
        insert into orders values(103,'2008-05-20 00:00:00',4,2060);

        select * 
           from orders where date in(
           select date
           from orders
           group by date
           having count(*)>1);


create table employee(
    id int primary key,
    name varchar(50),
    age int,
    address varchar(30),
    salary decimal(10,2));

    insert into employee values(1,'Ramesh',32,'Ahmedabad',2000.00);
    insert into employee values(2,'Khilan',25,'Delhi',1500.00);
    insert into employee values(3,'Kaushik',23,'Kota',2000.00);
    insert into employee values(4,'Chaitali',25,'Mumbai',6500.00);
    insert into employee values(5,'Hardik',27,'Bhopal',8500.00);
    insert into employee values(6,'Komal',22,'MP',null);
    insert into employee values(7,'Muffy',24,'Indore',null);

    select lower(name) as e_name
    from employee where salary is null;

create table studentdetails(
  RegisterNo int primary key,
  name varchar(50),
  age int,
  qualification varchar(20),
  mobileNo bigint,
  mail_id varchar(50),
  location varchar(50),
  gender char(1));

  insert into studentdetails (registerno, name, age, qualification, mobileno, mail_id, location, gender) values
(2, 'sai', 22, 'b.e', 9952836777, 'sai@gmail.com', 'chennai', 'm'),
(3, 'kumar', 20, 'bsc', 7890125648, 'kumar@gmail.com', 'madurai', 'm'),
(4, 'selvi', 22, 'b.tech',8904567342, 'selvi@gmail.com', 'selam',   'f'),
(5, 'nisha', 25, 'm.e', 7834672310, 'nisha@gmail.com', 'theni',   'f'),
(6, 'saisaran', 21, 'b.a', 7890345678, 'saran@gmail.com','madurai', 'f'),
(7, 'tom', 23, 'bca', 8901234675, 'tom@gmail.com', 'pune', 'm');

select gender, count(*) as total
from studentdetails
group by gender;