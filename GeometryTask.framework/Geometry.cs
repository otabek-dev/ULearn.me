using System;

namespace GeometryTasks
{
    public class Geometry
    {
        //возвращает длину переданного вектора
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
        }

        public static double GetLength(Segment segment)
        {
            return Math.Sqrt(
                Math.Pow((segment.Begin.X - segment.End.X), 2) +
                Math.Pow((segment.Begin.Y - segment.End.Y), 2));
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            var result =
            GetLength(new Segment
            {
                Begin = new Vector { X = segment.Begin.X, Y = segment.Begin.Y },
                End = vector
            }) +
            GetLength(new Segment
            {
                Begin = vector,
                End = new Vector { X = segment.End.X, Y = segment.End.Y }
            });

            return result == GetLength(segment) ? true : false;
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            return new Vector() { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
    }
}