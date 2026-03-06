using System;

class Program
{
    private static List<Activity> activities = [
        new BreathingActivity(),
        new ReflectionActivity(),
        new ListingActivity()
    ];

    static void Main(string[] args)
    {
        int activitiesNum = activities.Count();
        bool quit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("Choose... \n");
            for (int i = 0; i < activitiesNum; i++)
            {
                Console.WriteLine($"{i}. Start {activities[i].GetActivityName()} Activity");
            }
            Console.WriteLine("Any Else. Quit");

            string input = Console.ReadLine();
            int optionNumber = -1;
            if (!int.TryParse(input, out optionNumber)) optionNumber = -1;

            if (optionNumber >= 0 && optionNumber < activitiesNum)
            {
                activities[optionNumber].StartActivity();
            }
            else
            {
                quit = true;
            }
        } while(!quit);
        
    }
}