using MySql.Data.MySqlClient;

namespace MagnusCalculatorDocker;

public class Tests
{
    [Test]
    public void TestAdd()
    {
        var n1 = 10;
        var n2 = 5;
        var result = 15;

        FakeCalculator fc = new FakeCalculator();
        
        Assert.That(fc.Add(n1,n2).Equals(result));
    }
    
    [Test]
    public void TestSubtract()
    {
        var n1 = 10;
        var n2 = 5;
        var result = 5;

        FakeCalculator fc = new FakeCalculator();
        
        Assert.That(fc.Subtract(n1,n2).Equals(result));
    }
    
    [Test]
    public void TestDivide()
    {
        var n1 = 10;
        var n2 = 5;
        var result = 2;

        FakeCalculator fc = new FakeCalculator();
        
        Assert.That(fc.Divide(n1,n2).Equals(result));
    }
    
    [Test]
    public void TestMultiply()
    {
        var n1 = 10;
        var n2 = 5;
        var result = 50;

        FakeCalculator fc = new FakeCalculator();
        
        Assert.That(fc.Multiply(n1,n2).Equals(result));
    }
}