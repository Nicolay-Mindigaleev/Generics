using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Linq.Expressions;

class Polynomial
{
    private double[] array;
    private int power;
    private bool autoDiscarding = true;
    public bool AutoDiscarding
    {
        get {return autoDiscarding;}
        set {autoDiscarding = value;}
    }
    public int Power
    {
        get {return power;}
    }
    public void Discard()
    {
        int i = power - 1;
        while (array[i] == 0)
        {
            i--;
            if (i == -1)
                break;
        }
        if (i == -1)
        {
            array = new double[1];
            array[0] = 0;
            power = 1;
            return;
        }
        power = i + 1;
        double[] DiscardedArray = new double[power];
        for (int j = 0; j < power; j++)
        {
            DiscardedArray[j] = array[j];
        }
        array = DiscardedArray;
    }
    public Polynomial(int InputPower)
    {
        power = InputPower;
        array = new double[power];
        for(int i = 0; i < power; i++)
        {
            array[i] = i;
        }
    }
    public Polynomial(): this(1) {}
    public Polynomial(double[] values)
    {
        if (values.Length == 0)
        {
            values = new double[1];
            values[0] = 0;
        }
        array = new double[values.Length];
        power = values.Length;
        for (int i = 0; i < values.Length; i++)
            array[i] = values[i];
        if (autoDiscarding)
            Discard();
    }
    public Polynomial(Polynomial otherPol)
    {
        array = new double[otherPol.Power];
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
            if (array[i] == 0)
            {
                continue;
            } 
            else if (Math.Abs(array[i]) == 1 && i != 0)
                coef = "";
            else
                coef = $"{Math.Abs(array[i])}";
            if (array[i] > 0)
                result += " + ";
            else
                result += " - ";
            result += coef + pow;
            
        }
        if (result == "")
            result = "0";
        int currentcoef = array.Length - 1;
        while (currentcoef >= 0)
        {
            if (array[currentcoef] > 0)
                return result.Substring(3);
            else if (array[currentcoef] == 0)
                currentcoef--;
            else
                return "-" + result.Substring(3);                
        }
        return result;
    }
    public double this [int i]
    {
        get {return array[i];}
        set
        {
            array[i] = value;
            if (autoDiscarding)
                Discard();
        }
    }
    public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
    {
        double[] result = new double[Math.Max(pol1.Power, pol2.Power)];
        if (pol1.Power < pol2.Power)
        {
            Polynomial buffer = new Polynomial(pol1);
            pol1 = pol2;
            pol2 = buffer;
        }
        for (int i = 0; i < pol2.Power; i++)
        {
            result[i] = pol1[i] + pol2[i];        
        }
        for (int i = pol2.Power; i < pol1.Power; i++)
            result[i] = pol1[i];
        Polynomial sumPol = new Polynomial(result);
        return sumPol;
    }
    public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
    {
        Polynomial NegativePol2 = new Polynomial(pol2);
        for (int i = 0; i < pol2.Power; i++)
            NegativePol2[i] *= -1;
        return pol1 + NegativePol2;
    }
    public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
    {
        double[] result = new double[pol1.Power + pol2.Power - 1];
        for (int i = 0; i < pol2.Power; i++)
            for (int j = 0; j < pol1.Power; j++)
                result[i + j] += pol1[i] * pol2[j];               
        Polynomial PolMul = new Polynomial(result);
        return PolMul;
    }
    private static (Polynomial quotient, Polynomial remainder) Division(Polynomial pol1, Polynomial pol2)
    {
    if (pol2.Power == 1 && pol2[0] == 0)
        throw new DivideByZeroException("Divide by zero error");
    if (pol2.Power > pol1.Power)
        return (new Polynomial(), new Polynomial(pol1));
    int NewPow = pol1.Power - pol2.Power + 1;
    double[] result = new double[NewPow];
    double[] buffer = new double[pol1.Power];
    for (int i = 0; i < pol1.Power; i++)
        buffer[i] = pol1[i];
    for (int i = NewPow - 1; i >= 0; i--)
        {
            result[i] = buffer[i + pol2.Power - 1] / pol2[pol2.Power - 1];
            for (int j = 0; j < pol2.Power; j++)
            {
                buffer[i + j] -= result[i] * pol2[j];
            }
        }
        return (new Polynomial(result), new Polynomial(buffer));  
    }
    public static Polynomial operator /(Polynomial pol1, Polynomial pol2)
    {
        return Division(pol1, pol2).quotient;
    }
    public static Polynomial operator %(Polynomial pol1, Polynomial pol2)
    {
        return Division(pol1, pol2).remainder;
    }
}