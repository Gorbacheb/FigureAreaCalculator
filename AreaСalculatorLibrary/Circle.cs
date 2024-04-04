namespace AreaСalculatorLibrary;

public class Circle : IFigure
{
    public double Radius;

    public Circle(double radius)
    {
        if (radius < 0) throw new ArgumentException("radius cannot be less then zero");
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}