using System;


namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckEqual();
            CheckPosOrNeg();
            Operations();
            MultiplicationTable();
            CheckValues();
        }
        public static void CheckEqual()
        {
            int a, b;
            Console.WriteLine("Enter a number : ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a number : ");
            b = Convert.ToInt32(Console.ReadLine());
            string res = (a == b) ? "Equal" : "Not Equal";
            Console.WriteLine(res);
        }

        public static void CheckPosOrNeg()
        {
            int a;
            Console.WriteLine("Enter a number : ");
            a = Convert.ToInt32(Console.ReadLine());
            string res = (a > 0) ? "Positive" : "Negative";
            Console.WriteLine(res);
        }

        public static void Operations()
        {
            int a, b;
            Console.WriteLine("Enter a number : ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a number : ");
            b = Convert.ToInt32(Console.ReadLine());
            int sum = a + b;
            int diff = a - b;
            int mul = a * b;
            int div = a / b;
            Console.WriteLine("Sum = " + sum + "\nDifference = " + diff + "\nMultiply = " + mul + "\nDivide = ", div);
        }
        public static void MultiplicationTable()
        {
            int a;
            Console.WriteLine("Enter a number : ");
            a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
            {
                int res = a * i;
                Console.WriteLine(a + " * " + i + " = " + res);
            }
            Console.WriteLine();
        }
        public static void CheckValues()
        {
            int a, b;
            Console.WriteLine("Enter a number : ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a number : ");
            b = Convert.ToInt32(Console.ReadLine());
            if (a == b)
            {
                Console.WriteLine(3 * (a + b));
            }
            else
            {
                Console.WriteLine("Not same");
            }
        }
    }
}