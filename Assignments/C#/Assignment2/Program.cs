using System;
using System.Net;


class JaggedArray
{

    static void Main(string[] args)
    {
        jaggedArray();
        Days();
        Array1();
        Array2();
        CopyArray();
        StringProgram();
    }

    static void jaggedArray()
    {
        int[][] jaggedArray = new int[4][];

        for (int i = 0; i < 4; i++)
        {
            jaggedArray[i] = new int[4];
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                jaggedArray[i][j] = 25;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if ((i + 1) % 2 == 0)
                {
                    Console.Write(jaggedArray[i][j]);
                }
                else
                {
                    Console.Write(jaggedArray[i][j]+ " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");
        Console.WriteLine();
    }

    //Printing the day according to number
    static void Days()
    {
        Console.WriteLine("Enter the number : ");
        int num = Convert.ToInt32(Console.ReadLine());

        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        int day = (num - 1) % 7;

        Console.WriteLine(days[day]);
        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine();
    }

    //Array (avg, min, max)
    static void Array1()
    {
        Console.WriteLine("Enter the number of elements : ");
        int n= Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Enter the elements : ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        int min = arr[0], max = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            
            sum += arr[i];
            if (arr[i] < min)
            {
                min = arr[i];
            }
            if (arr[i] > max)
            {
                max = arr[i];
            }

        }
        double avg = (double)sum / n ;
        Console.WriteLine("The average of array is : " + avg);
        Console.WriteLine("The minimum element of array is : "+ min);
        Console.WriteLine("The maximum element of array is : "+ max);
        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine();
    }

    //Array(2)

    static void Array2()
    {
        int[] arr = new int[10];
        int sum = 0;
        int temp;
        
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Enter the mark : ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        int min = arr[0], max = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            
            sum += arr[i];
            if (arr[i] < min)
            {
                min = arr[i];
            }
            if (arr[i] > max)
            {
                max = arr[i];
            }

        }
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }

            }
        }

        Console.WriteLine("Ascending Order:");
        foreach (int marks in arr)
        {
            Console.Write(marks + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }

                }
            }
        Console.WriteLine("Descending Order:");
        foreach (int marks in arr)
        {
            Console.Write(marks + " ");
        }
        Console.WriteLine();

        double avg = (double)sum / 10;
        Console.WriteLine("The sum of the marks is : " + sum);
        Console.WriteLine("The average of marks is : " + avg);
        Console.WriteLine("The minimum mark is :  " + min);
        Console.WriteLine("The maximum mark is :  " + max);
        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine();
    }

    //Copying one array to another array

    static void CopyArray()
    {
        Console.WriteLine("Enter the number of elements : ");
        int[] arr = new int[3];
        Console.ReadLine();
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Enter the elements : ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        int[] arr2= new int[arr.Length];
        for(int i = 0; i < arr.Length; i++)
        {
            arr2[i] = arr[i];
            
        }
        Console.WriteLine("The copied array is : ");
        for(int i = 0; i < arr2.Length; i++)
        {
            Console.Write(arr2[i]);
        }
        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine();
    }

    //String (length, reverse, checking is two strings are same)

    static void StringProgram()
    {
        Console.WriteLine("Enter the string : ");
        String word= Console.ReadLine();

        //Length of string
        int length= word.Length;
        Console.WriteLine("The length of string is : " + length);

        //reverse of string
        String wordrev="";
        for (int i = length - 1; i >= 0; i--)
        {
            wordrev += word;
            
        }
        Console.Write("Reverse of the string is : "+wordrev);
        Console.WriteLine();

        //Check whether both String are same or not
        Console.WriteLine("Enter the string to compare : ");
        String word2 = Console.ReadLine();
        if (word2 != word)
        {
            Console.WriteLine("Both strings are not same");
        }
        else
        {
            Console.WriteLine("Both strings are same");
        }
    }
}


