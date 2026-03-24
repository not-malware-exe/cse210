using System.Text.Json.Nodes;

public class ChecklistGoal : QuantityGoal
{
    private bool _completed = false;

    public ChecklistGoal() : base() {}
    public ChecklistGoal(string name, string description, int points, int bonusPoints, int bonusCompletions, int completions = 0, bool completed = false) : base(name, description, points, bonusPoints, bonusCompletions, completions)
    {
        _completed = completed;
    }
    public override void SetupTypeName(){_typeName = "ChecklistGoal";}

    // class attribute getters and setter
    public override void CreateGoal()
    {
        base.CreateGoal();
    }

    // returns JsonObject using class attributes
    public override JsonObject ExportAttributesAsJsonObject()
    {
        JsonObject jsonObject = base.ExportAttributesAsJsonObject();
        
        jsonObject.Add("completed",JsonValue.Create(_completed));

        return jsonObject;
    }

    // sets class attributes using JsonObject
    public override void ImportAttributesAsJsonObject(JsonObject jsonObject)
    {
        base.ImportAttributesAsJsonObject(jsonObject);

        JsonNode completedJsonN;
        
        // sets default values
        _completed = false;

        // sets values from json

        if (jsonObject.TryGetPropertyValue("completed",out completedJsonN))
            if (completedJsonN is JsonValue)
                (completedJsonN as JsonValue).TryGetValue<bool>(out _completed);
    }

    // returns goal details
    public override string GetDetails()
    {
        return base.GetDetails() + $"\nCompleted: {_completed}";
    }

    // records completion of goal
    public override int Record(object checklist = null)
    {
        if (_completed)
        {
            Console.WriteLine("No Cheating!");
            return -base.Record(checklist);
        }

        int points = base.Record(checklist);

        if (_completions == _bonusCompletions)
             _completed = true;

        return points;
    }
}