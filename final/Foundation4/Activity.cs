using System;

public abstract class Activity
{
    private DateTime date;
    private int duration; 

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public int Duration
    {
        get { return duration; }
        set { duration = value; }
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {GetActivityType()} ({Duration} min): Distance {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }

    public abstract string GetActivityType();
}
