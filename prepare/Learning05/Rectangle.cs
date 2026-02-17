
using System.Drawing;

public class Rectangle : Shape
{
    
    public Rectangle(double length, double width, Color color) : base(color)
    {
        _width = width;
        _length = length;
    }

    private double _length = 0.0;
    public double Length
    {
        get
        {
            return _length;
        }
        set
        {
            _length = value;
        }

    }
    private double _width = 0.0;
    public double Width
    {
        get
        {
            return _width;
        }
        set
        {
            _width = value;
        }

    }

    public override double GetArea()
    {
        return _length * _width;
    }
}