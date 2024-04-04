using AreaСalculatorLibrary;
using FluentAssertions;
using NUnit.Framework;

namespace AreaCalculatorTests;

[TestFixture]
public class TriangleTests
{
    private const double Tolerance = 1e-6;

    [TestCase(1, 1, 100)]
    [TestCase(1, 100, 1)]
    [TestCase(100, 1, 1)]
    public void Triangle_ShouldThrowException_WhenTriangleDoesNotExist(double a, double b, double c)
    {
        var act = () => new Triangle(a, b, c);
        act.Should().Throw<ArgumentException>();
    }

    [TestCase(-1, 0, 0)]
    [TestCase(0, 0, 0)]
    public void Triangle_ShouldThrowException_WhenSidesLessOrEqualsZero(double a, double b, double c)
    {
        var act = () => new Triangle(a, b, c);
        act.Should().Throw<ArgumentException>();
    }


    [TestCase(1, 1, 1.41421356237, 0.5, TestName = "right triangle")]
    [TestCase(1, 1, 1, 0.4330127019, TestName = "equilateral triangle")]
    [TestCase(1.1, 2, 3, 0.55878775, TestName = "ordinary triangle")]
    public void CalculateArea_ShouldCalculateArea_WithCurrentPrecision(double a, double b, double c, double expected)
    {
        var triangle = new Triangle(a, b, c);

        var result = triangle.CalculateArea();

        result.Should().BeApproximately(expected, Tolerance);
    }
}