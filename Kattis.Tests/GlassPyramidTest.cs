using Kattis;

namespace Kattis.Tests;

[TestFixture]
[TestOf(typeof(GlassPyramid))]
public class GlassPyramidTest
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
        Console.SetIn(new StringReader("0\n0"));
        
        // ACT
        GlassPyramid.Execute();
        
        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(1));
        Assert.That(output[0], Is.EqualTo("10"));
    }
    
    [Test]
    public void Test2()
    {
        // ARRANGE
        Console.SetIn(new StringReader("4\n0"));
        
        // ACT
        GlassPyramid.Execute();
        
        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(1));
        Assert.That(output[0], Is.EqualTo("310"));
    }
    
    [Test]
    public void Test3()
    {
        // ARRANGE
        Console.SetIn(new StringReader("3\n1"));
        
        // ACT
        GlassPyramid.Execute();
        
        // ASSERT
        var output = _output.ToString().Split(
            [Environment.NewLine],
            StringSplitOptions.RemoveEmptyEntries
        );
        
        Assert.That(output, Has.Length.EqualTo(1));
        Assert.That(output[0], Is.EqualTo("83.333"));
    }

    [TearDown]
    public void TearDown()
    {
        _output.Close();
    }
}