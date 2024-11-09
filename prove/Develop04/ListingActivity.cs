using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };

    public ListingActivity() 
        : base("Listing Activity", "This activity helps you reflect on the good things in your life.")
    {
    }

    public override async Task RunAsync()
    {
        await StartAsync();
        Console.Clear();
        Console.WriteLine(GetRandomPrompt());
        await PauseAsync(3);

        List<string> items = new List<string>();
        var startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write(">>> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
                items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items.");
        await EndAsync();
    }

    private string GetRandomPrompt()
    {
        return Prompts[new Random().Next(Prompts.Length)];
    }
}
