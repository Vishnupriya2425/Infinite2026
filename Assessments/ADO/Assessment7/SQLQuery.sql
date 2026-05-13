create database EmployeeManagement;

use EmployeeManagement;


CREATE TABLE Employee_Details
(
    Empno int primary key,
    EmpName varchar(50) NOT NULL,
    Empsal numeric(10,2) check (Empsal >= 25000),
    Emptype char(1) check (Emptype IN ('F', 'P')),
    EmpDepId int
);
CREATE OR ALTER PROC sp_AddEmployee
    @ename VARCHAR(50),
    @esal NUMERIC(10,2),
    @etype CHAR(1),
    @deptid INT
AS
BEGIN
    DECLARE @eid INT

    SELECT @eid = ISNULL(MAX(Empno),0) + 1 FROM Employee_Details

    INSERT INTO Employee_Details (Empno, EmpName, Empsal, Emptype, EmpDepId)
    VALUES (@eid, @ename, @esal, @etype, @deptid)

    SELECT * FROM Employee_Details WHERE Empno = @eid
END
exec sp_AddEmployee 'Ravi', 30000, 'F',12;
exec sp_AddEmployee 'Priya', 28000, 'P',10;

select * from Employee_Details;

create or alter proc sp_updatesalary
    @eid int
    
as
begin
    update employee_details
    set empsal = empsal + 100
    where empno = @eid

    select *
    from employee_details
    where empno = @eid
end


exec sp_updatesalary 5
select * from Employee_Details



--USE EmployeeManagement;
--GO
--CREATE USER [INFICS\vishnupriyaa] FOR LOGIN [INFICS\vishnupriyaa];
--ALTER ROLE db_owner ADD MEMBER [INFICS\vishnupriyaa];
