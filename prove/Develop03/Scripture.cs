using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference Reference { get; }
    private List<Word> Words { get; }
    private Random random;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
        random = new Random();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", Words));
    }

    public bool HideRandomWord()
    {
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0)
        {
            return false;
        }

        var wordToHide = visibleWords[random.Next(visibleWords.Count)];
        wordToHide.Hide();
        return true;
    }
}
