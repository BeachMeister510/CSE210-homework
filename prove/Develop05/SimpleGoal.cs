public class SimpleGoal : Goal
{
    public override string[] SaveGoal()
    {
        return ["SimpleGoal:", _goalName + ",", _goalDescription + ",", _points.ToString(), _done.ToString() + ","];
    }

    public SimpleGoal(string name, string desc, int points) : base(name, desc, points)
    {

    }

    public SimpleGoal(string name, string desc, int points, bool done) : base(name, desc, points, done)
    {

    }
}