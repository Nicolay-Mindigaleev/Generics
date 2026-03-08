using System;
class Program
{
    static void Main()
    {/*
        {
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
        Polynomial<double> polParams = new Polynomial<double>(5);
        Console.WriteLine($"Polynomial(5): {polParams}");
        Polynomial<double> polArr = new Polynomial<double>([3, 5, 8, -9]);
        Console.WriteLine($"Polynomial(array): {polArr}");
        Polynomial<double> polCopy = new Polynomial<double>(polParams);
        Console.WriteLine($"Polynomial(polParams): {polCopy}");
        Console.WriteLine("POLYNOMIAL OPERATIONS TEST");
        Polynomial<double> p1 = new Polynomial<double>(3);
        Polynomial<double> p2 = new Polynomial<double>(5);
        Console.WriteLine($"{p1}  +  {p2}  =  {p1 + p2}");
        Polynomial<double> p3 = new Polynomial<double>(3);
        Polynomial<double> p4 = new Polynomial<double>(3);
        Console.WriteLine($"{p3}  *  {p4}  =  {p3 * p4}");
        Polynomial<double> p5 = new Polynomial<double>([2, 3, 1]);
        Polynomial<double> p6 = new Polynomial<double>([1, 1]);
        Console.WriteLine($"{p5}  /  {p6}  =  {p5 / p6}");
        Console.WriteLine($"{p5}  %  {p6}  =  {p5 % p6}");
        }
        {
        Console.WriteLine("POLYNOMIAL FRACTION TEST");
        Console.WriteLine("FRACTION CONSTRUCTORS TEST");
        Fraction<Polynomial<double>> fracDefault = new Fraction<Polynomial<double>>();
        Polynomial<double> fracPolOneParam = new Polynomial<double>([2, 9, 23, 6]);
        Fraction<Polynomial<double>> fracPol = new Fraction<Polynomial<double>>(fracPolOneParam);
        Polynomial<double> fracPolTwoParam = new Polynomial<double>([7, 12, 4, 91, 1, 3]);
        Fraction<Polynomial<double>> fracParams = new Fraction<Polynomial<double>>(fracPolOneParam, fracPolTwoParam);
        Fraction<Polynomial<double>> fracCopy = new Fraction<Polynomial<double>>(fracParams);
        Console.WriteLine($"Fraction(): {fracDefault}");
        Console.WriteLine($"Fraction(fracPolOneParam): {fracPol}");
        Console.WriteLine($"Fraction(fracPolOneParam, fracPolTwoParam): {fracParams}");
        Console.WriteLine($"Fraction(fracParams)(previosly): {fracCopy}");

        Console.WriteLine("FRACTION METHODS TEST");
        Polynomial<double> polynomTest1 = new Polynomial<double>([7, 12, 4, 91, 1, 3]);
        Polynomial<double> polynomTest2 = new Polynomial<double>([12, 35, 43, 9, 11, 8, 1]);
        Fraction<Polynomial<double>> WrongFrac = new Fraction<Polynomial<double>>(polynomTest1, polynomTest2);
        Console.Write($"Decomposition ({WrongFrac}) : ");
        WrongFrac.Decomposition(); 
        Console.WriteLine($"({WrongFrac})");

        Console.WriteLine("FRACTION OPERATIONS TEST");
        Fraction<Polynomial<double>> fr1 = new Fraction<Polynomial<double>>(polynomTest1, polynomTest2);
        Fraction<Polynomial<double>> fr2 = new Fraction<Polynomial<double>>(polynomTest1, polynomTest2);
        Console.WriteLine($"{fr1} + {fr2} = {fr1 + fr2}");
        Console.WriteLine($"{fr1} - {fr2} = {fr1 - fr2}");
        Fraction<Polynomial<double>> fr3 = new Fraction<Polynomial<double>>(polynomTest1, polynomTest2);
        Fraction<Polynomial<double>> fr4 = new Fraction<Polynomial<double>>(polynomTest1, polynomTest2);
        Console.WriteLine($"{fr3} * {fr4} = {fr3 * fr4}");
        Console.WriteLine($"{fr3} / {fr4} = {fr3 / fr4}");
        }*/
    /*{
    Console.WriteLine("POLYNOMIAL<FRACTION> TEST");
    Console.WriteLine("CONSTRUCTORS TEST");
        
    // Конструктор от массива дробей
    Fraction<int>[] fracArray = new Fraction<int>[]
    {
        new Fraction<int>(1, 2),
        new Fraction<int>(2, 3),
        new Fraction<int>(3, 4),
        new Fraction<int>(4, 5)
    };
    Polynomial<Fraction<int>> polyArray = new Polynomial<Fraction<int>>(fracArray);
    Console.WriteLine($"Polynomial(1/2, 2/3, 3/4, 4/5): {polyArray}");
    
    // Конструктор копирования
    Polynomial<Fraction<int>> polyCopy = new Polynomial<Fraction<int>>(polyArray);
    Console.WriteLine($"Polynomial(copy): {polyCopy}");
    
    Console.WriteLine("POLYNOMIAL OPERATIONS TEST");
    
    // Первый полином: 1/2 + 2/3 x + 3/4 x²
    Fraction<int>[] coeffs1 = new Fraction<int>[]
    {
        new Fraction<int>(1, 2),
        new Fraction<int>(2, 3),
        new Fraction<int>(3, 4)
    };
    Polynomial<Fraction<int>> poly1 = new Polynomial<Fraction<int>>(coeffs1);
    
    // Второй полином: 4/5 + 5/6 x + 6/7 x²
    Fraction<int>[] coeffs2 = new Fraction<int>[]
    {
        new Fraction<int>(4, 5),
        new Fraction<int>(5, 6),
        new Fraction<int>(6, 7)
    };
    Polynomial<Fraction<int>> poly2 = new Polynomial<Fraction<int>>(coeffs2);
    
    Console.WriteLine($"poly1 = {poly1}");
    Console.WriteLine($"poly2 = {poly2}");
    Console.WriteLine($"poly1 + poly2 = {poly1 + poly2}");
    Console.WriteLine($"poly1 - poly2 = {poly1 - poly2}");
    Console.WriteLine($"poly1 * poly2 = {poly1 * poly2}");
    
    // Тест на Discard() с нулями
    Fraction<int>[] coeffsWithZeros = new Fraction<int>[]
    {
        new Fraction<int>(0, 1),
        new Fraction<int>(0, 1),
        new Fraction<int>(1, 2),
        new Fraction<int>(2, 3),
        new Fraction<int>(0, 1),
        new Fraction<int>(0, 1)
    };
    Polynomial<Fraction<int>> polyZeros = new Polynomial<Fraction<int>>(coeffsWithZeros);
    Console.WriteLine($"poly with zeros (before Discard): {polyZeros}");
    polyZeros.Discard();
    Console.WriteLine($"poly with zeros (after Discard): {polyZeros}");
    
    // Тест индексатора
    Console.WriteLine($"poly1[0] = {poly1[0]}");
    Console.WriteLine($"poly1[1] = {poly1[1]}");
    Console.WriteLine($"poly1[2] = {poly1[2]}");
    
    // Тест AutoDiscarding
    polyZeros.AutoDiscarding = false;
    Fraction<int>[] newCoeffs = new Fraction<int>[]
    {
        new Fraction<int>(0, 1),
        new Fraction<int>(0, 1),
        new Fraction<int>(5, 7)
    };
    Polynomial<Fraction<int>> polyNoDiscard = new Polynomial<Fraction<int>>(newCoeffs);
    Console.WriteLine($"poly with AutoDiscarding=false: {polyNoDiscard}");
    Console.WriteLine("POLYNOMIAL<FRACTION> DIVISION TEST");*/

    // (1/2 x + 1/3) * (2/3 x + 1/4) = ?
    // Посчитаем руками, а потом проверим деление
    /*{
    Fraction<int>[] coeffs1 = new Fraction<int>[]
    {
        new Fraction<int>(1, 3),  // свободный член
        new Fraction<int>(1, 2)   // коэффициент при x
    };

    Fraction<int>[] coeffs2 = new Fraction<int>[]
    {
        new Fraction<int>(1, 4),  // свободный член
        new Fraction<int>(2, 3)   // коэффициент при x
    };

    Polynomial<Fraction<int>> polyA = new Polynomial<Fraction<int>>(coeffs1); // 1/2x + 1/3
    Polynomial<Fraction<int>> polyB = new Polynomial<Fraction<int>>(coeffs2); // 2/3x + 1/4

    Polynomial<Fraction<int>> polyMul = polyA * polyB;
    Console.WriteLine($"({polyA}) * ({polyB}) = {polyMul}");

    // Теперь деление: (polyMul) / polyA должно дать polyB
    Polynomial<Fraction<int>> quotient = polyMul / polyA;
    Polynomial<Fraction<int>> remainder = polyMul % polyA;

    Console.WriteLine($"({polyMul}) / ({polyA}) = {quotient}");
    Console.WriteLine($"остаток = {remainder}");
    }
}
    }*/
    Polynomial<double> ChangePowPol = new Polynomial<double>([1, 2, 8, 51]);
    ChangePowPol.Power = 9;
    ChangePowPol[1] = 2.35;
    ChangePowPol[3] = 15.212;
    }
}