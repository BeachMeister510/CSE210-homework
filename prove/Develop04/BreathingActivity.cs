using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.Marshalling;

public class BreathingActivity : Activity
{

    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _delay = 5;
        _activityLength = 30;
        _description = "Durring the breathing activity you will do a series of deep breathes. You will be asked to breathe in until the breathe out phase starts. This process repeats till the activity duration is reached.";
    }
    public BreathingActivity(int length)
    {
        _name = "Breathing Activity";
        _activityLength = length;
        _description = "Durring the breathing activity you will do a series of deep breathes. You will be asked to breathe in until the breathe out phase starts. This process repeats till the activity duration is reached.";

        if (length % 3 == 0)
        {
            _delay = 3;
        }
        else if (length % 4 == 0)
        {
            _delay = 4;
        }
        else if (length % 5 == 0)
        {
            _delay = 5;
        }
        else if (length % 7 == 0)
        {
            _delay = 7;
        }
        else if (length % 9 == 0)
        {
            _delay = 9;
        }
    }

    public BreathingActivity(int length, int delay)
    {
        _name = "Breathing Activity";
        _delay = delay;
        _activityLength = length;
        _description = "Durring the breathing activity you will do a series of deep breathes. You will be asked to breathe in until the breathe out phase starts. This process repeats till the activity duration is reached.";
    }
    public void Breathe()
    {
        int repeat = _activityLength / _delay;
        Console.Clear();
        while (repeat != 0)
        {
            repeat--;
            BreatheIn();
            BreatheOut();
        }
        Console.Clear();
    }
    public void BreatheIn()
    {
        int miliSecDelay = _delay * 100;
        bool breathIn = true;
        string aniString = "----------------------";
        int count = 0;
        List<char> stringParts = new List<char>(aniString);

        Console.Clear();
        Console.WriteLine("Breathe in");
        while (breathIn)
        {
            stringParts[count] = char.Parse("O");
            Console.Write("\r" + string.Concat(stringParts));
            count++;
            Thread.Sleep(miliSecDelay);
            if (count == stringParts.Count())
            {
                breathIn = false;
            }
        }
    }
    public void BreatheOut()
    {
        int miliSecDelay = _delay * 100;
        bool breathIn = true;
        string aniString = "OOOOOOOOOOOOOOOOOOOOOO";
        List<char> stringParts = new List<char>(aniString);
        int count = stringParts.Count();

        Console.Clear();
        Console.WriteLine("Breathe out");
        while (breathIn)
        {
            stringParts[count - 1] = char.Parse("-");

            Console.Write("\r" + string.Concat(stringParts));
            count--;
            Thread.Sleep(miliSecDelay);
            if (count == 0)
            {
                breathIn = false;
            }
        }
    }
}