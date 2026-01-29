using System;

class Program
{
    static void Main(string[] args)
    {
        
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        
        Fraction f5 = new Fraction(5);
        Console.WriteLine(f5.GetFractionString());
        Console.WriteLine(f5.GetDecimalValue());
        
        Fraction f3_4 = new Fraction(3,4);
        Console.WriteLine(f3_4.GetFractionString());
        Console.WriteLine(f3_4.GetDecimalValue());
        
        Fraction f1_3 = new Fraction(1,3);
        Console.WriteLine(f1_3.GetFractionString());
        Console.WriteLine(f1_3.GetDecimalValue());

        Fraction fx = new Fraction();
        Random rnd = new Random();

        for (int i = 0; i < 20; i++)
        {
            fx.SetNumerator(rnd.Next());
            fx.SetDenominator(rnd.Next());
            Console.WriteLine($"Fraction {i}: string: {fx.GetFractionString()} Number: {fx.GetDecimalValue()}");
        }
    }
}