namespace TestProject1;
using MilitaryTimeCombinations;
using NUnit.Framework;
using NUnit.Framework.Legacy;

[TestFixture]
public class Tests
{
    private MilitaryTimeCombinationCounter _counter;

    [SetUp]
    public void Setup()
    {
        _counter = new MilitaryTimeCombinationCounter();
    }

    // Functional correctness

    [TestCase("1?:4?", ExpectedResult = 100)]   // 10 valid hours (10–19), 10 valid minutes
    [TestCase("2?:??", ExpectedResult = 240)]   // 4 valid hours (20–23), 60 minutes
    [TestCase("??:??", ExpectedResult = 1440)]  // 24 hours * 60 minutes
    [TestCase("0?:0?", ExpectedResult = 100)]   // 10 valid hours (00–09), 10 valid minutes
    [TestCase("23:5?", ExpectedResult = 10)]    // Fixed hour, 10 possible minutes (50–59)
    [TestCase("23:?5", ExpectedResult = 6)]     // Fixed last minute digit, 6 valid minutes (05, 15,...55)
    [TestCase("00:00", ExpectedResult = 1)]     // No wildcards
    [TestCase("?3:4?", ExpectedResult = 30)]    // Hours 03, 13, 23 (3 options) * 10 minutes = 30
    public int CountTimeCombinations_ValidPatterns_ReturnsCorrectCount(string input)
    {
        return _counter.CountTimeCombinations(input);
    }

    // Invalid formats — should throw ArgumentException

    [TestCase("25:00")]    // hour > 23
    [TestCase("1:00")]     // missing leading zero
    [TestCase("13-00")]    // invalid separator
    [TestCase("??:6a")]    // invalid character
    [TestCase("2?:7?0aaadwdasadsfdekdfeidjksjjkdhksjdowjdkfksdljsjhskdjsldjksjdjksjhd")]   // too long
    [TestCase("")]         // empty
    public void CountTimeCombinations_InvalidInput_ThrowsArgumentException(string input)
    {
        var ex = Assert.Throws<ArgumentException>(() => _counter.CountTimeCombinations(input));
        StringAssert.Contains("required format", ex.Message);
    }
    
    [Test]
    public void CountTimeCombinations_NullInput_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _counter.CountTimeCombinations(null));
    }
}