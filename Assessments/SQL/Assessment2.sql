use Assignment2
select datename(weekday,'2005-05-24') as birthday_day;



select datediff(day,'2005-05-24',getdate()) as age_in_days;

select * 
from Emp
where  month(hiredate)=month(getdate()) and hiredate<=dateadd(year,-5,getdate());

begin transaction;
insert into Emp values(11,'VP','Developer',null,'2026-03-04',50000,null,10);
insert into Emp values(12,'Rk','Developer',null,'2020-03-07',60000,null,10);
insert into Emp values(13,'Kv','Developer',null,'2018-02-10',70000,null,10);

select* from Emp update emp set sal=sal*1.15
where empno=12;

select* from Emp update emp set sal=1400
where empno=7499;

save transaction dl1;

delete from emp where empno=13;

rollback transaction dl1;
commit;

select * from Emp;



go
create function calculate_bonus (@deptno int, @sal int)
returns decimal(10,2)
as
begin
    return 
        case 
            when @deptno = 10 then @sal * 0.15
            when @deptno = 20 then @sal * 0.20
            else @sal * 0.05
        end;
end;
go


select empno, ename, deptno, sal,
       dbo.calculate_bonus(deptno, sal) as Bonus
from Emp;



go
create procedure update_sales_salary
as
begin
    update emp
    set sal = sal + 500
    where deptno IN (
        select deptno 
        from dept 
        where dname = 'Salesman'
    )
    and sal < 1500;
end;


exec update_sales_salary;

select * 
from emp 
where deptno in (select deptno from dept where dname = 'Salesman');
