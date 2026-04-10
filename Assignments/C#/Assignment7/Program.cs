using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    

    class Program
    {
        static void Main()
        {
            // Input list
            List<int> numbers = new List<int> { 7, 2, 30 };

            // LINQ query: number and its square only if square > 20
            var result = numbers
                .Select(n => new { Number = n, Square = n * n })
                .Where(x => x.Square > 20);

            // Output
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }
        }
    }
}
