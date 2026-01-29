
using System.Reflection;

class Fraction
{
    private int _numerator = 0;
    public int GetNumerator(){return _numerator;}
    public void SetNumerator(int value){_numerator = value;}

    private int _denominator = 0;
    public int GetDenominator(){return _denominator;}
    public void SetDenominator(int value){_denominator = value;}

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public Fraction(int numerator,int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public String GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public float GetDecimalValue()
    {
        return (float)_numerator / (float)_denominator;
    }
}