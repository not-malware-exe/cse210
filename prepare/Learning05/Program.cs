using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [];
        shapes.Add(new Square(5.0,Color.Red));
        shapes.Add(new Rectangle(3.0,4.0,Color.Green));
        shapes.Add(new Circle(6.0,Color.Blue));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color} Area: {shape.GetArea()}");
        }
    }
}