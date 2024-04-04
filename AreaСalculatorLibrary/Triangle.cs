namespace AreaСalculatorLibrary;

public class Triangle : Polygon
{
    public readonly double LowestSide;
    public readonly double MaxSide;
    public readonly double MiddleSide;


    public Triangle(double a, double b, double c) : base(ConvertSidesToVectorList(a, b, c))
    {
        if (a <= 0 || b <= 0 || c <= 0) throw new ArgumentException("a, b, c must be more then zero");
        MaxSide = Math.Max(a, Math.Max(b, c));
        LowestSide = Math.Min(a, Math.Min(b, c));
        MiddleSide = a + b + c - MaxSide - LowestSide;

        if (LowestSide + MiddleSide <= MaxSide) throw new ArgumentException("this sides cannot be a triangle");
    }

    public static List<Vector2> ConvertSidesToVectorList(double a, double b, double c)
    {
        var angleA = Math.Acos((a * a + c * c - b * b) / (2 * a * c));
        var point1 = new Vector2(0, 0);
        var point2 = new Vector2(a, 0);
        var point3 = new Vector2(c * Math.Cos(angleA), c * Math.Sin(angleA));
        return [point1, point2, point3];
    }

    public bool IsRightTriangle(double tolerance)
    {
        return Math.Abs(LowestSide * LowestSide + MiddleSide * MiddleSide - MaxSide * MaxSide) < tolerance;
    }
}