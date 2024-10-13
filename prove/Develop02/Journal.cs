using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private readonly List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today that I didn’t know before?",
            "What challenge did I face today, and how did I handle it?",
            "What made me smile today?",
            "How did I show kindness to someone today?",
            "What goals do I want to achieve in the next month?",
            "What am I grateful for today?",
            "Who in my life am I most thankful for, and why?",
            "What small things brought me joy today?",
            "How did I make a positive impact on someone else today?",
            "What is something I often take for granted that I appreciate today?",
            "What do I want to accomplish this week?",
            "If I could visit anywhere in the world, where would I go and why?",
            "What do I want my life to look like in five years?",
            "What is one skill I would like to learn or improve?",
            "If I could give my younger self one piece of advice, what would it be?",
            "What was the most challenging emotion I felt today, and what caused it?",
            "How do I feel about my current situation in life?",
            "When did I feel most at peace today?",
            "What is something that stressed me out today, and how can I manage it better?",
            "What did I do to practice self-care today?"
        };
    }

    public void AddEntry(string response, string prompt)
{
    string date = DateTime.Now.ToString("yyyy-MM-dd");
    Entry newEntry = new Entry(prompt, response, date);
    _entries.Add(newEntry);
}


    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    _entries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }
        }
    }
}
