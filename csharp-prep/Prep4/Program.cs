using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> Numbers = new List<int>();
        int Entry = -1;
        Console.WriteLine("Enter a list of numbers one by one, type 0 when finished.");
        do
        {
            Console.Write("Enter a number: ");
            Entry = int.Parse(Console.ReadLine());
            Numbers.Add(Entry);
        } while (Entry != 0);

        int Sum = 0;
        int LargeNum = 0;
        foreach (int Number in Numbers)
        {
            Sum += Number;
            if (LargeNum < Number)
            {
                LargeNum = Number;
            }
        }
        int Avg = Sum / Numbers.Count;

        Console.WriteLine($"The sum is {Sum}.");
        Console.WriteLine($"The average is {Avg}.");
        Console.WriteLine($"The largest number is {LargeNum}.");
    }
}