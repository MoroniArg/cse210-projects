using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("""
            Journal Menu:
            1. Write a new entry
            2. Display journal
            3. Save journal to file
            4. Load journal from file
            5. Exit

            """);
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    // Display the prompt before asking for the response
                    string prompt = journal.GetRandomPrompt(); // Get a random prompt
                    Console.WriteLine($"Prompt: {prompt}"); // Display the prompt
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(response, prompt); // Pass the prompt to AddEntry
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
