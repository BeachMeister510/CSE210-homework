using System.Transactions;

public class ListeningActivity : Activity
{
    Random rand = new Random();
    List<string> listenPrompts = new List<string>
        {
            "List a few good things that happened today.",
            "List a few challenges you faced today and how you handled them.",
            "List a few things you would do differently if you could relive today.",
            "List a few moments from today that you are most grateful for.",
            "List a few things you learned today—about yourself or the world.",
            "List a few emotions you felt today and what influenced them.",
            "List a few moments that brought you stress or frustration and how you coped.",
            "List a few things that made you smile or laugh today.",
            "List a few words that describe your mood today.",
            "List a few worries you had today—do they still feel as important now?",
            "List a few accomplishments you had today, no matter how small.",
            "List a few ways you made progress toward a personal goal today.",
            "List a few habits or skills you improved on today.",
            "List a few things you procrastinated on and why.",
            "List a few ways you challenged yourself today.",
            "List a few people you interacted with today and how those interactions made you feel.",
            "List a few ways you helped or supported someone today.",
            "List a few moments where you could have communicated better.",
            "List a few compliments or kind words you gave (or received) today.",
            "List a few people you are grateful for today and why.",
            "List a few ways you took care of yourself today.",
            "List a few things you did for enjoyment today.",
            "List a few ways you de-stressed today.",
            "List a few ways you listened to your body's needs (food, rest, movement, etc.).",
            "List a few things you can do to take better care of yourself tomorrow."
        };
    public ListeningActivity()
    {
        _name = "Listening Activity";
        _description = "Durring the listening activty you will be asked to write a few different responses to a prompt.";
        _activityLength = 30;
    }
    public ListeningActivity(int length)
    {
        _name = "Listening Activity";
        _description = "Durring the listening activty you will be asked to write a few different responses to a prompt.";
        _activityLength = length;
    }

    public void Listen()
    {
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_activityLength);
        DateTime current = DateTime.Now;

        Console.Clear();
        int Index = rand.Next(0, listenPrompts.Count());

        Console.WriteLine("Consider the following prompt");
        Console.WriteLine($"-- {listenPrompts[Index]} --");
        Console.WriteLine("Write as many responses as you can");

        while (end > current)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadLine();
            }
            current = DateTime.Now;
        }

        Console.WriteLine("Time is up!");
        Thread.Sleep(2000);
        Console.Clear();
    }
}