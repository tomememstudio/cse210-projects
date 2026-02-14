class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _count;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int count = 0)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _count = count;
    }

    public override int RecordEvent()
    {
        if (_count >= _target) return 0;

        _count++;
        if (_count == _target) return _points + _bonus;
        return _points;
    }

    public override string GetDetailsString()
    {
        string box = _count >= _target ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description}) -- Completed {_count}/{_target}";
    }

    public override string GetSaveString()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_count}";
    }
}