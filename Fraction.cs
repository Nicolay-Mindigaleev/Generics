/// <summary>
/// universal fraction class with numerator and denominator T type.
/// supports int (common fraction) and Polynomial&lt;double&gt; type (Polynomial fraction).
/// </summary>
/// <typeparam name="T">numerator and denominator type: int or Polynomial&lt;double&gt;</typeparam>
class Fraction <T>
{
    /// <summary>
    /// Numerator of the fraction. Read only access
    /// </summary>
    private T numerator;
    public T Numerator
    {
        get {return numerator;}
        private set
        {numerator = value;}
    }
    /// <summary>
    /// Denominator of the fraction. Read only access.
    /// </summary>
    private T denominator;
    public T Denominator
    {
        get {return denominator;}
        private set
        {denominator = value;}
    }
    /// <summary>
    /// The integer part of a fraction. Used after calling Decomposition() method. Private access
    /// </summary>
    private T IntegerPart;
    /// <summary>
    /// Automatic fraction reduction flag. Default value: true. Read and edit access
    /// </summary>
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
    /// <summary>
    /// fraction reduction method.
    /// </summary>    
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
    /// <summary>
    /// Overriding ToString method. Prints numerator and denominator of the fraction, also prints integer part of the fraction, if it not equal zero
    /// </summary>  
    /// <returns>A string of all components of a fraction</returns>
    /// <exception cref="Exception">If somehow it doesn't return a value</exception>
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
    /// <summary>
    /// fraction decompositions method.
    /// </summary>  
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
    /// <summary>
    /// Addition fractions.
    /// </summary>
    /// <param name="val1">First fraction</param>
    /// <param name="val2">Second fraction</param>
    /// <returns>New fraction - result addition</returns>      
    public static Fraction<T> operator +(Fraction<T> val1, Fraction<T> val2)
    { 
        T newDenom = (dynamic)val1.Denominator * (dynamic)val2.Denominator;
        T numer1 = (dynamic)val1.Numerator * (dynamic)val2.Denominator;
        T numer2 = (dynamic)val2.Numerator * (dynamic)val1.Denominator;
        dynamic sum = (dynamic)numer1 + (dynamic)numer2;
        Fraction<T> result = new Fraction<T>(sum, newDenom);
        return result;            
    } 
    /// <summary>
    /// Subtract fractions.
    /// <param name="val1">Minuend fraction</param>
    /// <param name="val2">Subtrahend fraction</param>
    /// </summary>
    /// <returns>New fraction - result subtracting</returns> 
    public static Fraction<T> operator -(Fraction<T> val1, Fraction<T> val2)
    {
        T newDenom = (dynamic)val1.Denominator * (dynamic)val2.Denominator;
        T numer1 = (dynamic)val1.Numerator * (dynamic)val2.Denominator;
        T numer2 = (dynamic)val2.Numerator * (dynamic)val1.Denominator;
        dynamic subt = (dynamic)numer1 - (dynamic)numer2;
        Fraction<T> result = new Fraction<T>(subt, newDenom);
        return result;            
    }
    /// <summary>
    /// Multiply fractions.
    /// </summary>
    /// <param name="val1">First fraction</param>
    /// <param name="val2">Second fraction</param>
    /// <returns>New fraction - result multiplying</returns> 
    public static Fraction<T> operator *(Fraction<T> val1, Fraction<T> val2)
    {
        T newNum = (dynamic)val1.Numerator * (dynamic)val2.Numerator;
        T newDenum = (dynamic)val1.Denominator * (dynamic)val2.Denominator;
        Fraction<T> result = new Fraction<T>(newNum, newDenum);
        return result;
    }
    /// <summary>
    /// Division fractions.
    /// </summary>
    /// <param name="val1">Dividend fraction</param>
    /// <param name="val2">Divider fraction</param>
    /// <returns>New fraction - result dividing</returns> 
    /// <exception cref="DivideByZeroException">If second fraction equals zero</exception>
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
    /// <summary>
    /// Converting a fraction to decimal format. Only int type
    /// </summary>
    /// <param name="fraction">The fraction on which the operation will be performed</param>
    /// <returns>Division result in integer format</returns> 
    /// <exception cref="InvalidOperationException">If fraction type is polynomial</exception>
    public static explicit operator int(Fraction<T> fraction)
    {
        if(typeof(T) == typeof(int))
            return (dynamic)fraction.Numerator / fraction.Denominator;
        throw new InvalidOperationException("Cannot convert polynomial fraction to numeric type");
    }
    /// <summary>
    /// Converting a fraction to decimal format. Only int type
    /// </summary>
    /// <param name="fraction">The fraction on which the operation will be performed</param>
    /// <returns>Division result in double format</returns> 
    /// <exception cref="InvalidOperationException">If fraction type is polynomial</exception>
    public static explicit operator double(Fraction<T> fraction)
    {
        if(typeof(T) == typeof(int))
            return (double)(dynamic)fraction.Numerator / (double)(dynamic)fraction.Denominator;
        throw new InvalidOperationException("Cannot convert polynomial fraction to numeric type");
    }
    /// <summary>
    /// Converting a value in fraction type.
    /// </summary>
    /// <param name="value">The value on which the operation will be performed</param>
    /// <returns>fraction / 1</returns> 
    public static implicit operator Fraction<T>(T value)
    {
        return new Fraction<T>(value);
    }        
}