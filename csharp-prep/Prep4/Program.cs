using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userInput = -1;
        
        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());

            if (userInput != 0)
            {
                numbers.Add(userInput);
            }

        }

        //Finding the Sum Total of the numbers that have been put into the list

        int sumList = 0;

        foreach (int number in numbers)
        {
            sumList += number;
        }

        Console.Write("The Sum is: ");
        Console.WriteLine(sumList);

        //Finding the Average of the numbers that have been put into the list
        
        Console.Write("The Average is: ");
        Console.WriteLine(sumList / numbers.Count);
        
        //Finding the Largest number from the list

        int largestNumber = 0;

        foreach (int number in numbers)
        {
            if (number > largestNumber)
            {
                largestNumber = number;
            }
        }

        Console.Write("The largest number is: ");
        Console.WriteLine(largestNumber);
    }
}