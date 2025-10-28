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
        Console.SetIn(new StringReader("3\n1"));
        
        // ACT
        GlassPyramid.Execute();
        
        // ASSERT
    }

    [TearDown]
    public void TearDown()
    {
        _output.Close();
    }
}