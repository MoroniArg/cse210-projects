using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("William Rippetoe", "Scales");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Brianna Riconcillo", "Multiplications", "6", "1-3");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Catarino Manqueros", "US History", "The Civil War");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}