using System.ComponentModel.DataAnnotations;

public class Square : Shape
{
    private double _side;

    public override double GetArea()
    {
        double area = _side * _side;
        return area;
    }

    public Square(string color, double length) : base(color)
    {
        _side = length;
    }
}