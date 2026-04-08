using System;

struct Dob
{
    public int Day;
    public int Month;
    public int Year;
}
struct EmployeeDetails
{
    public string Name;
    public Dob Dob;
}

class NestedStruct
{
    static void Main()
    {
        EmployeeDetails[] employee = new EmployeeDetails[2];
        for (int i = 0; i < employee.Length; i++)
        {
            Console.WriteLine("Enter the details of the employee {0}:", i + 1);
            Console.WriteLine("Enter the employee name:");
            employee[i].Name = Console.ReadLine();
            Console.WriteLine("Enter the employee date of birth:");
            employee[i].Dob.Day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the employee month of birth:");
            employee[i].Dob.Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the employee year of birth:");
            employee[i].Dob.Year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
        }
            Console.WriteLine("Employee details");
            for (int i = 0; i < employee.Length; i++)
            {
            Console.WriteLine("Employee name: {0}", employee[i].Name + "/" + employee[i].Dob.Day + "/" + employee[i].Dob.Month + "/" + employee[i].Dob.Year);
            Console.WriteLine();
            }
        
    }
}



