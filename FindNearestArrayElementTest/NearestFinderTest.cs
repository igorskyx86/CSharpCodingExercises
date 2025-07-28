using NUnit.Framework;
using NUnit.Framework.Legacy;
using ConsoleApp1;
namespace FindNearestArrayElementTest;

public class Tests
{
    
    // Normal behavior
    [TestCase(new[] { 1, 3, 7, 10 }, 5, ExpectedResult = 3)]
    [TestCase(new[] { 1, 3, 7, 10 }, 9, ExpectedResult = 10)]
    [TestCase(new[] { 1, 3, 5, 6 }, 4, ExpectedResult = 3)]
    [TestCase(new[] { 1, 3, 5, 6 }, 5, ExpectedResult = 5)]
    [TestCase(new[] { 1, 3, 5, 6 }, 6, ExpectedResult = 6)]

    // Tie-breaking: return smaller value
    [TestCase(new[] { 1, 4 }, 2, ExpectedResult = 1)]
    [TestCase(new[] { 2, 5 }, 3, ExpectedResult = 2)]

    // Edge: target is smaller or larger than all elements
    [TestCase(new[] { 10, 20, 30 }, 5, ExpectedResult = 10)]
    [TestCase(new[] { 10, 20, 30 }, 40, ExpectedResult = 30)]

    public int FindNearest_ValidInputs_ReturnsClosest(int[] array, int target)
    {
        return NearestFinder.FindNearest(array, target);
    }

    // Null input
    [Test]
    public void FindNearest_NullArray_ThrowsArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(() =>
            NearestFinder.FindNearest(null, 10));
        StringAssert.Contains("array", ex.ParamName);
    }

    // Empty array
    [Test]
    public void FindNearest_EmptyArray_ThrowsArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() =>
            NearestFinder.FindNearest(new int[0], 10));
        StringAssert.Contains("Input array cannot be empty", ex.Message);
    }
}