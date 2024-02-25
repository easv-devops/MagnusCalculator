using MySql.Data.MySqlClient;

namespace MagnusCalculatorDocker;

public class Calculator : ICalculator
{
    private MySqlConnection _connection;

    public Calculator(MySqlConnection connection)
    {
        _connection = connection;
    }
    
    public double Add(double n1, double n2)
    {
        double result = n1 + n2;
        SaveData(n1, n2, "Addition", result);
        return result;
    }

    public double Subtract(double n1, double n2)
    {
        double result = n1 - n2;
        SaveData(n1, n2, "Subtract", result);
        return result;
    }

    public double Multiply(double n1, double n2)
    {
        double result = n1 * n2;
        SaveData(n1, n2, "Multiply", result);
        return result;
    }

    public double Divide(double n1, double n2)
    {
        double result = n1 / n2;
        SaveData(n1, n2, "Divide", result);
        return result;
    }

    private void SaveData(double n1, double n2, string _operator, double result)
    {
        string insertQuery = "INSERT INTO calcHistory (firstNum, secondNum, operator, finalRes) VALUES (@Value1, @Value2, @Value4, @Value4)";
        
        using (MySqlCommand cmd = new MySqlCommand(insertQuery, _connection))
        {
            cmd.Parameters.AddWithValue("@Value1", n1);
            cmd.Parameters.AddWithValue("@Value2", n2);
            cmd.Parameters.AddWithValue("@Value3", _operator);
            cmd.Parameters.AddWithValue("@Value4", result);
            cmd.ExecuteNonQuery();
        }
        Console.WriteLine("Added to history");
    }
}