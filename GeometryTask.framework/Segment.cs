namespace GeometryTasks
{
    public class Segment
    {
        public Vector Begin;

        public Vector End;

        public double GetLength(Segment segment)
        {
            return Geometry.GetLength(segment);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}