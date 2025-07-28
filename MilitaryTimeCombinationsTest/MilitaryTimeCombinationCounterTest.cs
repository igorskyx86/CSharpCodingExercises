namespace MilitaryTimeCombinations.Tests;

using MilitaryTimeCombinations;
using NUnit.Framework;

[TestFixture]
public class MilitaryTimeCombinationCounterTests
{
    private MilitaryTimeCombinationCounter _counter;

    [SetUp]
    public void Setup()
    {
        _counter = new MilitaryTimeCombinationCounter();
    }

    // Functional correctness

    [TestCase("1?:4?", ExpectedResult = 100, Description = "10 valid hours (10–19), 10 valid minutes")]
    [TestCase("2?:??", ExpectedResult = 240, Description = "4 valid hours (20–23), 60 minutes")]
    [TestCase("??:??", ExpectedResult = 1440, Description = "24 hours * 60 minutes")]
    [TestCase("0?:0?", ExpectedResult = 100, Description = "10 valid hours (00–09), 10 valid minutes")]
    [TestCase("23:5?", ExpectedResult = 10, Description = "Fixed hour, 10 possible minutes (50–59)")]
    [TestCase("23:?5", ExpectedResult = 6, Description = "Fixed last minute digit, 6 valid minutes (05, 15,...55)")]
    [TestCase("00:00", ExpectedResult = 1, Description = "No wildcards")]
    [TestCase("?3:4?", ExpectedResult = 30, Description = "Hours 03, 13, 23 (3 options) * 10 minutes = 30")]
    public int Count_WithValidPatterns_ReturnsExpectedCombinations(string pattern)
    {
        return _counter.CountTimeCombinations(pattern);
    }

    // Invalid formats — should throw ArgumentException

    [TestCase("25:00", Description = "hour > 23")]
    [TestCase("1:00", Description = "missing leading zero")]
    [TestCase("13-00", Description = "invalid separator")]
    [TestCase("??:6a", Description = "invalid character")]
    [TestCase("2?:7?0aaadwdasadsfdekdfeidjksjjkdhksjdowjdkfksdljsjhskdjsldjksjdjksjhd", Description = "too long")]
    [TestCase("", Description = "empty")]
    public void Count_WithInvalidFormat_ThrowsArgumentException(string input)
    {
        var ex = Assert.Throws<ArgumentException>(() => _counter.CountTimeCombinations(input));
        Assert.That(ex.Message, Does.Contain("required format"));
    }
    
    [Test]
    public void Count_WithNullInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _counter.CountTimeCombinations(null));
    }
}