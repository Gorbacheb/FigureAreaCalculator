using AreaСalculatorLibrary;
using FluentAssertions;
using NUnit.Framework;

namespace AreaCalculatorTests;

[TestFixture]
public class PolygonTests
{
    private const double Tolerance = 1e-6;

    [TestCaseSource(nameof(DivideCases))]
    public void CalculateArea_ShouldCalculateArea_WithPrecision(List<Vector2> points, double expected)
    {
        var polygon = new Polygon(points);

        var result = polygon.CalculateArea();

        result.Should().BeApproximately(expected, Tolerance);
    }

    public static object[] DivideCases =
    {
        new object[] { new List<Vector2> { new(0, 0), new(0, 1), new(1, 1), new(1, 0) }, 1 },
        new object[] { new List<Vector2> { new(1, 1), new(1, 3), new(3, 3), new(3, 1), new(2, 0) }, 5 },
        new object[] { new List<Vector2> { new(1, 1), new(1, 3), new(3, 3), new(3, 1), new(2, 2) }, 3 },
        new object[] { new List<Vector2> { new(0, 0), new(1, 10), new(1, 0) }, 5 }
    };


    [Test]
    public void Circle_ShouldThrowException_WhenPointsLessThenThree()
    {
        var act = () => new Polygon([new Vector2(0, 0), new Vector2(1, 0)]);
        act.Should().Throw<ArgumentException>();
    }
}