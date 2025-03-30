using System.Security.Cryptography.X509Certificates;

public class EternalGoal : Goal
{
    public override string[] SaveGoal()
    {
        return ["EternalGoal:", _goalName + ",", _goalDescription + ",", _points.ToString()];
    }
    public override int FinishGoal()
    {
        return _points;
    }

    public EternalGoal(string name, string desc, int points) : base(name, desc, points)
    {

    }
}