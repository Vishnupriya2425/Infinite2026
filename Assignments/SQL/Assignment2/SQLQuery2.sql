create database employee
use employee


create table Employees (
    employee_id int primary key,
    employee_name varchar(100),
    department varchar(50),
    salary int
);

insert into Employees (employee_id, employee_name, department, salary)
values
(101, 'Vishnu', 'IT', 50000),
(102, 'kavi', 'HR', 60000),
(103, 'Rika', 'Finance', 55000);

create function dbo.get_salary (@employee_id int)
returns int
as
begin
    return (
        select salary
        from Employees
        where employee_id = @employee_id
    );
end;
select dbo.get_salary(102) as Salary;

create function dbo.RectangleArea(@Length int,@Width  int)
returns int
as
begin
return @Length * @Width;
end;

select dbo.RectangleArea(10,5) as Area;