using System.ComponentModel.DataAnnotations;

public abstract class Event
{
    string _eventName;
    string _eventDescription;

    public virtual void Display()
    {
        Console.WriteLine("You have triggered an Event!");
        Console.WriteLine($"Event Name: {_eventName}");
        Console.WriteLine(_eventDescription);
    }

    public abstract bool CheckEventFinished();

    public Event(string name, string desc)
    {
        _eventName = name;
        _eventDescription = desc;
    }

    public Event()
    {
        _eventName = "Unkown Event";
        _eventDescription = "No description";
    }
}