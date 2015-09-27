using System;
using System.Collections.Generic;
using IListSorter;

namespace Merge
{
    public class MergeSortList<T> : IListSorter<T> where T : IComparable
    {
        public IList<T> Sort(IList<T> list)
        {
            return MergeSort(list, 0, list.Count - 1);
        }

        private IList<T> MergeSort(IList<T> list, int start, int end)
        {
            if (start == end)
            {
                var result = new List<T>();
                result.Add(list[start]);
                return result;
            }

            int split = start + (end - start) / 2;

            var left = MergeSort(list, start, split);
            var right = MergeSort(list, split + 1, end);

            return Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            var result = new List<T>();

            int leftCount = left.Count;
            int rightCount = right.Count;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftCount || rightIndex < rightCount)
            {
                if (leftIndex >= leftCount)
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
                else if (rightIndex >= rightCount)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return result;
        }
    }
}
