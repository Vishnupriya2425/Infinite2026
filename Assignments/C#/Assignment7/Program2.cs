using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    
    class Program2
    {
        static void Main()
        {
            // Input list
            List<string> words = new List<string> { "mum", "amsterdam", "bloom" };

            // words starting with 'a' and ending with 'm'
            var result = words
                .Where(word => word.StartsWith("a") && word.EndsWith("m"));

            // Output
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }

    
}
