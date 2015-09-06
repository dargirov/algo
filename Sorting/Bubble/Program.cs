using System;
using System.Collections;
using System.Collections.Generic;

using IListSorter;

namespace Bubble
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class Bubble<T> : IListSorter<T> where T : IComparable
    {

        public IList<T> Sort(IList<T> list)
        {
            int size = list.Count;

            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < size - i; j++)
                {
                    var left = list[j];
                    var right = list[j + 1];
                    if (left.CompareTo(right) > 0)
                    {
                        this.Swap(list, j, j + 1);
                    }
                }
            }

            return list;
        }

        private void Swap(IList<T> list, int left, int right)
        {
            var temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}