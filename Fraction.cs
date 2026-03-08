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
        if (typeof(T) == typeof(Polynomial<double>)) return;
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
        if (typeof(T) == typeof(int))
        {
            dynamic Dnumerator = numerator;
            dynamic Ddenominator = denominator;
            int PrevDiv = Math.Max(Math.Abs(Dnumerator), Math.Abs(Ddenominator));
            int remainder = Math.Min(Math.Abs(Dnumerator), Math.Abs(Ddenominator));
            int buffer = 1;
            while (remainder != 0)
            {
                buffer = remainder;
                remainder = PrevDiv % remainder;
                PrevDiv = buffer;
            }
            numerator /= (dynamic)buffer;
            denominator /= (dynamic)buffer;            
        }
        if (typeof(T) == typeof(Polynomial<double>))
        {
            dynamic Dnumerator = numerator;
            dynamic Ddenominator = denominator;
            Polynomial<double> PrevDiv;
            Polynomial<double> remainder;
            if (Dnumerator.Power > Ddenominator.Power)
            {
                PrevDiv = Dnumerator;
                remainder = Ddenominator;
            }
            else
            {
                PrevDiv = Ddenominator;
                remainder = Dnumerator;
            }
            Polynomial<double> buffer = new Polynomial<double>([1]);
            while (remainder.Power != 1 || remainder[0] != 0)
            {
                buffer = remainder;
                remainder = PrevDiv % remainder;
                PrevDiv = buffer;
            }
            numerator /= (dynamic)buffer;
            denominator /= (dynamic)buffer;            
        }
    }
    public Fraction(T NumeratorValue, T DenominatorValue)
    {
        if (typeof(T) == typeof(int))
        {
            if ((int)(object)DenominatorValue == 0)
                throw new DivideByZeroException("Denominator can't be equals zero");
            IntegerPart = (T)(Object)0;
        }

        if (typeof(T) == typeof(Polynomial<double>))
        {
            dynamic polyn = DenominatorValue;
            if (polyn.Power == 0 && polyn[0] == 0)
                throw new DivideByZeroException("Denominator can't be equals zero");
            IntegerPart = (T)(Object)new Polynomial<double>();
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

        if (typeof(T) == typeof(Polynomial<double>))
        {
            numerator = (T)(Object)new Polynomial<double>();
            denominator = (T)(Object)new Polynomial<double>([1]);
            IntegerPart = (T)(Object)new Polynomial<double>();
        }
   
    }
    public Fraction(T Value)
    {
        if (typeof(T) == typeof(int))
        {
            numerator = (T)(Object)Value;
            denominator = (T)(Object)1;
            IntegerPart = (T)(Object)0;
        }

        if (typeof(T) == typeof(Polynomial<double>))
        {
            dynamic PolyValue = Value;
            numerator = (T)(Object)new Polynomial<double>(PolyValue);
            denominator = (T)(Object)new Polynomial<double>([1]);
            IntegerPart = (T)(Object)new Polynomial<double>();
        }        
    }
    public Fraction(Fraction<T> otherFraction) : this(otherFraction.Numerator, otherFraction.Denominator)
    {}
    public override string ToString()
    {
        if (typeof(T) == typeof(int))
        {
            dynamic IntPart = IntegerPart;
            dynamic Dnumerator = numerator;
            if (IntPart == 0)
                return ($"{numerator}/{denominator}");
            else if (Dnumerator > 0)
                return ($"{IntegerPart} + {numerator}/{denominator}");
            return ($"{IntegerPart} - {Math.Abs(Dnumerator)}/{denominator}");
        }
        if (typeof(T) == typeof(Polynomial<double>))
        {
            dynamic IntPart = IntegerPart;
            dynamic Dnumerator = numerator;
            if (IntPart.Power == 1 && IntPart[0] == 0)
                return ($"{numerator}/{denominator}");
            return ($"{IntegerPart} + {numerator}/{denominator}");
        }
        throw new Exception("How you do it?");
    }
    public void Decomposition()
    {
        IntegerPart = (dynamic)numerator / denominator;
        if(typeof(T) == typeof(int))
        {
            dynamic Dnumerator = numerator;
            if (Dnumerator > 0)
                Dnumerator %= denominator;
            else
            {
                numerator = (Math.Abs(Dnumerator) % denominator) * -1;
            }            
        }
        if(typeof(T) == typeof(Polynomial<double>))
        {
                numerator %= (dynamic)denominator;
        }
    }
    public static Fraction<T> operator +(Fraction<T> val1, Fraction<T> val2)
    { 
        T newDenom = (dynamic)val1.Denominator * (dynamic)val2.Denominator;
        T numer1 = (dynamic)val1.Numerator * (dynamic)val2.Denominator;
        T numer2 = (dynamic)val2.Numerator * (dynamic)val1.Denominator;
        dynamic sum = (dynamic)numer1 + (dynamic)numer2;
        Fraction<T> result = new Fraction<T>(sum, newDenom);
        return result;            
    } 
    public static Fraction<T> operator -(Fraction<T> val1, Fraction<T> val2)
    {
        T newDenom = (dynamic)val1.Denominator * (dynamic)val2.Denominator;
        T numer1 = (dynamic)val1.Numerator * (dynamic)val2.Denominator;
        T numer2 = (dynamic)val2.Numerator * (dynamic)val1.Denominator;
        dynamic subt = (dynamic)numer1 - (dynamic)numer2;
        Fraction<T> result = new Fraction<T>(subt, newDenom);
        return result;            
    }
    public static Fraction<T> operator *(Fraction<T> val1, Fraction<T> val2)
    {
        T newNum = (dynamic)val1.Numerator * (dynamic)val2.Numerator;
        T newDenum = (dynamic)val1.Denominator * (dynamic)val2.Denominator;
        Fraction<T> result = new Fraction<T>(newNum, newDenum);
        return result;
    }
    public static Fraction<T> operator /(Fraction<T> val1, Fraction<T> val2)
    {
        dynamic Dval2 = val2;
        if (typeof(T) == typeof(int))
            if (Dval2.Numerator == 0)
                throw new DivideByZeroException("Divide by zero error");
        if (typeof(T) == typeof(Polynomial<double>))
            if (Dval2.Numerator.Power == 1 && Dval2.Numerator[0] == 0)
                throw new DivideByZeroException("Divide by zero error");
        T newNum = (dynamic)val1.Numerator * (dynamic)val2.Denominator;
        T newDenum = (dynamic)val1.Denominator * (dynamic)val2.Numerator;
        Fraction<T> result = new Fraction<T>(newNum, newDenum);
        return result;
    }
        public static explicit operator int(Fraction<T> fraction)
        {
            if(typeof(T) == typeof(int))
                return (dynamic)fraction.Numerator / fraction.Denominator;
            throw new InvalidOperationException("Cannot convert polynomial fraction to numeric type");
        }
        public static explicit operator double(Fraction<T> fraction)
        {
            if(typeof(T) == typeof(int))
                return (double)(dynamic)fraction.Numerator / (double)(dynamic)fraction.Denominator;
            throw new InvalidOperationException("Cannot convert polynomial fraction to numeric type");
        }
    public static implicit operator Fraction<T>(T value)
    {
        return new Fraction<T>(value);
    }        
}