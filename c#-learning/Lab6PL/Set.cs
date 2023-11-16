using System.Text;

namespace csharplearning.Lab6PL
{
    internal class Set
    {
        private int[] values;
        public Set(params int[] _values) => values = _values.Distinct().ToArray();
        public override string ToString() => values.Length>0 ? $"{{{string.Join(",", values)}}}" : "{}";
        public int GetElementsArrayCapacity() => values.Length;
        public static Set operator +(Set a, Set b) => new((from n in a.values.Union(b.values) select n).ToArray());
        public static Set operator -(Set a, Set b) => new((from n in a.values where !b.values.Contains(n) select n).ToArray());
        public static bool operator true(Set a) => a.values.Length > 0;
        public static bool operator false(Set a) => a.values.Length == 0;
        public static Set operator &(Set a, Set b) => new((from n in a.values where b.values.Contains(n) select n).ToArray());
        public static Set operator |(Set a, Set b) => a + b;
        public static bool operator ==(Set a, Set b) => a.values.All(b.values.Contains) && b.values.All(a.values.Contains);
        public static bool operator !=(Set a, Set b) => !(a == b);
    }
}