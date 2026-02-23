using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("FRACTION CONSTRUCTORS TEST");
        Fraction fracDefault = new Fraction();
        Fraction fracInt = new Fraction(7);
        Fraction fracParams = new Fraction(4, 12);
        Fraction fracCopy = new Fraction(fracParams);
        Console.WriteLine($"Fraction(): {fracDefault}");
        Console.WriteLine($"Fraction(7): {fracInt}");
        Console.WriteLine($"Fraction(4, 12): {fracParams}");
        Console.WriteLine($"Fraction(fracParams)(previosly): {fracCopy}");

        Console.WriteLine("FRACTION METHODS TEST");
        Fraction WrongFrac = new Fraction(17, 5);
        Console.Write($"Decomposition ({WrongFrac}) : ");
        WrongFrac.Decomposition(); 
        Console.WriteLine($"({WrongFrac})");

        Console.WriteLine("FRACTION OPERATIONS TEST");
        Fraction fr1 = new Fraction(5, 2);
        Fraction fr2 = new Fraction(3, 4);
        Console.WriteLine($"{fr1} + {fr2} = {fr1 + fr2}");
        Console.WriteLine($"{fr1} - {fr2} = {fr1 - fr2}");
        Fraction fr3 = new Fraction(6, 7);
        Fraction fr4 = new Fraction(3, 10);
        Console.WriteLine($"{fr3} * {fr4} = {fr3 * fr4}");
        Console.WriteLine($"{fr3} / {fr4} = {fr3 / fr4}");
        Fraction fr5 = new Fraction(9, 4);
        Fraction fr6 = new Fraction(1, 4);
        Console.WriteLine($"{fr5} = {(int)fr5}");
        Console.WriteLine($"{fr5} = {(double)fr5}");
        Console.WriteLine($"{fr6} = {(int)fr6}");
        Console.WriteLine($"{fr6} = {(double)fr6}");

        Console.WriteLine("POLYNOMIAL CONSTRUCTORS TEST");
        Polynomial polParams = new Polynomial(5);
        Console.WriteLine($"Polynomial(5): {polParams}");
        Polynomial polArr = new Polynomial([3, 5, 8, -9]);
        Console.WriteLine($"Polynomial(array): {polArr}");
        Polynomial polCopy = new Polynomial(polParams);
        Console.WriteLine($"Polynomial(polParams): {polCopy}");
        Console.WriteLine("POLYNOMIAL OPERATIONS TEST");
        Polynomial p1 = new Polynomial(3);
        Polynomial p2 = new Polynomial(5);
        Console.WriteLine($"{p1}  +  {p2}  =  {p1 + p2}");
        Polynomial p3 = new Polynomial(3);
        Polynomial p4 = new Polynomial(3);
        Console.WriteLine($"{p3}  *  {p4}  =  {p3 * p4}");
        Polynomial p5 = new Polynomial([2, 3, 1]);
        Polynomial p6 = new Polynomial([1, 1]);
        Console.WriteLine($"{p5}  /  {p6}  =  {p5 / p6}");
        Console.WriteLine($"{p5}  %  {p6}  =  {p5 % p6}");        
    }
}