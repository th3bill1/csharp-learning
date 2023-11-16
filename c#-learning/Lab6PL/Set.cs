using System.Text;

namespace csharplearning.Lab6PL
{
    internal class Set
    {
        private int[] values;
        public Set(params int[] _values)
        {
            values = _values.Distinct().ToArray();
        }
        public override string ToString()
        {
            if (values.Length == 0) return "{}";
            StringBuilder sb = new("{");
            for (int i = 0; i < values.Length - 1; i++) sb.Append(values[i] + ",");
            sb.Append(values[^1] + "}");
            return sb.ToString();
        }
        public int GetElementsArrayCapacity() => values.Length;
        public static Set operator +(Set a, Set b)
        {
            int[] result = new int[a.values.Length + b.values.Length];
            a.values.CopyTo(result, 0);
            b.values.CopyTo(result, a.values.Length);
            return new Set(result);
        }
        public static Set operator -(Set a, Set b)
        {
            List<int> result = new();
            foreach (int i in a.values) if (!b.values.Contains(i)) result.Add(i);
            return new Set(result.ToArray());
        }
        public static bool operator true(Set a) => a.values.Length > 0;
        public static bool operator false(Set a) => a.values.Length == 0;
        public static Set operator &(Set a, Set b)
        {
            List<int> result = new();
            foreach (int value in a.values) if (b.values.Contains(value)) result.Add(value);
            return new Set(result.ToArray());
        }
        public static Set operator |(Set a, Set b) => a + b;
        public static bool operator ==(Set a, Set b) => a.values.All(b.values.Contains) && b.values.All(a.values.Contains);
        public static bool operator !=(Set a, Set b) => !(a == b);
    }
}