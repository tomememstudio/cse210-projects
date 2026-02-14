class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override int RecordEvent() => _points;

    public override string GetSaveString()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}