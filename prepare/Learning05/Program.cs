using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        var square = new Square("blue", 5);

        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        var rectangle = new Rectangle("red", 2, 10);
        var circle = new Circle("purple", 3);

        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        var shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes){
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"{color}, {area}");
        }

    }
}