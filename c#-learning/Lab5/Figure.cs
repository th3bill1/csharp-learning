namespace csharplearning.Lab5
{

    abstract class Figure
    {
        private static int figures_count = 0;
        private int children_count = 0;
        private Vector2 _position;
        Figure[] _children;
        Figure _parent;
        public int id;
        public Figure(Vector2 position)
        {
            _children = new Figure[2];
            _position = position;
            id = figures_count++;
        }
        public Vector2 GetRelativePosition()
        {
            return _position;
        }
        public void AddChild(Figure child)
        {
            if (children_count == _children.Length)
            {
                Array.Resize(ref _children, children_count * 2);
            }
            _children[children_count++] = child;
            child._parent = this;
        }
        public string GetTreeString(int level = 0)
        {
            string value = "";
            value += ToString();
            level++;
            foreach (Figure child in _children)
            {
                if (child != null)
                {
                    value += "\n";
                    for (int i = 0; i < level; i++) value += "\t";
                    value += child.GetTreeString(level);
                }

            }
            return value;
        }
        public int GetMaxNumberOfChildren()
        {
            return _children.Length;
        }
        public void Move(Vector2 vector)
        {
            _position = Vector2.Add(vector, _position);
        }
        public Vector2 GetGlobalPosition()
        {
            Vector2 vector = _position;
            if (_parent != null)
            {
                vector = Vector2.Add(vector, _parent.GetGlobalPosition());
            }
            return vector;
        }
        public abstract BoundingBox GetFigureBoundingBox();

        public BoundingBox CalculateBoundingBox()
        {
            BoundingBox box = GetFigureBoundingBox();
            foreach (Figure child in _children)
            {
                if (child != null)
                {
                    box = BoundingBox.TotalBounding(box, child.GetFigureBoundingBox());
                }
            }
            return box;
        }
    }
    class Circle : Figure
    {
        float _radius;
        public override string ToString()
        {
            return $"Circle ID {id}: Position in {GetGlobalPosition()}, Radius={_radius}";
        }
        public Circle(Vector2 position, float radius) : base(position)
        {
            _radius = radius;
        }
        public override BoundingBox GetFigureBoundingBox()
        {
            Vector2 min = new Vector2(GetRelativePosition().x - _radius, GetRelativePosition().y - _radius);
            Vector2 max = new Vector2(GetRelativePosition().x + _radius, GetRelativePosition().y + _radius);
            return new BoundingBox(min, max);
        }
    }
    class Triangle : Figure
    {
        Vector2[] vertices;
        public override string ToString()
        {
            return $"Triangle ID {id}: Position in {GetGlobalPosition()}, Vertices in {vertices[0]},{vertices[1]},{vertices[2]}";
        }
        public Triangle(Vector2 position, Vector2 vertice1, Vector2 vertice2, Vector2 vertice3) : base(position)
        {
            vertices = new Vector2[3];
            vertices[0] = vertice1;
            vertices[1] = vertice2;
            vertices[2] = vertice3;
        }
        public override BoundingBox GetFigureBoundingBox()
        {
            float min_x = Math.Min(vertices[0].x, Math.Min(vertices[1].x, vertices[2].x));
            float min_y = Math.Min(vertices[0].y, Math.Min(vertices[1].y, vertices[2].y));
            float max_x = Math.Max(vertices[0].x, Math.Max(vertices[1].x, vertices[2].x));
            float max_y = Math.Max(vertices[0].y, Math.Max(vertices[1].y, vertices[2].y));
            Vector2 min = new(min_x, min_y);
            Vector2 max = new(max_x, max_y);
            return new BoundingBox(min, max);
        }
    }
}
