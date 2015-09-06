using System;
using System.Collections.Generic;

using IListSorter;

namespace Selection
{
    public class SelectionSortList<T> : IListSorter<T> where T : IComparable
    {
        public IList<T> Sort(IList<T> list)
        {
            int size = list.Count;

            for (int i = 0; i < size - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (list[j].CompareTo(list[smallest]) < 0)
                    {
                        smallest = j;
                    }
                }

                this.Swap(list, i, smallest);
            }

            return list;
        }

        private void Swap(IList<T> list, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            var temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
