class Fraction <T>
{
    private T numerator;
    public T Numerator
    {
        get {return numerator;}
        private set
        {numerator = value;}
    }
    private T denominator;
    public T Denominator
    {
        get {return denominator;}
        private set
        {denominator = value;}
    }
    private T IntegerPart;
    private bool autoReduce;
    public bool AutoReduce
    {
        get {return autoReduce;}
        set {autoReduce = value;}
    }
    private void SignCheck()
    {
        if (typeof(T) == typeof(Polynomial)) return;
        dynamic numer = numerator, denom = denominator;
        if (denom < 0)
        {
            numer *= -1;
            denom *= -1;
            numerator = numer;
            denominator = denom;
        }

    }
    public void Reduce()
    {
        int PrevDiv = Math.Max(Math.Abs(numerator), Math.Abs(denominator));
        int remainder = Math.Min(Math.Abs(numerator), Math.Abs(denominator));
        int buffer = 1;
        while (remainder != 0)
        {
            buffer = remainder;
            remainder = PrevDiv % remainder;
            PrevDiv = buffer;
        }
        numerator /= buffer;
        denominator /= buffer;
    }
    public Fraction(T NumeratorValue, T DenominatorValue)
    {
        numerator = default(T);
        denominator = default(T);
        IntegerPart = default(T);
        if (typeof(T) == typeof(int))
        {
            if ((int)(object)DenominatorValue == 0)
                throw new DivideByZeroException("Denominator can't be equals zero");
            IntegerPart = (T)(Object)0;
        }

        if (typeof(T) == typeof(Polynomial))
        {
            dynamic polyn = DenominatorValue;
            if (polyn.Power == 0 && polyn[0] == 0)
                throw new DivideByZeroException("Denominator can't be equals zero");
            IntegerPart = (T)(Object)new Polynomial();
        }
        numerator = NumeratorValue;
        denominator = DenominatorValue;
        SignCheck();
        if (AutoReduce)
            Reduce();
    }
    public Fraction()
    {
        if (typeof(T) == typeof(int))
        {
            numerator = (T)(Object)0;
            denominator = (T)(Object)1;
            IntegerPart = (T)(Object)0;
        }

        if (typeof(T) == typeof(Polynomial))
        {
            numerator = (T)(Object)new Polynomial();
            denominator = (T)(Object)new Polynomial([1]);
            IntegerPart = (T)(Object)new Polynomial();
        }
   
    }
    public Fraction(int IntegerValue) : this(IntegerValue, 1)
    {}
    public Fraction(Fraction otherFraction) : this(otherFraction.Numerator, otherFraction.Denominator)
    {}
    public override string ToString()
    {
        if (IntegerPart == 0)
            return ($"{numerator}/{denominator}");
        else if (numerator > 0)
            return ($"{IntegerPart} + {numerator}/{denominator}");
        return ($"{IntegerPart} - {Math.Abs(numerator)}/{denominator}");
    }
    public void Decomposition()
    {
        IntegerPart = numerator / denominator;
        if (numerator > 0)
            numerator %= denominator;
        else
        {
            numerator = (Math.Abs(numerator) % denominator) * -1;
        }
    }
    public static Fraction operator +(Fraction val1, Fraction val2)
    {
        int newDenom = val1.Denominator * val2.Denominator;
        int numer1 = val1.Numerator * val2.Denominator;
        int numer2 = val2.Numerator * val1.Denominator;
        Fraction result = new Fraction(numer1 + numer2, newDenom);
        return result;
    } 
    public static Fraction operator -(Fraction val1, Fraction val2)
    {
        Fraction val2Copy = new Fraction(val2);
        val2Copy.Numerator *= -1;
        return val1 + val2Copy;
    }
    public static Fraction operator *(Fraction val1, Fraction val2)
    {
        Fraction result = new Fraction(val1.Numerator * val2.Numerator, 
                                      val1.Denominator * val2.Denominator);
        return result;
    }
    public static Fraction operator /(Fraction val1, Fraction val2)
    {
        if (val2.Numerator == 0)
            throw new DivideByZeroException("Divide by zero error");
        Fraction result = new Fraction(val1.Numerator * val2.Denominator, 
                                      val1.Denominator * val2.Numerator);
        return result;
    }
    public static explicit operator int(Fraction fraction)
    {
        return fraction.Numerator / fraction.Denominator;
    }
    public static explicit operator double(Fraction fraction)
    {
        return (double)fraction.Numerator / (double)fraction.Denominator;
    }
    public static implicit operator Fraction(int value)
    {
        return new Fraction(value);
    }        
}