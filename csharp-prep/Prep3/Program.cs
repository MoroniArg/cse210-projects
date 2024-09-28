using System;

class Program
{
    static void Main(string[] args)
    {
        int userGuess = -1;
        Random RandomGenerator = new Random();
        int MagicNumber = RandomGenerator.Next(0,100);

        while (MagicNumber != userGuess)
        {
            Console.Write("What is your guess? ");
            userGuess = int.Parse(Console.ReadLine());
            

            if (userGuess < MagicNumber)
            {
                Console.WriteLine("Higher");
            }

            else if (userGuess > MagicNumber)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

    }
}