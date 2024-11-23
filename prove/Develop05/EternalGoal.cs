class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordProgress()
    {
        
    }

    public override string GetProgress()
    {
        return $"{Name} ({Description}) - Eternal Goal";
    }
}
