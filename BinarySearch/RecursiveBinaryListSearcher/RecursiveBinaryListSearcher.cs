namespace RecursiveBinaryListSearcher
{
    using System;
    using System.Collections.Generic;
    using IListSearcher;

    public class RecursiveBinaryListSearcher<T> : IListSearcher<T> where T : IComparable
    {
        private int SearchRecursively(IList<T> list, T key, int lowerIndex, int upperIndex)
        {
            if (lowerIndex > upperIndex)
            {
                return -(lowerIndex + 1);
            }

            var index = lowerIndex + (upperIndex - lowerIndex) / 2;
            var compare = key.CompareTo(list[index]);

            if (compare < 0)
            {
                index = this.SearchRecursively(list, key, lowerIndex, index - 1);
            }
            else if (compare > 0)
            {
                index = this.SearchRecursively(list, key, index + 1, upperIndex);
            }

            return index;
        }

        public int Search(IList<T> list, T key)
        {
            return this.SearchRecursively(list, key, 0, list.Count - 1);
        }
    }
}
