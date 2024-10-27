using System;

public class Reference
{
    public string Book { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int verse)
    {
        Book = book;
        StartVerse = verse;
        EndVerse = verse;
    }

    public Reference(string book, int startVerse, int endVerse)
    {
        Book = book;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse > StartVerse ? $"{Book} {StartVerse}-{EndVerse}" : $"{Book} {StartVerse}";
    }
}
