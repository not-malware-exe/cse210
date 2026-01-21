using System;

class Program
{
    // prompts user for integer and repeats until user enters integer
    static int InputInt(string prompt = "")
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
            return InputInt(prompt);
        }
    }

    static void Main(string[] args)
    {
        Random rnd = new Random();
        string[] prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",

            "What is your social security number?",
            "What are the numbers on the front and back of your credit card?",
            "Where do you live?",
            "What is your first, middle, last, and mother's maiden name?",
            "Where did you go to Elementary School?",
            "What is the name of your first dog?",
            "Where were you born?",
            "What is your nationality?",
        ];
        
        // Class that stores, displays, saves and loads user entries
        Log log = new Log();

        bool quit = false;
        do
        {
            //Prompts user for number from 1-5, case code block would run if corresponding choice is entered
            Console.WriteLine("Please enter a number corresponding to the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Erase");
            Console.WriteLine("6. Quit");
            int choice = InputInt("What will it be?");

            switch (choice)
            {
                case 1: // prompts user to create a new entry that gets appended to log
                    string prompt = prompts[rnd.Next(0,prompts.Length - 1)];
                    Console.WriteLine(prompt);

                    string responce = Console.ReadLine();

                    log.AddEntry(new Entry(prompt,responce));
                    break;
                case 2: // displays all entries in log
                    log.Display();
                    break;
                case 3: // saves entries to entered file from log
                    Console.WriteLine("What is your file path?");
                    log.Save(Console.ReadLine());
                    break;
                case 4: // loads entries from entered file to log
                    Console.WriteLine("What is your file path?");
                    log.Load(Console.ReadLine());
                    break;
                case 5: // wipes all data from log and file
                    Console.WriteLine("What is your file path?");
                    log.Erase(Console.ReadLine());
                    break;
                case 6: // Causes loop to end
                    quit = true;
                    break;
                default: // Nothing happens
                    Console.WriteLine("Choice must be any number from 1-5.");
                    break;
            }

        } while(!quit);
    }
}