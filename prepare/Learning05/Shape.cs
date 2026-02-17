
using System.Drawing;

public abstract class Shape
{
    public Shape(Color color)
    {
        _color = color;
    }

    private Color _color = Color.Black;

    public Color Color
    {
        get
        {
            return _color;
        }
        set
        {
            _color = value;
        }

    }

    public abstract double GetArea();
}