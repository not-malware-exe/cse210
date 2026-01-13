using System;
using System.Globalization;

class Program
{
    static void display_welcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string prompt_user_name(string prompt)
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        return str;
    }

    static int prompt_user_number(string prompt = "")
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
            return prompt_user_number(prompt);
        }
    }

    static void prompt_user_birth_year(out int birth_year, string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        int value = 0;

        if (int.TryParse(str, out value))
        {
            birth_year = value;
        }
        else
        {
            Console.WriteLine("Entry has to be an integer, try again.");
            prompt_user_birth_year(out birth_year, prompt);
        }
    }

    static int square_number(int value)
    {
        double double_value = value;
        return (int)Math.Pow(double_value,2);
    } 

    static void display_result(string user_name,int squared_number,int birth_year)
    {
        Console.WriteLine($"{user_name}, your favorite number squared is {squared_number}.");
        int year = DateTime.Now.Year;
        int user_age = year - birth_year;
        Console.WriteLine($"{user_name}, you are or will be {user_age} as of {year}.");
    }
    static void Main(string[] args)
    {
        display_welcome();
        string user_name = prompt_user_name("What is your name?");
        int favorite_number = prompt_user_number("What is your favorite number?");
        int user_birth_year = -999999;
        prompt_user_birth_year(out user_birth_year, "What is your birth year");
        int squared_number = square_number(favorite_number);
        display_result(user_name,squared_number,user_birth_year);
    }
}