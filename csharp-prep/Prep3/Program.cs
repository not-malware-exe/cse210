using System;

class Program
{
    static int input_pos_int(string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        int value = 0;

        if (int.TryParse(str, out value))
        {
            if (value < 0)
            {
                Console.WriteLine("Integer has to be greater than 0.");
                return input_pos_int(prompt);
            }
        }
        else
        {
            Console.WriteLine("Entry has to be an integer, try again.");
            return input_pos_int(prompt);
        }

        return value;
    }

    static void Main(string[] args)
    {
        int max_number = input_pos_int("Please enter a whole number greater than 0.");
        Random rnd = new Random();
        int magic_number = rnd.Next(0,max_number);
        int guess = -1;
        int number_of_guesses = 0;

        do
        {
            
            if (number_of_guesses == 0){guess = input_pos_int($"Please guess a whole number from 0 to {max_number}");}
            else if (guess > magic_number){guess = input_pos_int("Too high, try again.");}
            else if (guess < magic_number){guess = input_pos_int("Too low, try again.");}

            number_of_guesses++;
            
        } while (guess != magic_number);

        Console.WriteLine("Correct!");
        Console.WriteLine($"You guessed {number_of_guesses} times.");

    }
}