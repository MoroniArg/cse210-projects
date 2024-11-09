using System;
using System.Threading.Tasks;

public abstract class Activity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Duration { get; private set; }

    protected Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public async Task StartAsync()
    {
        Console.Clear();
        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine(Description);
        Console.Write("Enter the duration in seconds: ");
        Duration = int.TryParse(Console.ReadLine(), out int duration) && duration > 0 ? duration : 10;
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    public async Task EndAsync()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You have completed the {Name} for {Duration} seconds.");
        await PauseAsync(3);
    }

    protected async Task PauseAsync(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rPausing: {new string('.', seconds - i + 1)}");
            await Task.Delay(1000);
        }
        Console.WriteLine();
    }

    public abstract Task RunAsync();
}
