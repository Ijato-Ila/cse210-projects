public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"You earned {Points} points for progressing on: {Name}");
        return Points;
    }

    public override bool IsComplete()
    {
        return false; // never complete
    }

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description})";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }

    public static EternalGoal Deserialize(string[] parts)
    {
        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
    }
}
