using System.Text.Json.Nodes;

public abstract class QuantityGoal : Goal
{
    protected int _completions;
    protected int _bonusPoints;
    protected int _bonusCompletions;

    public QuantityGoal() : base() {}
    public QuantityGoal(string name, string description, int points, int bonusPoints, int bonusCompletions, int completions = 0) : base(name,description,points)
    {
        _bonusPoints = bonusPoints;
        _bonusCompletions = bonusCompletions;
        _completions = completions;
    }
    // public override void SetupTypeName(){_typeName = "invalid";}

    
    // class attribute getters and setter
    public override void CreateGoal()
    {
        base.CreateGoal();
        _bonusCompletions = Inputs.InputInt("How many completions should it take to get bonus points: ");
        _bonusPoints = Inputs.InputInt("What is the bonus point value: ");
    }

    // returns JsonObject using class attributes
    public override JsonObject ExportAttributesAsJsonObject()
    {
        JsonObject jsonObject = base.ExportAttributesAsJsonObject();

        jsonObject.Add("completions",JsonValue.Create(_completions));
        jsonObject.Add("bonusPoints",JsonValue.Create(_bonusPoints));
        jsonObject.Add("bonusCompletions",JsonValue.Create(_bonusCompletions));

        return jsonObject;
    }

    // sets class attributes using JsonObject
    public override void ImportAttributesAsJsonObject(JsonObject jsonObject)
    {
        base.ImportAttributesAsJsonObject(jsonObject);

        JsonNode completionsJsonN;
        JsonNode bonusPointsJsonN;
        JsonNode bonusCompletionsJsonN;
        
        // sets default values
        _completions = 0;
        _bonusPoints = 0;
        _bonusCompletions = 5;

        // sets values from json


        if (jsonObject.TryGetPropertyValue("completions",out completionsJsonN))
            if (completionsJsonN is JsonValue)
                (completionsJsonN as JsonValue).TryGetValue<int>(out _completions);
        if (jsonObject.TryGetPropertyValue("bonusPoints",out bonusPointsJsonN))
            if (bonusPointsJsonN is JsonValue)
                (bonusPointsJsonN as JsonValue).TryGetValue<int>(out _bonusPoints);
        if (jsonObject.TryGetPropertyValue("bonusCompletions",out bonusCompletionsJsonN))
            if (bonusCompletionsJsonN is JsonValue)
                (bonusCompletionsJsonN as JsonValue).TryGetValue<int>(out _bonusCompletions);
    }

    // returns goal details
    public override string GetDetails()
    {
        return base.GetDetails() + $"\nBonus Points: {_bonusPoints}\nCompletions for Bonus: {_bonusCompletions}\nCompletions: {_completions}";
    }

    // records completion of goal
    public override int Record(object checklist = null)
    {
        _completions++;
        if (_completions % _bonusCompletions != 0)
        {
            return _points;
        }
        else
        {
            Console.WriteLine($"{_bonusPoints} bonus points awarded.");
            return _points + _bonusPoints;
        }
    }
}