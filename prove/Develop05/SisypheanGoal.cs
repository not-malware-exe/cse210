using System.Text.Json.Nodes;

public class SisypheanGoal : QuantityGoal
{

    public SisypheanGoal() : base() {}
    public SisypheanGoal(string name, string description, int points, int bonusPoints, int bonusCompletions, int completions = 0) : base(name,description,points,bonusPoints,bonusCompletions,completions){}
    public override void SetupTypeName(){_typeName = "SisypheanGoal";}

    
    // class attribute getters and setter
    public override void CreateGoal()
    {
        base.CreateGoal();
    }

    // returns JsonObject using class attributes
    public override JsonObject ExportAttributesAsJsonObject()
    {
        JsonObject jsonObject = base.ExportAttributesAsJsonObject();

        return jsonObject;
    }

    // sets class attributes using JsonObject
    public override void ImportAttributesAsJsonObject(JsonObject jsonObject)
    {
        base.ImportAttributesAsJsonObject(jsonObject);
    }

    // returns goal details
    public override string GetDetails()
    {
        return base.GetDetails();
    }

    // records completion of goal
    public override int Record(object checklist = null)
    {
        return base.Record(checklist);
    }
}