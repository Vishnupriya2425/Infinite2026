using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    abstract class Student
    {
        public string StudentName;
        public int StudentId;
        public double StudentGrade;
        public abstract bool isPassed(double studentGrade);
    }
    class UnderGraduate : Student
    {
        public override bool isPassed(double studentGrade)
        {
            return studentGrade >= 70;

        }
    }
    class Graduate : Student
    {
        public override bool isPassed(double studentGrade)
        {
            return studentGrade >= 80;
        }
    }
    class StudentProgram
    {
        static void Main()
        {
            UnderGraduate underGraduate = new UnderGraduate();
            Console.WriteLine("Enter the name of the undergraduate student :");
            underGraduate.StudentName = Console.ReadLine();
            Console.WriteLine("Enter the id of the undergraduate student :");
            underGraduate.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the grade of the undergraduate student :");
            underGraduate.StudentGrade = Convert.ToDouble(Console.ReadLine());
            if (underGraduate.isPassed(underGraduate.StudentGrade))
            {
                Console.WriteLine("Undergraduate student " + underGraduate.StudentName + " has passed.");
            }
            else
            {
                Console.WriteLine("Undergraduate student " + underGraduate.StudentName + " has failed.");
            }
            Graduate graduate = new Graduate();
            Console.WriteLine("\nEnter the name of the graduate student :");
            graduate.StudentName = Console.ReadLine();
            Console.WriteLine("Enter the id of the graduate student :");
            graduate.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the grade of the graduate student :");
            graduate.StudentGrade = Convert.ToDouble(Console.ReadLine());
            if (graduate.isPassed(graduate.StudentGrade))
            {
                Console.WriteLine("Graduate student " + graduate.StudentName + " has passed.");
            }
            else
            {
                Console.WriteLine("Graduate student " + graduate.StudentName + " has failed.");
            }
            Console.ReadLine();
        }
    }
}

