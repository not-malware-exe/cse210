
using System.Drawing;

public class Circle : Shape
{
    
    public Circle(double radius, Color color) : base(color)
    {
        _radius = radius;
    }

    private double _radius = 0.0;

    public double Radius
    {
        get
        {
            return _radius;
        }
        set
        {
            _radius = value;
        }

    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(_radius,2);
    }
}