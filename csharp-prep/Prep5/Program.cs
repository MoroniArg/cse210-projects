using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userSquared = SquareNumber(userNumber);
        DisplayResult(userName, userSquared);
    }
        
    static void DisplayWelcome()
    {
        //No return
        //No integers         
            
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        //Return the user's name
        //No integers

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        //Return the user's favorite number
        //No integers

        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        //Return Number squared
        //An integer number

        int squared = number * number;

        return squared;

    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}