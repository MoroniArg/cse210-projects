using System;
using System.Threading.Tasks;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity helps you relax by guiding you through slow breathing. Focus on your breath and follow the countdown.")
    {
    }

    public override async Task RunAsync()
    {
        await StartAsync();
        int remainingTime = Duration;

        while (remainingTime > 0)
        {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            await CountdownAsync(4);  
            remainingTime -= 4;
            if (remainingTime <= 0) break;

            Console.Clear();
            Console.WriteLine("Hold your breath...");
            await CountdownAsync(3);
            remainingTime -= 3;

            if (remainingTime <= 0) break;


            Console.Clear();
            Console.WriteLine("Breathe out...");
            await CountdownAsync(4);
            remainingTime -= 4;

            Console.Clear();
            Console.WriteLine("Hold...");
            await CountdownAsync(3);
            remainingTime -= 3;
        }

        await EndAsync();
    }

    private async Task CountdownAsync(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} seconds remaining...");
            await Task.Delay(1000);
        }
        Console.WriteLine();
    }
}
