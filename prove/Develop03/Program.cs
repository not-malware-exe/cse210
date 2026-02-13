using System;

class Program
{
    // Function that returns user defined integer
    static int PromptInt(string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        int value = 0;

        if (int.TryParse(str, out value)) // Can be parsed as integer
        {
            return value;
        }
        else // Can't be integer
        {
            Console.WriteLine("Entry has to be an integer, try again.");
            return PromptInt(prompt);
        }
    }
    
    static void Main(string[] args)
    {
        // Creates scripture object with a hardcoded scripture
        Scripture scripture = new Scripture("Genesis 1", 1, 5,
"In the beginning God created the heaven and the earth. And the earth was without form, and void; and darkness was upon the face of the deep. And the Spirit of God moved upon the face of the waters. And God said, Let there be light: and there was light. And God saw the light, that it was good: and God divided the light from the darkness. And God called the light Day, and the darkness he called Night. And the evening and the morning were the first day.");

        bool continueProgram = true;
        do
        {
            
            Console.WriteLine(scripture.GetFullToggledScripture());

            Console.WriteLine("Please enter a character corresponding to the following:");
            Console.WriteLine("'a': hide 5 letters.");
            Console.WriteLine("'b': hide custom letters.");
            Console.WriteLine("'c': hide all letters.");
            Console.WriteLine("'d': reveal all letters.");
            Console.WriteLine("'e': enter new scripture.");
            Console.WriteLine("'quit': quit.");

            string userResponce = Console.ReadLine();

            switch(userResponce){
                case "a": // Hides 5 words
                    scripture.HideRandomWords(5);
                    break;
                case "b": // Hides user defined amount of words
                    int hideNum = PromptInt("How many? ");
                    scripture.HideRandomWords(hideNum);
                    break;
                case "c": // Hides all revealed words
                    scripture.HideAllWords();
                    break;
                case "d": // Reveals all hidden words
                    scripture.RevealAllWords();
                    break;
                case "e": // Create different Scripture object
                    Console.WriteLine("What book and chapter? ");
                    string chapter = Console.ReadLine();

                    int firstVerse = PromptInt("What is the first verse? ");

                    int lastVerse = PromptInt("What is the last verse? ");
                    Console.WriteLine("What is the text? (Must not have line breaks.)");
                    string text = Console.ReadLine();

                    scripture = new Scripture(chapter,firstVerse,lastVerse,text);
                    break;
                case "quit":// Ends program loop
                    continueProgram = false;
                    break;
                default: 
                    Console.WriteLine("Entry not valid.");
                    break;
            }
            
        } while (continueProgram);

    }
}