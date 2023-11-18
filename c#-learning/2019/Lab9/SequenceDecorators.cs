using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharplearning._2019.Lab9
{
    internal interface ISequenceDecorator : IEnumerable<int>
    {
        string Description();
        IEnumerable<int> Decorate(System.Collections.IEnumerable sequence);
    }
    internal class SequenceSum : ISequenceDecorator
    {
        public string Description() => "SequenceSum()";
        public IEnumerable<int> Decorate(System.Collections.IEnumerable sequence)
        {
            int sum = 0;
            foreach (int value in sequence.Cast<int>())
            {
                sum += value;
                yield return sum;
            }
        }
        public IEnumerator<int> GetEnumerator() => throw new NotImplementedException();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
    internal class LessThanFilter : ISequenceDecorator
    {
        int limit;
        bool memory;
        public LessThanFilter(int limit, bool memory = false)
        {
            this.limit = limit;
            this.memory = memory;

        }
        public string Description() => $"LessThanFilter({limit},{memory})";
        public IEnumerable<int> Decorate(System.Collections.IEnumerable sequence)
        {
            if (memory)
            {
                int last = int.MaxValue;
                foreach (int value in sequence.Cast<int>())
                {
                    if (value < limit)
                    {
                        last = value;
                        yield return value;
                    }
                    else if (last == int.MaxValue) continue;
                    else yield return last;
                }
            }
            else
            {
                foreach (int value in sequence)
                    if (value < limit)
                        yield return value;
            }
        }
        public IEnumerator<int> GetEnumerator() => throw new NotImplementedException();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
    internal class MedianFilter : ISequenceDecorator
    {
        int filterSize;
        public MedianFilter(int filterSize) => this.filterSize = filterSize;
        public string Description() => $"MedianFilter({filterSize})";
        public IEnumerable<int> Decorate(System.Collections.IEnumerable sequence)
        {

            int[] array = sequence.Cast<int>().Take(1000).ToArray(); //takes 1000 is stinky, probably should be changed
            int[] temp = new int[filterSize];
            int i = 0;
            Console.WriteLine(i);
            while (i<array.Length)
            {
                for (int j = 0; j < filterSize; j++)
                {
                    if (i < array.Length)
                    { 
                        temp[j] = array[i];
                        i++;
                    }
                    else break;
                }
                Array.Sort(temp);
                
                yield return filterSize % 2 == 0 ? temp[filterSize / 2 ] : temp[filterSize / 2];
            }
        }
        public IEnumerator<int> GetEnumerator() => throw new NotImplementedException();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
/*
 Notes:
- For each sequence class, use yield operator to implement IEnumerable interface.
- In whole tasks use int as a numeric type.
- All classes and interfaces define inside EN_Lab_09 namespace

Stage 3 [1.5]
In file AdvancedSequences.cs create interface ISequenceCombine.
The interface should methods:
 * string Description(), that returns description of sequence.
 * IEnumerable Combine(IEnumerable, IEnumerable), that combines two enumerables.

In file AdvancedSequences.cs create class CantorPair that implements interface ISequenceCombine.
 * Implement method Description, that returns name of class with parameters which where given in contructor,
   e.g. "CantorPair".
 * Implement method Combine, that creates Cantor pairs from two infinite series.
 
 Cantor pairs are created by going through next diagonals in matrix created by combining two series.
 For an example, by combining two series of natural numbers we will get a matrix:
  |   0  |   1  |   2  |   3  |   4  | ...
 0|(0, 0) (0, 1) (0, 2) (0, 3) (0, 4)  ...
 1|(1, 0) (1, 1) (1, 2) (1, 3) (1, 4)  ...
 2|(2, 0) (2, 1) (2, 2) (2, 3) (2, 4)  ...
 3|(3, 0) (3, 1) (3, 2) (3, 3) (3, 4)  ...
 4|(4, 0) (4, 1) (4, 2) (4, 3) (4, 4)  ...

 On a matrix created this way, we go through next diagonals starting with a diagonal going through point (0, 0).
 So the next items in the series will be taken from the matrix in this way.
  | 0 | 1 | 2 | 3 | 4 | ...
 0|#01 #03 #06 #10 #15
 1|#02 #05 #09 #14 ...
 2|#04 #08 #13 ... ... 
 3|#07 #12 ... ... ...
 4|#11 ... ... ... ...

Use collection List<> for storing previous visited elements.
yield in Combine() should return tuples of two objects.

Stage 4 [1.0]
Improve CantorPair so it will support finite series.
If one of series ends, go through rest of elements using the same diagonal pattern.
For an example, if we take arrays [0, 1, 2] and [0, 1, 2, 3, 4], next items in the series will be:
  | 0 | 1 | 2 | 3 | 4 |
 0|#01 #03 #06 #09 #12
 1|#02 #05 #08 #11 #14
 2|#04 #07 #10 #13 #15*/