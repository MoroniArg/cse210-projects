using System;
using System.Threading.Tasks;

public class ReflectionActivity : Activity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How can you apply this experience in the future?",
        "What made this time different than other times when you were not as successful?",
        "How did you feel when it was complete?",
        "What is your favorite thing about this experience?",
        "How can you keep this experience in mind in the future?",
        "What could you learn from this experience that applies to other situations?"
    };

    public ReflectionActivity() 
        : base("Reflection Activity", "This activity helps you reflect on moments of strength and resilience. Take time to think deeply.")
    {
    }

    public override async Task RunAsync()
    {
        await StartAsync();

        Console.Clear();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine("\nPress Enter when you're ready to continue...");
        Console.ReadLine();

        int remainingTime = Duration;

        while (remainingTime > 0)
        {
            Console.Clear();
            Console.WriteLine(GetRandomQuestion());
            await PauseAsync(5);
            remainingTime -= 5;
        }

        await EndAsync();
    }

    private string GetRandomPrompt()
    {
        return Prompts[new Random().Next(Prompts.Length)];
    }

    private string GetRandomQuestion()
    {
        return Questions[new Random().Next(Questions.Length)];
    }
}
