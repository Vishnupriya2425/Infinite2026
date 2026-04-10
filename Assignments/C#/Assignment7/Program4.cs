using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLibrary;

namespace Assignment7
{
    class Program4
    {
        const double TotalFare = 500;

        static void Main(string[] args)
        {
            string name;
            int age;

            Console.WriteLine("Enter Passenger Name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter Age:");
            age = Convert.ToInt32(Console.ReadLine());

            Concession concession = new Concession();
            string result = concession.CalculateConcession(age, TotalFare);

            Console.WriteLine("\nPassenger Name: " + name);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
