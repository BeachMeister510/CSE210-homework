using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade out of 100?");
        string StringGrade = Console.ReadLine();
        int Grade = int.Parse(StringGrade);

        if (Grade < 60)
        {
            Console.WriteLine("You got an F.");
        }
        else if (Grade < 70 && Grade >= 60)
        {
            Console.WriteLine("You got a D.");
        }
        else if (Grade < 80 && Grade >= 70)
        {
            Console.WriteLine("You got a C.");
        }
        else if (Grade < 90 && Grade >= 80)
        {
            Console.WriteLine("You got a B!");
        }
        else
        {
            Console.WriteLine("You got an A!");
        }
    }
}