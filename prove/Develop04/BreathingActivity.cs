
public class BreathingActivity : Activity
{

    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public BreathingActivity(float duration) : base(duration)
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void PrintBreathIn()
    {
        Console.Clear();
        Console.Write("Breath in... ");
        PrintCountDown(3);
    }
    public void PrintBreathOut()
    {
        Console.Clear();
        Console.Write("  Breath out... ");
        PrintCountDown(4);
    }
    public void PrintBreathIG(float remainderDuration)
    {
        Console.Clear();
        Console.WriteLine("Breath or don't, you choose.");
        PrintSpinnerAnimation(remainderDuration);
    }

    public override void DoActivity()
    {
        for (float i = _duration; i >= 7.0f; i -= 7.0f)
        {
            PrintBreathIn();
            PrintBreathOut();
        }

        if (_duration % 7.0f != 0.0f)
        {
            PrintBreathIG(_duration % 7.0f);
        }
    }
    
}