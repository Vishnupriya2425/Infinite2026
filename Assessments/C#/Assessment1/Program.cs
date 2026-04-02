using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    class Employee
    {
        public int EmpId;
        public string EmpName;
        public double Salary;
        public string Department;
    }
    class EmployeeProgram
    {
        static List<Employee> employees = new List<Employee>();
        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Search Employee using ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        DisplayEmployees();
                        break;
                    case 3:
                        SearchEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;

                }

            }
            while (choice != 6);
        }

            static void AddEmployee()
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter the employee ID :");
                employee.EmpId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the employee Name :");
                employee.EmpName = Console.ReadLine();
                Console.WriteLine("Enter the employee Salary :");
                employee.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the employee Department :");
                employee.Department = Console.ReadLine();

                employees.Add(employee);
                Console.WriteLine("The according employee added successfully!!!");

            }
            static void DisplayEmployees()
            {
                if (employees.Count == 0)
                {
                    Console.WriteLine("There is no employees to display");
                    return;
                }
                foreach (Employee emp in employees)
                {
                    Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, Salary: {emp.Salary}, Department: {emp.Department}");
                }

            }
            static void SearchEmployee()
            {
                Console.WriteLine("Enter the employee ID to search :");
                int empId = Convert.ToInt32(Console.ReadLine());
                foreach (Employee emp in employees)
                {
            if (emp.EmpId == empId)
            {
                Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, Salary: {emp.Salary}, Department: {emp.Department}");
                return;
            }
            else
            {
                Console.WriteLine("There is no employee for the given ID");
            }
                }

            }
            static void UpdateEmployee()
            {
                Console.WriteLine("Enter the ID to be updated :");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Employee emp in employees)
                {
                    if (emp.EmpId != id)
                    {
                        Console.WriteLine("There is no employee for the given ID");
                        return;
                    }
                    Console.WriteLine("Enter the new name:");
                    emp.EmpName = Console.ReadLine();
                    Console.WriteLine("Enter the new department:");
                    emp.Department = Console.ReadLine();
                    Console.WriteLine("Enter the new salary:");
                    emp.Salary = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("The details of the Employee have been updated successfully!!!");
                    return;
                }
            }
            static void DeleteEmployee()
            {
                Console.WriteLine("Enter the ID to be deleted :");
                int id = Convert.ToInt32(Console.ReadLine());
                for(int i=0;i<employees.Count;i++)
                {
                   if (employees[i].EmpId == id)
                   {
                     employees.RemoveAt(i);
                     Console.WriteLine("The Employee has been deleted successfully!!!");
                     return;
                   }
                   else
                   {
                     Console.WriteLine("There is no employee for the given ID");
                   }
                }
            }
        }
