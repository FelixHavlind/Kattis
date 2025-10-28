namespace Kattis.Tests;

[TestFixture]
[TestOf(typeof(CandleBox))]
public class CandleBoxTest
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
        Console.SetIn(new StringReader("2\n26\n8\n"));
    
        // ACT
        CandleBox.Execute();
    
        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(1));
        Assert.That(output[0], Is.EqualTo("4"));
    }
    [Test]
    public void Test2()
    {
        // ARRANGE
        Console.SetIn(new StringReader("4\n75\n10\n"));
    
        // ACT
        CandleBox.Execute();
    
        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(1));
        Assert.That(output[0], Is.EqualTo("15"));
    }
    [Test]
    public void Test3()
    {
        // ARRANGE
        Console.SetIn(new StringReader("3\n45\n12\n"));
    
        // ACT
        CandleBox.Execute();
    
        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(1));
        Assert.That(output[0], Is.EqualTo("6"));
    }
    
    [TearDown]
    public void TearDown()
    {
        _output.Close();
    }
}