using System;
using System.Collections.Generic;

using IListSorter;

namespace Insertion
{
    public class InsertionSortList<T> : IListSorter<T> where T : IComparable
    {
        public IList<T> Sort(IList<T> list)
        {
            var result = new List<T>();

            foreach (var elem in list)
            {
                int slot = result.Count;
                if (slot > 0)
                {
                    while (slot > 0)
                    {
                        if (elem.CompareTo(result[slot - 1]) >= 0)
                        {
                            break;
                        }

                        slot--;
                    }
                }

                result.Insert(slot, elem);
            }

            return result;
        }
    }
}
