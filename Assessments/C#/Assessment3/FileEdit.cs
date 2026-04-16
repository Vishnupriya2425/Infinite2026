using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public class FileEdit
    {
        public static void Main (string[] args)
        {
            string filePath = "demo.txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                Console.WriteLine("The file has been created successfully!!!...");
            }
            Console.WriteLine("Enter the text to write to the file:");
            string text= Console.ReadLine();
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(text);
            }
            Console.WriteLine("The text has been written to the according file successfully!!!...");
        }
    }
}
