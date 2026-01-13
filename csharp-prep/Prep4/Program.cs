using System; 
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static int input_int(string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        int value = 0;

        if (int.TryParse(str, out value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("Entry has to be an integer, try again.");
            return input_int(prompt);
        }
    }
    static void Main(string[] args)
    {
        List<int> list = [];

        Console.WriteLine("Enter a list of whole numbers, enter 0 to end.");

        do
        {
            list.Add(input_int("Enter a number:"));
        } while (list[list.Count - 1] != 0);

        int sum = 0;
        int largest_number = 0;
        // int smallest_positive_number = 0;
        int smallest_number = 0;

        foreach (int value in list)
        {
            if (value > largest_number){largest_number = value;}
            // if ((value < smallest_positive_number) && (value > 0)){smallest_positive_number = value;}
            if (value < smallest_number){smallest_number = value;}

            sum += value;
        }

        float average_number = ((float)sum) / list.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average number (including the zero) is: {average_number}");
        Console.WriteLine($"The largest number is: {largest_number}");
        // Console.WriteLine($"The smallest positive number is: {smallest_positive_number}");
        Console.WriteLine($"The smallest number is: {smallest_number}");
    }
}