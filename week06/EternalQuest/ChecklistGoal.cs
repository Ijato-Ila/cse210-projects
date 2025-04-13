public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _amountCompleted;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _targetCount)
        {
            _amountCompleted++;
        }

        if (_amountCompleted == _targetCount)
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetCount;
    }

    public override string GetStatus()
    {
        string check = IsComplete() ? "X" : " ";
        return $"[{check}] {Name} ({Description}) -- Completed {_amountCompleted}/{_targetCount}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_amountCompleted}";
    }

    public static ChecklistGoal Deserialize(string[] parts)
    {
        var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
        goal._amountCompleted = int.Parse(parts[6]);
        return goal;
    }
}
