using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
        class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpCity { get; set; }
            public decimal EmpSalary { get; set; }
        }

        class Program3
        {
            static void Main(string[] args)
            {
                // Populate employee list
                List<Employee> employees = new List<Employee>
            {
                new Employee { EmpId = 101, EmpName = "Arun", EmpCity = "Bangalore", EmpSalary = 55000 },
                new Employee { EmpId = 102, EmpName = "Divya", EmpCity = "Chennai", EmpSalary = 42000 },
                new Employee { EmpId = 103, EmpName = "Karthik", EmpCity = "Bangalore", EmpSalary = 48000 },
                new Employee { EmpId = 104, EmpName = "Meena", EmpCity = "Hyderabad", EmpSalary = 60000 },
                new Employee { EmpId = 105, EmpName = "Suresh", EmpCity = "Pune", EmpSalary = 38000 }
            };

                // a. Display all employees
                Console.WriteLine("All Employees:");
                DisplayEmployees(employees);

                // b. Employees with salary > 45000
                Console.WriteLine("\nEmployees with Salary > 45000:");
                var highSalaryEmp = employees.Where(e => e.EmpSalary > 45000);
                DisplayEmployees(highSalaryEmp);

                // c. Employees from Bangalore
                Console.WriteLine("\nEmployees from Bangalore:");
                var bangaloreEmp = employees.Where(e => e.EmpCity == "Bangalore");
                DisplayEmployees(bangaloreEmp);

                // d. Employees sorted by name (ascending)
                Console.WriteLine("\nEmployees Sorted by Name (Ascending):");
                var sortedByName = employees.OrderBy(e => e.EmpName);
                DisplayEmployees(sortedByName);

                Console.ReadLine();
            }

            // method to display employee data
            static void DisplayEmployees(IEnumerable<Employee> empList)
            {
                foreach (var emp in empList)
                {
                    Console.WriteLine($"Id: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                }
            }
        }
    
}
