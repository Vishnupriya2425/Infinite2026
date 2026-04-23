using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Designation { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string City { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 1001, FirstName="Malcolm", LastName="Daruwalla", Designation="Manager", DateOfBirth=new DateTime(1984,11,16), DateOfJoining=new DateTime(2011,6,8), City="Mumbai"},
            new Employee { EmployeeId = 1002, FirstName="Asdin", LastName="Dhalla", Designation="AsstManager", DateOfBirth=new DateTime(1984,8,20), DateOfJoining=new DateTime(2012,7,7), City="Mumbai"},
            new Employee { EmployeeId = 1003, FirstName="Madhavi", LastName="Oza", Designation="Consultant", DateOfBirth=new DateTime(1987,11,14), DateOfJoining=new DateTime(2015,4,12), City="Pune"},
            new Employee { EmployeeId = 1004, FirstName="Saba", LastName="Shaikh", Designation="SE", DateOfBirth=new DateTime(1990,6,3), DateOfJoining=new DateTime(2016,2,2), City="Pune"},
            new Employee { EmployeeId = 1005, FirstName="Nazia", LastName="Shaikh", Designation="SE", DateOfBirth=new DateTime(1991,3,8), DateOfJoining=new DateTime(2016,2,2), City="Mumbai"},
            new Employee { EmployeeId = 1006, FirstName="Amit", LastName="Pathak", Designation="Consultant", DateOfBirth=new DateTime(1989,11,7), DateOfJoining=new DateTime(2014,8,8), City="Chennai"},
            new Employee { EmployeeId = 1007, FirstName="Vijay", LastName="Natrajan", Designation="Consultant", DateOfBirth=new DateTime(1989,12,2), DateOfJoining=new DateTime(2015,6,1), City="Mumbai"},
            new Employee { EmployeeId = 1008, FirstName="Rahul", LastName="Dubey", Designation="Associate", DateOfBirth=new DateTime(1993,11,11), DateOfJoining=new DateTime(2014,11,6), City="Chennai"},
            new Employee { EmployeeId = 1009, FirstName="Suresh", LastName="Mistry", Designation="Associate", DateOfBirth=new DateTime(1992,8,12), DateOfJoining=new DateTime(2014,12,3), City="Chennai"},
            new Employee { EmployeeId = 1010, FirstName="Sumit", LastName="Shah", Designation="Manager", DateOfBirth=new DateTime(1991,4,12), DateOfJoining=new DateTime(2016,1,2), City="Pune"}
        };

        var allEmployees = employees;

        Console.WriteLine("All Employees:");
        foreach (var emp in allEmployees)
        {
            Console.WriteLine($"{emp.EmployeeId} {emp.FirstName} {emp.LastName} {emp.Designation} {emp.City}");
        }

        var employeesOutsideMumbai = employees.Where(e => e.City != "Mumbai");
        Console.WriteLine("\nEmployees not from Mumbai:");
        foreach (var emp in employeesOutsideMumbai)
        {
            Console.WriteLine($"{emp.EmployeeId} {emp.FirstName} {emp.City}");
        }

        var assistantManagers = employees.Where(e => e.Designation == "AsstManager");
        Console.WriteLine("\nAssistant Managers:");
        foreach (var emp in assistantManagers)
        {
            Console.WriteLine($"{emp.EmployeeId} {emp.FirstName} {emp.Designation}");
        }

        var lastNamesStartingWithS = employees.Where(e => e.LastName.StartsWith("S"));
        Console.WriteLine("\nEmployees whose last name starts with 'S':");
        foreach (var emp in lastNamesStartingWithS)
        {
            Console.WriteLine($"{emp.EmployeeId} {emp.FirstName} {emp.LastName}");
        }
    }
}