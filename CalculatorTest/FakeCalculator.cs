namespace MagnusCalculatorDocker;

using MySql.Data.MySqlClient;


public class FakeCalculator : ICalculator
{
    public double Add(double n1, double n2)
    {
        double result = n1 + n2;
        return result;
    }

    public double Subtract(double n1, double n2)
    {
        double result = n1 - n2;
        return result;
    }

    public double Multiply(double n1, double n2)
    {
        double result = n1 * n2;
        return result;
    }

    public double Divide(double n1, double n2)
    {
        double result = n1 / n2;
        return result;
    }
}