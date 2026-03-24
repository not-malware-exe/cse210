using System;

class Program
{
    static List<string> goalTypeNames = ["SimpleGoal","EternalGoal","SisypheanGoal","ChecklistGoal"];

    static void Main(string[] args)
    {
        string filePath = "save.json"; //Inputs.InputStr("Enter save file destination: ");
        SaveInstance saveInstance = new SaveInstance(filePath,-100);
        // saveInstance.LoadFromJson();

        bool quit = false;

        do
        {
            Console.Clear();
            Console.WriteLine($"You have {saveInstance.GetPoints()} points.\nYour level: {Levels.GetLevel(saveInstance.GetPoints())}\n");

            Thread.Sleep(3000);

            Console.WriteLine("Your options are: ");
            Console.WriteLine("'List Goals'");
            Console.WriteLine("'Create Goal'");
            Console.WriteLine("'Record Goal'");
            Console.WriteLine("'Clear Goals'");
            Console.WriteLine("'Load'");
            Console.WriteLine("'Save'");
            Console.WriteLine("'Stop Being Mean To Me'");
            Console.WriteLine("\nType any of the above wrong or type anything else -> Quit");

            string option = Inputs.InputStr("\nEnter your option: ");
            Console.Clear();

            switch (option)
            {
                case "List Goals":
                    saveInstance.DisplayGoals();
                    Inputs.InputStr("Enter anything to continue: ");
                    break;
                case "Create Goal":
                    int goalTypeOption = -1;

                    do
                    {
                        Console.WriteLine("Your options are: ");
                        for (int i = 0; i < goalTypeNames.Count(); i++)
                        {
                            Console.WriteLine($"{i}. {goalTypeNames[i]}");
                        }
                        goalTypeOption = Inputs.InputInt("\nEnter your option: ");

                        if (goalTypeOption < 0 || goalTypeOption >= goalTypeNames.Count())
                        {
                            Console.WriteLine("That was not an option.");
                            Thread.Sleep(2000);
                        }
                    } while (goalTypeOption < 0 || goalTypeOption >= goalTypeNames.Count());
                    Console.Clear();
                    
                    saveInstance.CreateGoal(goalTypeNames[goalTypeOption]);
                    break;
                case "Record Goal":

                    List<Goal> goals = saveInstance.GetGoals();
                    int goalOption = -1;

                    do
                    {
                        Console.WriteLine("Your options are: ");
                        for (int i = 0; i < goals.Count(); i++)
                        {
                            Console.WriteLine($"{i}. {goals[i].GetName()}, {goals[i].GetTypename()}");
                        }
                        goalOption = Inputs.InputInt("\nEnter your option: ");

                        if (goalOption < 0 || goalOption >= goals.Count())
                        {
                            Console.WriteLine("That was not an option.");
                            Thread.Sleep(2000);
                        }
                    } while (goalOption < 0 || goalOption >= goals.Count());
                    Console.Clear();

                    Goal chosenGoal = goals[goalOption];

                    int awardedPoints = chosenGoal.Record();
                    Console.WriteLine($"You have been awarded {awardedPoints} points.");
                    
                    string priorLevel = Levels.GetLevel(saveInstance.GetPoints());
                    saveInstance.AddPoints(awardedPoints);
                    string newLevel = Levels.GetLevel(saveInstance.GetPoints());

                    if (priorLevel != newLevel)
                    {
                        if (awardedPoints > 0)
                            Console.WriteLine("You Leveled Up");
                        else
                            Console.WriteLine("You Leveled Down, Great Job!");
                    }
                    Inputs.InputStr("Enter anything to continue: ");

                    break;
                case "Clear Goals":
                    // removes goals and removes point value from point score because yes
                    int deletedPoints = 0;

                    foreach (Goal goal in saveInstance.GetGoals())
                    {
                        deletedPoints += Math.Abs(goal.GetPoints()); // does not matter if completed, this program is not meant to be nice (:<
                    }
                    saveInstance.AddPoints(-deletedPoints);
                    saveInstance.ClearGoals();

                    Console.WriteLine($"The goals you have erased are worth {deletedPoints} points, so you owe that much.");
                    Console.WriteLine($"{deletedPoints} points have been removed.");
                    Inputs.InputStr("Enter anything to continue: ");

                    break;
                case "Load":
                    saveInstance.LoadFromJson();
                    break;
                case "Save":
                    saveInstance.SaveToJson();
                    break;
                case "Stop Being Mean To Me":
                    Console.WriteLine("No");
                    Thread.Sleep(1000);
                    saveInstance.SetPoints(-1);
                    break;
                case "I'm A Loser":
                    Console.WriteLine("So, you admit to being a loser.");
                    saveInstance.SetPoints(Inputs.InputInt("How many points do you want to have, loser."));
                    break;
                default:
                    Console.WriteLine("I'm not mad, just disappointed.");
                    Thread.Sleep(1000);
                    quit = true;
                    break;
            }


        } while(!quit);

        // saveInstance.SaveToJson(); // happy now
    }
}