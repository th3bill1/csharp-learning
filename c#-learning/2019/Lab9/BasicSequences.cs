using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharplearning._2019.Lab9
{
    internal interface ISequence : IEnumerable<int>
    {
        string Description();
    }
    internal class Repeat : ISequence
    {
        readonly int value;
        readonly int count;
        public Repeat(int value, int count)
        {
            this.value = value;
            this.count = count;
        }
        public string Description() => $"Repeat({value},{count})";
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return value;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
    abstract class Sequence
    {
        protected readonly int initial;
        protected readonly int step;
        public Sequence(int initial, int step)
        {
            this.initial = initial;
            this.step = step;
        }
    }
    internal class ArithmeticProgression : Sequence, ISequence
    {
        public ArithmeticProgression(int initial, int step = 1) : base(initial, step) { }
        public string Description() => $"ArithmeticProgression({initial},{step})";
        public IEnumerator<int> GetEnumerator()
        {
            int current = initial;
            while (true)
            {
                yield return current;
                current += step;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
    internal class GeometricProgression : Sequence, ISequence
    {
        public GeometricProgression(int initial, int step = 1) : base(initial, step) { }
        public string Description() => $"GeometricProgression({initial},{step})";
        public IEnumerator<int> GetEnumerator()
        {
            int current = initial;
            while (true)
            {
                yield return current;
                current *= step;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
    internal class PowersOf : GeometricProgression, ISequence
    {
        public PowersOf(int value) : base(value) { }
        public new string Description() => $"PowersOf({initial})";
        public new IEnumerator<int> GetEnumerator()
        {
            int current = 1;
            while (true)
            {
                yield return current;
                current *= initial;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}