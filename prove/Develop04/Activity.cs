
public class Activity
{
    
    protected float _duration = 0;
    protected string _name = "";
    protected string _description = "";


    public Activity()
    {
        _name = "___";
        _description = "___";
    }

    public Activity(float duration)
    {
        _name = "___";
        _description = "___";
        _duration = duration;
    }

    public string GetActivityName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }

    public float PromptDuration()
    {
        string consoleInput = "";
        bool inputFailed = false;


        do
        {
            Console.WriteLine("How long, in seconds, to you like for your session?");
            consoleInput = Console.ReadLine();

            inputFailed = !float.TryParse(consoleInput,out _duration); // checks if input is an integer
            if (!inputFailed) inputFailed = _duration < 0; // checks a second time if input did not fail prior if input is not negative

            if (inputFailed) Console.WriteLine("Input must be a positive float, try again.");

        } while (inputFailed);
        
        return _duration;
    }
    
    public void PrintStartingMessage()
    {
        Console.WriteLine($"Welcome to the {GetActivityName()} activity.");
    }
    public void PrintCompletionMessage()
    {
        Console.WriteLine($"You have completed {_duration} seconds of the {GetActivityName()} activity.");
    }

    // plays a count down in console for set number of seconds
    public void PrintCountDown(int seconds, bool display0 = true)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the character
        }
        if (display0) Console.Write($"0\n");
        else Console.Write($"\n");
    }

    // plays a spinner animation in console for set duration
    public void PrintSpinnerAnimation(float spinDuration)
    {
        char[] frames = ['|','/','-','\\'];
        int frameNum = 4;
        int currentFrame = 0;
        float frameDuration = 0.1f;

        int count = (int)Math.Ceiling(spinDuration / frameDuration);
        float remainderDuration = spinDuration % frameDuration;

        for (int i = count; i > 0; i--)
        {
            Console.Write($"{frames[currentFrame]}");
            if (i > 1 || remainderDuration == 0.0) Thread.Sleep((int)(frameDuration * 1000.0f));
            else Thread.Sleep((int)(remainderDuration * 1000.0f));
            Console.Write("\b \b"); // erase the character
            currentFrame = (currentFrame + 1) % frameNum;
        }
    }

    public void PrintReady()
    {
        Console.Write("Get ready: ");

        PrintCountDown(3);
    }

    public void PrintDone()
    {
        Console.WriteLine("Well Done!\n");

        PrintSpinnerAnimation(3.0f);
    }

    public virtual void DoActivity()
    {
        PrintSpinnerAnimation(_duration);
    }
    
    public void StartActivity()
    {
        Console.Clear();

        PrintStartingMessage();
        Console.WriteLine(GetDescription());
        PromptDuration();
        Console.Clear();
        
        PrintReady();
        DoActivity();
        PrintDone();
        PrintCompletionMessage();
    }
}