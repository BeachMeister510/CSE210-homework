
using System.Formats.Asn1;

public class Activity
{
    protected string _name;
    protected int _activityLength;
    protected int _delay;
    protected string _description;



    public Activity()
    {
        _name = "Unknown Activity";
        _activityLength = 0;
        _delay = 0;
        _description = "No Description";
    }

    public void ActivityStart()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Thread.Sleep(5000);
    }

    public void ActivityEnd()
    {
        Console.WriteLine($"You have comepleted {_activityLength} seconds of the {_name}");
    }

    public void DisplayDescription()
    {
        Console.WriteLine(_description);
    }

    public int GetLength()
    {
        return _activityLength;
    }

    public int GetDelay()
    {
        return _delay;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetName(string name)
    {
        _name = name;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public void SetLength(int length)
    {
        _activityLength = length;
    }
}