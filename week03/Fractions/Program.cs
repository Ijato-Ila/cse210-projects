using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(3, 4);
        Fraction f4 = new Fraction(1, 3);

        PrintFraction(f1, 1);
        PrintFraction(f2, 2);
        PrintFraction(f3, 3);
        PrintFraction(f4, 4);
    }

    static void PrintFraction(Fraction fraction, int number)
    {
        Console.WriteLine($"Fraction {number}: {fraction.GetFractionString()} = {fraction.GetDecimalValue()}");
    }
}
