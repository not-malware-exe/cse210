
using System.Drawing;

public class Square : Shape
{

    public Square(double sideLength, Color color) : base(color)
    {
        _sideLength = sideLength;
    }

    private double _sideLength = 0.0;

    public double SideLength
    {
        get
        {
            return _sideLength;
        }
        set
        {
            _sideLength = value;
        }

    }

    public override double GetArea()
    {
        return Math.Pow(_sideLength,2.0);
    }
}