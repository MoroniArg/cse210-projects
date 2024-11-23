using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Total Score: {totalScore}");
            Console.WriteLine($"Current Level: {GetLevel(totalScore)}\n");

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save progress");
            Console.WriteLine("5. Load progress");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ShowGoals();
                    break;
                case 4:
                    SaveProgress();
                    break;
                case 5:
                    LoadProgress();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nChoose goal type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.Write(">>>");
        int type = int.Parse(Console.ReadLine());
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completion: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine("\nSelect a goal to record progress:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetProgress()}");
        }

        Console.Write("Enter the goal number: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice > 0 && choice <= goals.Count)
        {
            goals[choice - 1].RecordProgress();
            totalScore += goals[choice - 1].Points;

            if (goals[choice - 1] is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                totalScore += checklistGoal.BonusPoints;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }

    static void ShowGoals()
    {
        Console.WriteLine("\nGoals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetProgress());
        }
    }

    static void SaveProgress()
    {
        Console.Write("Enter file name to save progress (e.g., user1.txt): ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(totalScore);

            foreach (var goal in goals)
            {
                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine($"Simple|{simpleGoal.Name}|{simpleGoal.Description}|{simpleGoal.Points}|{simpleGoal.IsComplete()}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine($"Eternal|{eternalGoal.Name}|{eternalGoal.Description}|{eternalGoal.Points}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"Checklist|{checklistGoal.Name}|{checklistGoal.Description}|{checklistGoal.Points}|{checklistGoal.BonusPoints}|{checklistGoal.TargetCount}|{checklistGoal.CurrentCount}");
                }
            }
        }

        Console.WriteLine("Progress saved.");
    }

    static void LoadProgress()
    {
        Console.Write("Enter file name to load progress (e.g., user1.txt): ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        goals.Clear();

        using (StreamReader reader = new StreamReader(fileName))
        {
            totalScore = int.Parse(reader.ReadLine());

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                if (type == "Simple")
                {
                    bool completed = bool.Parse(parts[4]);
                    var simpleGoal = new SimpleGoal(name, description, points);
                    if (completed) simpleGoal.MarkComplete();
                    goals.Add(simpleGoal);
                }
                else if (type == "Eternal")
                {
                    goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "Checklist")
                {
                    int bonusPoints = int.Parse(parts[4]);
                    int targetCount = int.Parse(parts[5]);
                    int currentCount = int.Parse(parts[6]);
                    var checklistGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                    while (currentCount-- > 0)
                    {
                        checklistGoal.RecordProgress();
                    }
                    goals.Add(checklistGoal);
                }
            }
        }

        Console.WriteLine("Progress loaded.");
    }

    static int GetLevel(int score)
    {
        int[] levelThresholds = { 0, 100, 250, 500, 1000, 2000, 3000 };
        for (int i = levelThresholds.Length - 1; i >= 0; i--)
        {
            if (score >= levelThresholds[i])
            {
                return i + 1;
            }
        }
        return 1;
    }
}
