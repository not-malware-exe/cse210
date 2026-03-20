using System.Text.Json.Nodes;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected string _typeName;

    public Goal()
    {
        SetupTypeName();
    }
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        SetupTypeName();
    }
    public virtual void SetupTypeName(){_typeName = "invalid";}

    
    // class attribute getters and setter
    public string GetName() {return _name;}
    public string GetDescription() {return _description;}
    public int GetPoints() {return _points;}
    public string GetTypename() {return _typeName;}
    public virtual void CreateGoal()
    {
        _name = Inputs.InputStr("What is the name of your new goal: ");
        _description = Inputs.InputStr("Provide a description for your goal: ");
        _points = Inputs.InputInt("What is the point value of completing the goal: ");
    }

    // returns JsonObject using class attributes
    public virtual JsonObject ExportAttributesAsJsonObject()
    {
        JsonObject jsonObject = new JsonObject();

        jsonObject.Add("name",JsonValue.Create(_name));
        jsonObject.Add("description",JsonValue.Create(_description));
        jsonObject.Add("points",JsonValue.Create(_points));

        return jsonObject;
    }

    // sets class attributes using JsonObject
    public virtual void ImportAttributesAsJsonObject(JsonObject jsonObject)
    {
        JsonNode nameJsonN;
        JsonNode descriptionJsonN;
        JsonNode pointsJsonN;

        // sets default values
        _name = "???";
        _description = "???";
        _points = 0;

        // sets values from json
        if (jsonObject.TryGetPropertyValue("name",out nameJsonN))
            if (nameJsonN is JsonValue)
                (nameJsonN as JsonValue).TryGetValue<string>(out _name);
        
        if (jsonObject.TryGetPropertyValue("description",out descriptionJsonN))
            if (descriptionJsonN is JsonValue)
                (descriptionJsonN as JsonValue).TryGetValue<string>(out _description);

        if (jsonObject.TryGetPropertyValue("points",out pointsJsonN))
            if (pointsJsonN is JsonValue)
                (pointsJsonN as JsonValue).TryGetValue<int>(out _points);
    }

    // returns goal details
    public virtual string GetDetails()
    {
        return $"Goal: {_name}\nDescription: {_description}\nPoint Value: {_points}";
    }

    // records completion of goal
    public virtual int Record(object checklist = null)
    {
        return _points;
    }
}