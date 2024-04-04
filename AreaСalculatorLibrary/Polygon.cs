namespace AreaСalculatorLibrary;

public class Polygon : IFigure
{
    public Polygon(List<Vector2> vertices)
    {
        if (vertices.Count < 3) throw new ArgumentException("vertices count must be more then 2");
        Vertices = vertices;
    }

    public List<Vector2> Vertices { get; }

    public double CalculateArea()
    {
        var n = Vertices.Count;
        double area = 0;

        for (var i = 0; i < n; i++)
        {
            var currentVertex = Vertices[i];
            var nextVertex = Vertices[(i + 1) % n];

            area += currentVertex ^ nextVertex;
        }

        area /= 2;
        return Math.Abs(area);
    }
}