class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordProgress()
    {
        _isComplete = true;
    }

    public override string GetProgress()
    {
        return $"{Name} ({Description}) - {(_isComplete ? "Completed" : "Incomplete")}";
    }

    public bool IsComplete()
    {
        return _isComplete;
    }

    public void MarkComplete()
    {
        _isComplete = true;
    }
}
