class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string desc, int points, bool complete = false)
        : base(name, desc, points)
    {
        _isComplete = complete;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;
        _isComplete = true;
        return _points;
    }
    public override string GetDetailsString()
    {
        string box = _isComplete ? "[X]" : "[ ]";
        return $"{box} {_name} ({_description})";
    }

    public override string GetSaveString()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
    }
}