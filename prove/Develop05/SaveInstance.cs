using System.Text.Json;
using System.Text.Json.Nodes;

public class SaveInstance
{
    private List<Goal> _goals = [];
    private string _jsonPath;
    private int _points;
    private int _pointDeductionDailyRate;

    public SaveInstance(string jsonPath, int pointDeductionDailyRate)
    {
        _jsonPath = jsonPath;
        _pointDeductionDailyRate = pointDeductionDailyRate;
    }
    
    public void LoadFromJson()
    {
        if (!File.Exists(_jsonPath))
        {
            return;
        }

        // gets json as string
        string jsonStr = "";
        using (StreamReader reader = new StreamReader(_jsonPath))
            jsonStr = reader.ReadToEnd();

        // converts json string to JsonObject
        JsonObject jsonObject = JsonNode.Parse(jsonStr) as JsonObject;

        JsonNode pointsJsonN;
        JsonNode dateJsonN;
        JsonNode goalsJsonN;

        // sets default values
        _points = 0;
        _pointDeductionDailyRate = 100;

        // sets values from json
        // gets points
        if (jsonObject.TryGetPropertyValue("points",out pointsJsonN))
            if (pointsJsonN is JsonValue)
                (pointsJsonN as JsonValue).TryGetValue<int>(out _points);

        // gets previous date
        if (jsonObject.TryGetPropertyValue("date",out dateJsonN))
            if (dateJsonN is JsonValue)
            {
                DateTime prevDate = new DateTime();
                (dateJsonN as JsonValue).TryGetValue<DateTime>(out prevDate);
                DeductDailyPoints(prevDate,DateTime.Now); // deducts daily points (:<
            }
                
        // gets goals
        if (jsonObject.TryGetPropertyValue("goals",out goalsJsonN))
            if (goalsJsonN is JsonObject)
                LoadGoals(goalsJsonN as JsonObject);
            
    }
    public void SaveToJson()
    {
        JsonObject jsonObject = new JsonObject();

        jsonObject.Add("points",JsonValue.Create(_points));
        jsonObject.Add("date",JsonValue.Create(DateTime.Now));
        jsonObject.Add("goals",SaveGoals());

        // overwrites save json with jsonStr
        string jsonStr = jsonObject.ToJsonString();
        using (StreamWriter writer = new StreamWriter(_jsonPath,false))
            writer.Write(jsonStr);
    }

    public void LoadGoals(JsonObject goalsJsonObject)
    {
        foreach ((string typeName,JsonNode typeGoalsJsonNode) in goalsJsonObject) // gets typeName and list of goal data
        {
            if (typeGoalsJsonNode is JsonArray)
            {
                foreach (JsonNode goalJsonNode in typeGoalsJsonNode as JsonArray) // gets goals from list of goal data
                {
                    Goal newGoal;

                    switch (typeName) {
                        case "SimpleGoal": newGoal = new SimpleGoal(); break;
                        case "SisypheanGoal": newGoal = new SisypheanGoal(); break;
                        case "QuestGoal": newGoal = new QuestGoal(); break;
                        default: continue;
                    }

                    if (goalJsonNode is JsonObject) {
                        newGoal.ImportAttributesAsJsonObject(goalJsonNode as JsonObject);
                        _goals.Add(newGoal);
                    }
                }
            }
        }
    }
    public JsonObject SaveGoals()
    {
        JsonObject jsonObject = new JsonObject();

        jsonObject.Add("SimpleGoal",new JsonArray());
        jsonObject.Add("SisypheanGoal",new JsonArray());
        jsonObject.Add("QuestGoal",new JsonArray());

        foreach (Goal goal in _goals)
        {
            JsonNode goalsJsonN;

            if (jsonObject.TryGetPropertyValue(goal.GetTypename(),out goalsJsonN))
                if (goalsJsonN is JsonArray)
                    (goalsJsonN as JsonArray).Add(goal.ExportAttributesAsJsonObject());
        }

        return jsonObject;
    }

    public List<Goal> GetGoals() {return _goals;}
    public void ClearGoals() {_goals = [];}
    public int GetPoints() {return _points;}
    public void SetPoints(int points) {_points = points;}
    public void AddPoints(int points) {_points += points;}

    public void DeductDailyPoints(DateTime lastDate, DateTime currentDate)
    {
        float differenceInDays = (float)(currentDate - lastDate).TotalDays;
        int deductedPoints = _pointDeductionDailyRate * (int)differenceInDays;

        Console.WriteLine($"It has been {differenceInDays} days, you lost {deductedPoints} points.");
        Thread.Sleep(5000);

        // _points = Math.Max(_points - deductedPoints,0);
        _points -= deductedPoints; // actually having negative points is much funnier
    }

    public Goal CreateGoal(string typeName)
    {
        switch (typeName)
        {
            case "SimpleGoal":
                return CreateGoal<SimpleGoal>();
            case "SisypheanGoal":
                return CreateGoal<SisypheanGoal>();
            case "QuestGoal":
                return CreateGoal<QuestGoal>();
            default:
                return null;
        }
    }
    public Goal CreateGoal<GoalType>() where GoalType : Goal, new()
    {
        GoalType newGoal = new GoalType();
        newGoal.CreateGoal();
        _goals.Add(newGoal);
        return newGoal;
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetails());
            Console.WriteLine("");
        }
    }
}