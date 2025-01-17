using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber = new Random();
        int Number = randomNumber.Next(1, 101);
        int Guess = -1;
        int GuessNumber = 0;

        do
        {
            GuessNumber++;
            Console.WriteLine("What is your guess?");
            Guess = int.Parse(Console.ReadLine());
            if (Guess < Number)
            {
                Console.WriteLine("The magic number is higher.");
            }
            else if (Guess > Number)
            {
                Console.WriteLine("The magic number is lower.");
            }
        } while (Number != Guess);

        Console.WriteLine($"You guessed it! It took you {GuessNumber} Guesses.");
    }
}