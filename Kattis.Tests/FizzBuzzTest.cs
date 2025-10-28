namespace Kattis.Tests;

[TestFixture]
[TestOf(typeof(FizzBuzz))]
public class FizzBuzzTest
{
    private StringWriter _output; 
    
    [SetUp]
    public void Setup()
    { 
        _output = new StringWriter(); 
        Console.SetOut(_output); 
    }
    
    [Test]
    public void Test1()
    {
        // ARRANGE
        Console.SetIn(new StringReader("2 3 7\n"));
        
        // ACT
        FizzBuzz.Execute();

        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(7));
        Assert.Multiple(() =>
        {
            Assert.That(output[0], Is.EqualTo("1"));
            Assert.That(output[1], Is.EqualTo("Fizz"));
            Assert.That(output[2], Is.EqualTo("Buzz"));
            Assert.That(output[3], Is.EqualTo("Fizz"));
            Assert.That(output[4], Is.EqualTo("5"));
            Assert.That(output[5], Is.EqualTo("FizzBuzz"));
            Assert.That(output[6], Is.EqualTo("7"));
        });
    }
    [Test]
    public void Test2()
    {
        // ARRANGE
        Console.SetIn(new StringReader("2 4 7\n"));
        
        // ACT
        FizzBuzz.Execute();

        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(7));
        Assert.Multiple(() =>
        {
            Assert.That(output[0], Is.EqualTo("1"));
            Assert.That(output[1], Is.EqualTo("Fizz"));
            Assert.That(output[2], Is.EqualTo("3"));
            Assert.That(output[3], Is.EqualTo("FizzBuzz"));
            Assert.That(output[4], Is.EqualTo("5"));
            Assert.That(output[5], Is.EqualTo("Fizz"));
            Assert.That(output[6], Is.EqualTo("7"));
        });
    }
    [Test]
    public void Test3()
    {
        // ARRANGE
        Console.SetIn(new StringReader("3 5 7\n"));
        
        // ACT
        FizzBuzz.Execute();

        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(7));
        Assert.Multiple(() =>
        {
            Assert.That(output[0], Is.EqualTo("1"));
            Assert.That(output[1], Is.EqualTo("2"));
            Assert.That(output[2], Is.EqualTo("Fizz"));
            Assert.That(output[3], Is.EqualTo("4"));
            Assert.That(output[4], Is.EqualTo("Buzz"));
            Assert.That(output[5], Is.EqualTo("Fizz"));
            Assert.That(output[6], Is.EqualTo("7"));
        });
    }
    
    [TearDown]
    public void TearDown()
    {
        _output.Close();
    }
}