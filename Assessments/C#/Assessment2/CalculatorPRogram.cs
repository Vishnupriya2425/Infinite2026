using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class CalculatorPRogram
    {
        delegate int Calculator(int a, int b);
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static void performOperation(int g, int v, Calculator operation)
        {
            int result = operation(g, v);
            Console.WriteLine("Result : " + result);
        }
        static void Main()
        {
            int number1, number2;
            Console.WriteLine("Enter the first number :");
            number1 =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number :");
            number2=Convert.ToInt32(Console.ReadLine());
            
            performOperation(number1, number2, Add);
            performOperation(number1, number2, Subtract);
            performOperation(number1, number2, Multiply);

            Console.ReadLine();
        }
    }
}
