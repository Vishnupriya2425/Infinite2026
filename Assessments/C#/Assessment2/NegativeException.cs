using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class NegativeException
    {
        static void CheckNegative(int number)
        {
            if (number < 0)
            {
                throw new Exception("Negative numbers are not allowed.");
            }
            else
            {
                Console.WriteLine("The number " + number +" is valid");
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter a number :");
            int number = Convert.ToInt32(Console.ReadLine());
            try
            {
                CheckNegative(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : "+ex.Message);
            }
            Console.ReadLine();
        }
    }
}
