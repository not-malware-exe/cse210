
public class ListingActivity : Activity
{
    private Random rand = new Random();
    
    private string[] prompts = [
        "Who are people that you appreciate?... ",
        "What are personal strengths of yours?... ",
        "Who are people that you have helped this week?... ",
        "When have you felt the Holy Ghost this month?... ",
        "Who are some of your personal heroes?... "
    ];

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public ListingActivity(float duration) : base(duration)
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public void PrintRandomPrompt(int pauseSeconds = 3)
    {
        Console.Clear();
        Console.Write(prompts[rand.Next(0,prompts.GetLength(0) - 1)]);
        PrintCountDown(pauseSeconds);
    }

    public void PromptEntry(int itemNumber = 0)
    {
        Console.Write($"{itemNumber}. ");
        Console.ReadLine();
    }

    public override void DoActivity()
    {
        float remainingDuration = _duration;

        float pauseDuration = remainingDuration >= 3.0f ? 3.0f : (float)Math.Floor(remainingDuration);
        PrintRandomPrompt((int)pauseDuration);
        remainingDuration -= pauseDuration;

        if (remainingDuration == 0.0f)
        {
            Console.WriteLine("Looks as if you don't have any time to list anything, LOSER!");
        }
        else
        {
            Console.WriteLine($"You have {remainingDuration} seconds to list as many items as you can!");
            
            DateTime startTime = DateTime.Now;
            int numOfEntries = 0;

            do 
            {
                PromptEntry(numOfEntries);
                numOfEntries++;
                remainingDuration -= (float)DateTime.Now.Subtract(startTime).TotalSeconds;
            } while(remainingDuration >= 0.0f);

            Console.Write($"You typed out {numOfEntries} entries.\nYou went {-remainingDuration} seconds over... ");
            if (remainingDuration > -1.0f) Console.Write($"impressive.\n");
            else if (remainingDuration > -5.0f) Console.Write($"even my grandma can type faster than you.\n");
            else Console.Write($"I'm not paying you overtime.\n");
        }

    }
    
}