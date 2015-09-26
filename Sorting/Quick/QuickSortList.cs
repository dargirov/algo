using System;
using System.Collections.Generic;
using IListSorter;

namespace Quick
{
    public class QuickSortList<T> : IListSorter<T> where T : IComparable
    {
        public QuickSortList()
        {
        }

        public IList<T> Sort(IList<T> list)
        {
            QuickSort(list, 0, list.Count - 1);
            return list;
        }

        private void QuickSort(IList<T> list, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex)
            {
                return;
            }

            if (startIndex < 0 || endIndex >= list.Count)
            {
                return;
            }

            T value = list[endIndex];
            int partition = Partition(list, value, startIndex, endIndex - 1);
            if (list[partition].CompareTo(value) < 0)
            {
                partition++;
            }

            Swap(list, partition, endIndex);

            QuickSort(list, startIndex, partition - 1);
            QuickSort(list, partition + 1, endIndex);
        }

        private int Partition(IList<T> list, T value, int left, int right)
        {
            while (left < right)
            {
                if (list[left].CompareTo(value) < 0)
                {
                    left++;
                    continue;
                }

                if (list[right].CompareTo(value) >= 0)
                {
                    right--;
                    continue;
                }

                Swap(list, left, right);
                left++;
            }

            return left;
        }

        private void Swap(IList<T> list, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            T temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
