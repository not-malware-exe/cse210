using System.Text.Json.Nodes;

public class EternalGoal : Goal
{
    public EternalGoal() : base() {}
    public EternalGoal(string name, string description, int points) : base(name,description,points) {}
    public override void SetupTypeName(){_typeName = "EternalGoal";}

    
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