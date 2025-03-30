public abstract class Goal
{
    protected string _goalName;
    protected string _goalDescription;
    protected int _points;
    protected bool _done;

    public abstract string[] SaveGoal();
    public virtual void Display()
    {
        if (_done)
        {
            Console.WriteLine($"[X] {_goalName} - {_goalDescription} ({_points} Points)");
        }
        else
        {
            Console.WriteLine($"[ ] {_goalName} - {_goalDescription} ({_points} Points)");
        }
    }
    public virtual string ReturnGoal()
    {
        if (_done)
        {
            return $"[X] {_goalName} - {_goalDescription} ({_points} Points)";
        }
        else
        {
            return $"[ ] {_goalName} - {_goalDescription} ({_points} Points)";
        }
    }
    public virtual int FinishGoal()
    {
        if (!_done)
        {
            _done = true;
            return _points;
        }
        else
        {
            Console.WriteLine("You have already completed this goal");
            return 0;
        }

    }
    public Goal(string name, string desc, int points)
    {
        _goalName = name;
        _goalDescription = desc;
        _points = points;
        _done = false;
    }

    public Goal(string name, string desc, int points, bool done)
    {
        _goalName = name;
        _goalDescription = desc;
        _points = points;
        _done = done;
    }
}