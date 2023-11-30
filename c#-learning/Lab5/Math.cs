namespace csharplearning.Lab5
{
    struct Vector2
    {
        public float x, y;
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"Point({x}, {y})";
        }
        static public Vector2 Add(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
    }
    struct BoundingBox
    {
        Vector2 min;
        Vector2 max;

        public override string ToString()
        {
            return $"Minimum {min}, Maximum {max}";
        }
        public BoundingBox(Vector2 min, Vector2 max)
        {
            this.min = min;
            this.max = max;
        }
        public static BoundingBox TotalBounding(BoundingBox a, BoundingBox b)
        {
            float min_x = Math.Min(a.min.x, b.min.x);
            float min_y = Math.Min(a.min.y, b.min.y);
            float max_x = Math.Max(a.max.x, b.max.x);
            float max_y = Math.Max(a.max.y, b.max.y);
            Vector2 min = new Vector2(min_x, min_y);
            Vector2 max = new Vector2(max_x, max_y);
            return new BoundingBox(min, max);
        }
    }
}
