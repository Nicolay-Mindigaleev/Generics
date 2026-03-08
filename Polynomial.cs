using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Linq.Expressions;

class Polynomial <T>
{
    private delegate void ChangedCoef(int i, T prevValue, T CurrValue);
    private delegate void ChangedPow(int prevVal, int CurrVal);
    private T[] array;
    private int power;
    private event ChangedPow ChangedPower;
    public int Power
    {
        get {return power;}
        set
        {
            ChangedPower(power, value);
            T[] arrayCopy = new T[value];
            if (value > power)
            {
                for (int i = 0; i < power; i++)
                {
                    arrayCopy[i] = array[i];
                }
                for(int i = power; i < value; i++)
                {
                    if (typeof(T) == typeof(int))
                        arrayCopy[i] = (dynamic)0;
                    if (typeof(T) == typeof(Fraction<int>))
                    {
                        arrayCopy[i] = (dynamic)new Fraction<int>();
                    }
                }
            }
            else
            {
                for (int i = 0; i < value; i++)
                {
                    arrayCopy[i] = array[i];
                }                
            }
            array = arrayCopy;
            power = value;
        }
    }
    private void ChangedPowerInfo(int prevPow, int currPow)
    {
        Console.WriteLine($"WARNING! Power have been changed from {prevPow} to {currPow}. Discarding was not activated. You need to activate it yourself");
    }
    private bool autoDiscarding = true;
    public bool AutoDiscarding
    {
        get {return autoDiscarding;}
        set {autoDiscarding = value;}
    }
    public void Discard()
    {
        if (typeof(T) == typeof(double))
        {
            int i = power - 1;
            while ((dynamic)array[i] == 0)
            {
                i--;
                if (i == -1)
                    break;
            }
            if (i == -1)
            {
                array = new T[1];
                array[0] = (dynamic)0;
                power = 1;
                return;
            }
        
            power = i + 1;
            T[] DiscardedArray = new T[power];
            for (int j = 0; j < power; j++)
            {
                DiscardedArray[j] = array[j];
            }
            array = DiscardedArray;
        } 
        if (typeof(T) == typeof(Fraction<int>))
        {
            int i = power - 1;
            while (i >= 0)
            {
                dynamic item = array[i];
                if (item.Numerator != 0)
                    break;
                i--;
            }
            if (i == -1)
            {
                array = new T[1];
                array[0] = (dynamic)new Fraction<int>();
                power = 1;
                return;
            }
        
            power = i + 1;
            T[] DiscardedArray = new T[power];
            for (int j = 0; j < power; j++)
            {
                DiscardedArray[j] = array[j];
            }
            array = DiscardedArray;
        }            
    }
    public Polynomial(int InputPower)
    {
        ChangedPower += ChangedPowerInfo;
        ChangedCoefEv += CoefChangeInfo;
        if (typeof(T) == typeof(double))
        {
            power = InputPower;
            array = new T[power];
            for(int i = 0; i < power; i++)
            {
                array[i] = (dynamic)i;
            }
            return;            
        }
        throw new Exception("Can't use fractions numbers");
    }
    public Polynomial(): this(1) {}
    public Polynomial(T[] values)
    {
        ChangedPower += ChangedPowerInfo;
        ChangedCoefEv += CoefChangeInfo;
        if (values.Length == 0)
        {
            if (typeof(T) == typeof(double))
            {
                values = new T[1];
                values[0] = (dynamic)0;                
            }
            if (typeof(T) == typeof(Fraction<int>))
            {
                values = new T[1];
                values[0] = (dynamic)new Fraction<int>();                
            }
        }
        array = new T[values.Length];
        power = values.Length;
        for (int i = 0; i < values.Length; i++)
            array[i] = values[i];
        if (autoDiscarding)
            Discard();
    }
    public Polynomial(Polynomial<T> otherPol)
    {
        ChangedPower += ChangedPowerInfo;
        ChangedCoefEv += CoefChangeInfo;
        array = new T[otherPol.Power];
        power = otherPol.Power;
        for (int i = 0; i < otherPol.Power; i++)
        {
            array[i] = otherPol.array[i];
        }
    }
    public override string ToString()
    {
        string result = "";
        for (int i = power - 1; i >= 0; i--)
        {
            string pow;
            if (i == 1)
                pow = "x";
            else if (i == 0)
                pow = "";
            else
                pow = $"x^{i}";
            string coef;
            if (typeof(T) == typeof(double))
            {
                if ((dynamic)array[i] == 0)
                {
                    continue;
                } 
                else if (Math.Abs((dynamic)array[i]) == 1 && i != 0)
                    coef = "";
                else
                    coef = $"{Math.Abs((dynamic)array[i])}";
                if ((dynamic)array[i] > 0)
                    result += " + ";
                else
                    result += " - ";
                result += coef + pow;    
            
                if (result == "")
                    result = "0";
            }
            if (typeof(T) == typeof(Fraction<int>))
            {
                dynamic item = array[i];
                if (item.Numerator == 0)
                {
                    continue;
                } 
                else if ((Math.Abs(item.Numerator) == 1 && Math.Abs(item.Denominator) == 1) && i != 0)
                    coef = "";
                else
                    coef = $"{Math.Abs(item.Numerator)}/{Math.Abs(item.Denominator)}";
                if (item.Numerator > 0)
                    result += " + ";
                else
                    result += " - ";
                result += coef + pow;    
            
                if (result == "")
                    result = "0";
            }                
        }
        int currentcoef = array.Length - 1;
        while (currentcoef >= 0)
        {
            if(typeof(T) == typeof(double))
            {
                if ((dynamic)array[currentcoef] > 0)
                    return result.Substring(3);
                else if ((dynamic)array[currentcoef] == 0)
                    currentcoef--;
                else
                    return "-" + result.Substring(3);                 
            }
            if(typeof(T) == typeof(Fraction<int>))
            {
                dynamic numer = array[currentcoef];
                if (numer.Numerator > 0)
                    return result.Substring(3);
                else if (numer.Numerator == 0)
                    currentcoef--;
                else
                    return "-" + result.Substring(3);                 
            }               
        }
        return result;
    }
    private event ChangedCoef ChangedCoefEv;
    public T this [int i]
    {
        get {return array[i];}
        set
        {
            ChangedCoefEv(i, array[i], value);
            array[i] = value;
            if (autoDiscarding)
                Discard();
        }
    }
    private void CoefChangeInfo(int i, T PrevValue, T CurrValue)
    {
        Console.WriteLine($"The coefficient with degree {i} was changed from {PrevValue} to {CurrValue}");
    }
    public static Polynomial<T> operator +(Polynomial<T> pol1, Polynomial<T> pol2)
    {
        T[] result = new T[Math.Max(pol1.Power, pol2.Power)];
        if (pol1.Power < pol2.Power)
        {
            Polynomial<T> buffer = new Polynomial<T>(pol1);
            pol1 = pol2;
            pol2 = buffer;
        }
        for (int i = 0; i < pol2.Power; i++)
        {
            result[i] = (dynamic)pol1[i] + pol2[i];        
        }
        for (int i = pol2.Power; i < pol1.Power; i++)
            result[i] = pol1[i];
        Polynomial<T> sumPol = new Polynomial<T>(result);
        return sumPol;
    }
    public static Polynomial<T> operator -(Polynomial<T> pol1, Polynomial<T> pol2)
    {
        T[] result = new T[Math.Max(pol1.Power, pol2.Power)];
        if (pol1.Power < pol2.Power)
        {
            Polynomial<T> buffer = new Polynomial<T>(pol1);
            pol1 = pol2;
            pol2 = buffer;
        }
        for (int i = 0; i < pol2.Power; i++)
        {
            result[i] = (dynamic)pol1[i] - pol2[i];        
        }
        for (int i = pol2.Power; i < pol1.Power; i++)
            result[i] = pol1[i];
        Polynomial<T> sumPol = new Polynomial<T>(result);
        return sumPol;
    }
    public static Polynomial<T> operator *(Polynomial<T> pol1, Polynomial<T> pol2)
    {
        T[] result = new T[pol1.Power + pol2.Power - 1];
        if (typeof(T) == typeof(Fraction<int>))
            for(int i = 0; i < result.Length; i++)
                result[i] =(dynamic) new Fraction<int>();
        for (int i = 0; i < pol2.Power; i++)
            for (int j = 0; j < pol1.Power; j++)
                result[i + j] += (dynamic)pol1[j] * (dynamic)pol2[i];               
        Polynomial<T> PolMul = new Polynomial<T>(result);
        return PolMul;
    }
    private static (Polynomial<T> quotient, Polynomial<T> remainder) Division(Polynomial<T> pol1, Polynomial<T> pol2)
    {
    if (typeof(T) == typeof(double))
        {
            if (pol2.Power == 1 && (dynamic)pol2[0] == 0)
                throw new DivideByZeroException("Divide by zero error");            
        }
    if (typeof(T) == typeof(Fraction<int>))
        {
            dynamic Dpol2 = pol2[0];
            if (pol2.Power == 1 && Dpol2.Numerator == 0)
                throw new DivideByZeroException("Divide by zero error");            
        }

    if (pol2.Power > pol1.Power)
        return (new Polynomial<T>(), new Polynomial<T>(pol1));
    int NewPow = pol1.Power - pol2.Power + 1;
    T[] result = new T[NewPow];
    T[] buffer = new T[pol1.Power];
    for (int i = 0; i < pol1.Power; i++)
        buffer[i] = (dynamic)pol1[i];
    for (int i = NewPow - 1; i >= 0; i--)
        {
            result[i] = (dynamic)buffer[i + pol2.Power - 1] / pol2[pol2.Power - 1];
            for (int j = 0; j < pol2.Power; j++)
            {
                buffer[i + j] -= (dynamic)result[i] * pol2[j];
            }
        }
        return (new Polynomial<T>((dynamic)result), new Polynomial<T>((dynamic)buffer));  
    }
    public static Polynomial<T> operator /(Polynomial<T> pol1, Polynomial<T> pol2)
    {
        return Division(pol1, pol2).quotient;
    }
    public static Polynomial<T> operator %(Polynomial<T> pol1, Polynomial<T> pol2)
    {
        return Division(pol1, pol2).remainder;
    }
}