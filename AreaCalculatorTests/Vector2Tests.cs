using AreaСalculatorLibrary;
using FluentAssertions;
using NUnit.Framework;

namespace AreaCalculatorTests;

[TestFixture]
public class Vector2Tests
{
    private const double Tolerance = 1e-6;

    [TestCase(0, 0, 1, 1, 0, TestName = "dot product on (0, 0) should be (0, 0)")]
    [TestCase(0, 1, 1, 0, 0, TestName = "orthogonal")]
    [TestCase(0.1, -0.1, 2, 3, -0.1, TestName = "random")]
    public void DotProductTest(double x1, double y1, double x2, double y2, double expected)
    {
        var vector1 = new Vector2(x1, y1);
        var vector2 = new Vector2(x2, y2);
        var result = vector1 * vector2;
        result.Should().BeApproximately(expected, Tolerance);
    }


    [TestCase(0, 0, 1, 1, 0, TestName = "cross product on (0, 0) should be (0, 0)")]
    [TestCase(1, 0, 0, 1, 1, TestName = "square area")]
    [TestCase(0.1, -0.2, 0.4, 0.7, 0.15, TestName = "random")]
    public void CrossProductTests(double x1, double y1, double x2, double y2, double expected)
    {
        var vector1 = new Vector2(x1, y1);
        var vector2 = new Vector2(x2, y2);
        var result = vector1 ^ vector2;
        result.Should().BeApproximately(expected, Tolerance);
    }
}