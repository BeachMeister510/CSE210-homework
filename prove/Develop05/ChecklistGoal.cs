public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _numberToComplete;
    private int _bonusPoints;
    public override int FinishGoal()
    {
        if (_timesCompleted < _numberToComplete - 1)
        {
            _timesCompleted++;
            return _points;
        }
        else if (_timesCompleted == _numberToComplete)
        {
            _timesCompleted++;
            AddBonus();
            return base.FinishGoal();
        }
        else
        {
            Console.WriteLine("You already completed this goal");
            return 0;
        }
    }
    public void AddBonus()
    {
        _points += _bonusPoints;
    }
    public override void Display()
    {
        if (_done)
        {
            Console.WriteLine($"[X] {_goalName} - {_goalDescription} ({_points} Points / {_bonusPoints} Bonus)  {_timesCompleted}/{_numberToComplete}");
        }
        else
        {
            Console.WriteLine($"[ ] {_goalName} - {_goalDescription} ({_points} Points/ {_bonusPoints} Bonus)  {_timesCompleted}/{_numberToComplete}");
        }
    }
    public override string ReturnGoal()
    {
        if (_done)
        {
            return $"[X] {_goalName} - {_goalDescription} ({_points} Points / {_bonusPoints} Bonus)  {_timesCompleted}/{_numberToComplete}";
        }
        else
        {
            return $"[ ] {_goalName} - {_goalDescription} ({_points} Points/ {_bonusPoints} Bonus)  {_timesCompleted}/{_numberToComplete}";
        }
    }
    public override string[] SaveGoal()
    {
        return ["ChecklistGoal:", _goalName + ",", _goalDescription + ",", _points.ToString() + ",", _done.ToString() + ",", _numberToComplete.ToString() + ",", _timesCompleted.ToString() + ",", _bonusPoints.ToString()];
    }

    public ChecklistGoal(string name, string desc, int points) : base(name, desc, points)
    {
        _timesCompleted = 0;
        _numberToComplete = 1;
        _bonusPoints = 0;
    }

    public ChecklistGoal(string name, string desc, int points, int goalNum, int bonus) : base(name, desc, points)
    {
        _timesCompleted = 0;
        _numberToComplete = goalNum;
        _bonusPoints = bonus;
    }

    public ChecklistGoal(string name, string desc, int points, bool done, int goalNum, int completed, int bonus) : base(name, desc, points, done)
    {
        _timesCompleted = completed;
        _numberToComplete = goalNum;
        _bonusPoints = bonus;
    }
}