using MagnusCalculatorDocker;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
            try
            {
                Console.WriteLine("Enter 1st number...");

                string input1 = Console.ReadLine();

                if (input1 == null)
                {
                    Console.WriteLine("Input for the first number is null.");
                    return;
                }

                if (!double.TryParse(input1, out double n1))
                {
                    Console.WriteLine("Invalid input for the first number.");
                    return;
                }

                Console.WriteLine("Enter 2nd number...");

                string input2 = Console.ReadLine();

                if (input2 == null)
                {
                    Console.WriteLine("Input for the second number is null.");
                    return;
                }

                if (!double.TryParse(input2, out double n2))
                {
                    Console.WriteLine("Invalid input for the second number.");
                    return;
                }

                Console.WriteLine("Pick the operation by inserting the right symbol (-,+,/,*)");

                string operation = Console.ReadLine();

                string connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING");
                using (MySqlConnection connection = new MySqlConnection(connectionString))

                {
                    connection.Open();

                    Calculator _calculator = new Calculator(connection);

                    if (operation.Equals('+'))
                    {
                        double result = n1 + n2;
                        _calculator.Add(n1, n2);
                        Console.WriteLine($"Result: {result}");
                    }
                    else if (operation.Equals('-'))
                    {
                        double result = n1 - n2;
                        _calculator.Subtract(n1, n2);
                        Console.WriteLine($"Result: {result}");
                    }
                    else if (operation.Equals('/'))
                    {
                        double result = n1 / n2;
                        _calculator.Divide(n1, n2);
                        Console.WriteLine($"Result: {result}");
                    }
                    else if (operation.Equals('*'))
                    {
                        double result = n1 * n2;
                        _calculator.Multiply(n1, n2);
                        Console.WriteLine($"Result: {result}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
    }
}
