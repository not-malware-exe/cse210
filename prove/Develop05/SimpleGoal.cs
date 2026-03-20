using System.Text.Json.Nodes;

public class SimpleGoal : Goal
{
    protected bool _completed = false;
    public SimpleGoal() : base() {}
    public SimpleGoal(string name, string description, int points, bool completed = false) : base(name,description,points)
    {
        _completed = completed;
    }
    public override void SetupTypeName(){_typeName = "SimpleGoal";}

    
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
            return -_points;
        }
        _completed = true;
        return _points;
    }
}