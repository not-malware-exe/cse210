using System;

class Program
{
    static int input_percentage(string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        int value = 0;

        if (int.TryParse(str, out value))
        {
            if (value < 0)
            {
                Console.WriteLine("Percentage can't be less than 0, try again.");
                return input_percentage(prompt);
            } 
            else if (value > 100)
            {
                Console.WriteLine("Percentage can't be greater than 100, try again.");
                return input_percentage(prompt);
            }
        }
        else
        {
            Console.WriteLine("Entry has to be an integer, try again.");
            return input_percentage(prompt);
        }
        return value;
    }

    static void Main(string[] args)
    {
        var grades = new Dictionary<int,string>{{93,"A"},{90,"A-"},{87,"B+"},{83,"B"},{80,"B-"},{77,"C+"},{73,"C"},{70,"C-"},{67,"D+"},{63,"D"},{60,"D-"},{0,"F"}};

        int grade_percentage = input_percentage("What is your grade percent? ");
        
        foreach (int grade_percentage_threshold in grades.Keys)
        {
            if (grade_percentage >= grade_percentage_threshold)
            {
                Console.WriteLine($"Your grade letter is a {grades[grade_percentage_threshold]}.");
                break;
            }
        }
        if (grade_percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("... and you failed.");
        }
    }
}