
public class ReflectionActivity : Activity
{
    private Random _rand = new Random();
    
    private string[] _prompts = [
        "Think of a time when you stood up for someone else... ",
        "Think of a time when you did something really difficult... ",
        "Think of a time when you helped someone in need... ",
        "Think of a time when you did something truly selfless... "
    ];
    private string[] _questions = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    public ReflectionActivity()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public ReflectionActivity(float duration) : base(duration)
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void PrintRandomPrompt(int pauseSeconds = 3)
    {
        Console.Clear();
        Console.Write(_prompts[_rand.Next(0,_prompts.GetLength(0) - 1)]);
        PrintCountDown(pauseSeconds,false);
        Console.Write("\n");
    }

    public void PrintRandomQuestion(float pauseDuration = 3.0f)
    {
        Console.WriteLine(_questions[_rand.Next(0,_questions.GetLength(0) - 1)]);
        PrintSpinnerAnimation(pauseDuration);
    }

    public override void DoActivity()
    {
        float remainingDuration = _duration;

        float pauseDuration = remainingDuration >= 3.0f ? 3.0f : (float)Math.Floor(remainingDuration);
        PrintRandomPrompt((int)pauseDuration);
        remainingDuration -= pauseDuration;

        while (remainingDuration > 0.0f)
        {
            pauseDuration = remainingDuration >= 3.0f ? 3.0f : remainingDuration;
            PrintRandomQuestion(pauseDuration);
            remainingDuration -= pauseDuration;
        }
    }
    
}