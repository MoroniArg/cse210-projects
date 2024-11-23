class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override void RecordProgress()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
        }
    }

    public override string GetProgress()
    {
        return $"{Name} ({Description}) - {CurrentCount}/{TargetCount} completed";
    }

    public bool IsComplete()
    {
        return CurrentCount >= TargetCount;
    }
}
