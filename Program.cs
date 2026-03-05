using System;
class Program
{
    static void Main()
    {
        /*{
        Console.WriteLine("INT FRACTION TEST");
        Console.WriteLine("FRACTION CONSTRUCTORS TEST");
        Fraction<int> fracDefault = new Fraction<int>();
        Fraction<int> fracInt = new Fraction<int>(7);
        Fraction<int> fracParams = new Fraction<int>(4, 12);
        Fraction<int> fracCopy = new Fraction<int>(fracParams);
        Console.WriteLine($"Fraction(): {fracDefault}");
        Console.WriteLine($"Fraction(7): {fracInt}");
        Console.WriteLine($"Fraction(4, 12): {fracParams}");
        Console.WriteLine($"Fraction(fracParams)(previosly): {fracCopy}");

        Console.WriteLine("FRACTION METHODS TEST");
        Fraction<int> WrongFrac = new Fraction<int>(17, 5);
        Console.Write($"Decomposition ({WrongFrac}) : ");
        WrongFrac.Decomposition(); 
        Console.WriteLine($"({WrongFrac})");

        Console.WriteLine("FRACTION OPERATIONS TEST");
        Fraction<int> fr1 = new Fraction<int>(5, 2);
        Fraction<int> fr2 = new Fraction<int>(3, 4);
        Console.WriteLine($"{fr1} + {fr2} = {fr1 + fr2}");
        Console.WriteLine($"{fr1} - {fr2} = {fr1 - fr2}");
        Fraction<int> fr3 = new Fraction<int>(6, 7);
        Fraction<int> fr4 = new Fraction<int>(3, 10);
        Console.WriteLine($"{fr3} * {fr4} = {fr3 * fr4}");
        Console.WriteLine($"{fr3} / {fr4} = {fr3 / fr4}");
        Fraction<int> fr5 = new Fraction<int>(9, 4);
        Fraction<int> fr6 = new Fraction<int>(1, 4);
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
        }*/
        {
        Console.WriteLine("POLYNOMIAL FRACTION TEST");
        Console.WriteLine("FRACTION CONSTRUCTORS TEST");
        Fraction<Polynomial> fracDefault = new Fraction<Polynomial>();
        Polynomial fracPolOneParam = new Polynomial([2, 9, 23, 6]);
        Fraction<Polynomial> fracPol = new Fraction<Polynomial>(fracPolOneParam);
        Polynomial fracPolTwoParam = new Polynomial([7, 12, 4, 91, 1, 3]);
        Fraction<Polynomial> fracParams = new Fraction<Polynomial>(fracPolOneParam, fracPolTwoParam);
        Fraction<Polynomial> fracCopy = new Fraction<Polynomial>(fracParams);
        Console.WriteLine($"Fraction(): {fracDefault}");
        Console.WriteLine($"Fraction(fracPolOneParam): {fracPol}");
        Console.WriteLine($"Fraction(fracPolOneParam, fracPolTwoParam): {fracParams}");
        Console.WriteLine($"Fraction(fracParams)(previosly): {fracCopy}");

        Console.WriteLine("FRACTION METHODS TEST");
        Polynomial polynomTest1 = new Polynomial([7, 12, 4, 91, 1, 3]);
        Polynomial polynomTest2 = new Polynomial([12, 35, 43, 9, 11, 8, 1]);
        Fraction<Polynomial> WrongFrac = new Fraction<Polynomial>(polynomTest1, polynomTest2);
        Console.Write($"Decomposition ({WrongFrac}) : ");
        WrongFrac.Decomposition(); 
        Console.WriteLine($"({WrongFrac})");

        Console.WriteLine("FRACTION OPERATIONS TEST");
        Fraction<Polynomial> fr1 = new Fraction<Polynomial>(polynomTest1, polynomTest2);
        Fraction<Polynomial> fr2 = new Fraction<Polynomial>(polynomTest1, polynomTest2);
        Console.WriteLine($"{fr1} + {fr2} = {fr1 + fr2}");
        Console.WriteLine($"{fr1} - {fr2} = {fr1 - fr2}");
        Fraction<Polynomial> fr3 = new Fraction<Polynomial>(polynomTest1, polynomTest2);
        Fraction<Polynomial> fr4 = new Fraction<Polynomial>(polynomTest1, polynomTest2);
        Console.WriteLine($"{fr3} * {fr4} = {fr3 * fr4}");
        Console.WriteLine($"{fr3} / {fr4} = {fr3 / fr4}");
        }    
    }
}