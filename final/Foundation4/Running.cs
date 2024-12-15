public class Running : Activity
{
    private double distance;
    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60; 
    }

    public override double GetPace()
    {
        return (Duration / GetDistance()); 
    }

    public override string GetActivityType()
    {
        return "Running";
    }
}