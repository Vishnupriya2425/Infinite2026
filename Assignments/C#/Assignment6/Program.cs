using System;
using System.IO;

namespace Assignment6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayBookShelf();
            Console.ReadLine();
            WriteAndReadFromFile();
            CountLinesInFile();
        }

        static void DisplayBookShelf()
        {
            string[] bookNames =
            {
                "Harry Potter",
                "The Tempest",
                "Pride and Prejudice",
                "The Great Gatsby",
                "To Kill a Mockingbird"
            };

            string[] authorNames =
            {
                "J. K. Rowling",
                "William Shakespeare",
                "Jane Austen",
                "F. Scott Fitzgerald",
                "Harper Lee"
            };

            Console.WriteLine("\n--- BOOK DETAILS ---");

            for (int i = 0; i < bookNames.Length; i++)
            {
                Console.WriteLine("Book: " + bookNames[i] +
                                  ", Author: " + authorNames[i]);
                
            }
        }

            public static void WriteAndReadFromFile()
            {
                string filePath = "books.txt";

                string[] books =
                {
                "Harry Potter",
                "The Tempest",
                "Pride and Prejudice",
                "The Great Gatsby",
                "To Kill a Mockingbird"
            };
            Console.WriteLine("\n--- Write and Read from File ---");

            File.WriteAllLines(filePath, books);
                Console.WriteLine("Data written to file successfully.\n");

                Console.WriteLine("Reading data from file:");
                string[] fileData = File.ReadAllLines(filePath);


                foreach (string line in fileData)
                {
                    Console.WriteLine(line);
                }

                Console.ReadLine();
            }

            public static void CountLinesInFile()

            {
            Console.WriteLine("\n--- Counting Lines In File ---");
            string filePath = "books.txt";

            int lineCount = File.ReadAllLines(filePath).Length;

            Console.WriteLine("Number of lines in the file: " + lineCount);

            Console.ReadLine();
            }

    }
}
