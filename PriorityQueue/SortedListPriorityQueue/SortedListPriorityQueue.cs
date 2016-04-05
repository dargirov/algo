namespace SortedListPriorityQueue
{
    using System;
    using System.Collections.Generic;
    using IQueue;

    public class SortedListPriorityQueue<T> : IQueue<T> where T : IComparable
    {
        private List<T> list;

        public SortedListPriorityQueue()
        {
            this.list = new List<T>();
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            var index = this.GetSize() - 1;
            var result = this.list[index];
            this.list.RemoveAt(index);
            return result;
        }

        public void Enqueue(T value)
        {
            int pos = this.GetSize();
            while (pos > 0 && this.list[pos - 1].CompareTo(value) > 0)
            {
                pos--;
            }

            this.list.Insert(pos, value);
        }

        public int GetSize()
        {
            return this.list.Count;
        }

        public bool IsEmpty()
        {
            return this.GetSize() == 0;
        }
    }
}
