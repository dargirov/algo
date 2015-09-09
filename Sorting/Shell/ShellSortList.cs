using System;
using System.Collections.Generic;
using IListSorter;

namespace Shell
{
    public class ShellSortList<T> : IListSorter<T> where T : IComparable
    {
        private int[] h = { 121, 40, 13, 4, 1 };

        public ShellSortList()
        {
        }

        public IList<T> Sort(IList<T> list)
        {
            foreach (var gap in this.h)
            {
                for (int i = gap, j = 0; i < list.Count; i++)
                {
                    var current = list[i];
                    for (j = i; j >= gap && current.CompareTo(list[j - gap]) < 0; j -= gap)
                    {
                        list[j] = list[j - gap];
                    }

                    list[j] = current;
                }
            }

            return list;
        }
    }
}
