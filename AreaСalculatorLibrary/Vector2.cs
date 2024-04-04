namespace AreaСalculatorLibrary;

public class Vector2
{
    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    // сложение векторов
    public static Vector2 operator +(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    }

    // вычитание векторов
    public static Vector2 operator -(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
    }

    // умножение на число
    public static Vector2 operator *(Vector2 v, double scalar)
    {
        return new Vector2(v.X * scalar, v.Y * scalar);
    }

    // скалярное умножение
    public static double operator *(Vector2 v1, Vector2 v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y;
    }

    // векторное умножение, возвращает вектор в плоскости Oz
    public static double operator ^(Vector2 v1, Vector2 v2)
    {
        return v1.X * v2.Y - v1.Y * v2.X;
    }
}