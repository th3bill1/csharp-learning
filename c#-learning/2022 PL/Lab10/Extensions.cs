using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharplearning._2022PL.Lab10
{
    internal class NDimMatrix<T>
    {
        public Array _array;
        public NDimMatrix(Array array)
        {
            _array = array;
        }
        public NDimMatrix<T> this[params Range[] ranges]
        {
            get
            {
                int[] dims = new int[ranges.Length];
                var i = 0;
                foreach (var range in ranges) dims[i] = range.GetOffsetAndLength(_array.GetLength(i++)).ToTuple().Item2;
                Array value = Array.CreateInstance(typeof(T), dims);
                GetArrayRanged(_array, value, Array.Empty<int>(), Array.Empty<int>(), ranges);
                return new NDimMatrix<T>(value);
            }
            set { ModifyArrayRanged(value._array, Array.Empty<int>(), Array.Empty<int>(),ranges); }
        }
        public static void GetArrayRanged(Array _array, Array a, int[] original_array_indices, int[] new_array_indices, params Range[] ranges)
        {
            (int mOffset, int mLength) = ranges[0].GetOffsetAndLength(_array.GetLength(0));
            if (ranges.GetLength(0) == 1)
            {
                for (int i = mOffset; i < mOffset + mLength; i++)
                {
                    a.SetValue(_array.GetValue(CreateIndices(original_array_indices, i)), CreateIndices(new_array_indices, i - mOffset));
                }
            }
            else
                for (int i = mOffset; i < mOffset + mLength; i++)
                {
                    GetArrayRanged(_array, a, CreateIndices(original_array_indices, i), CreateIndices(new_array_indices, i - mOffset), ranges[1..]);
                }
        }
        public static int[] CreateIndices(int[] old_array, int new_index)
        {
            int[] new_array = new int[old_array.Length + 1];
            old_array.CopyTo(new_array, 0);
            new_array[^1] = new_index;
            return new_array;
        }
        public void ModifyArrayRanged(Array a, int[] original_array_indices, int[] new_array_indices, params Range[] ranges)
        {
            (int mOffset, int mLength) = ranges[0].GetOffsetAndLength(_array.GetLength(0));
            if (ranges.GetLength(0) == 1)
            {
                for (int i = mOffset; i < mOffset + mLength; i++)
                {
                    _array.SetValue(a.GetValue(CreateIndices(new_array_indices, i - mOffset)), CreateIndices(original_array_indices, i));
                }
            }
            else for (int i = mOffset; i < mOffset + mLength; i++)
                {
                    ModifyArrayRanged(a, CreateIndices(original_array_indices, i), CreateIndices(new_array_indices, i - mOffset), ranges[1..]);
                }
        }
    }
    internal static class ExtensionMethods
    {
        public static T Max<T>(this NDimMatrix<T> matrix)
        {
            return matrix._array.Cast<T>().Max();
        }
        public static T Min<T>(this NDimMatrix<T> matrix)
        {
            return matrix._array.Cast<T>().Min();
        }
        public static T[] Flatten<T>(this NDimMatrix<T> matrix)
        {
            return matrix._array.Cast<T>().ToArray();
        }
    }
}
