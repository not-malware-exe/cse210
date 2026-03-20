public static class Inputs
{
    // returns user input as string
    public static string InputStr(string prompt = "")
    {
        Console.WriteLine(prompt);
        string str = Console.ReadLine();

        return str;
    }
    // returns user input as integer
    public static int InputInt(string prompt = "")
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
            return InputInt(prompt);
        }
    }
}