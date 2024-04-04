using AreaСalculatorLibrary;
using FluentAssertions;
using NUnit.Framework;

namespace AreaCalculatorTests;

[TestFixture]
public class CircleTests
{
    private const double Tolerance = 1e-6;

    [Test]
    public void Circle_ShouldThrowException_WhenRadiusLessThenZero()
    {
        var act = () => new Circle(-1);
        act.Should().Throw<ArgumentException>();
    }


    [TestCase(0, 0, TestName = "circle area with 0 radius should be 0")]
    [TestCase(1, Math.PI, TestName = "circle area with 1 radius should be PI")]
    [TestCase(0.1, Math.PI * 0.1 * 0.1, TestName = "circle area with 0.1 radius")]
    public void CalculateArea_ShouldCalculateArea_WithCurrentPrecision(double radius, double expected)
    {
        var circle = new Circle(radius);

        var result = circle.CalculateArea();

        result.Should().BeApproximately(expected, Tolerance);
    }
}