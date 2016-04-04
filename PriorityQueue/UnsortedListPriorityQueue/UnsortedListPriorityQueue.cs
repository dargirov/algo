namespace UnsortedListPriorityQueue
{
    using System;
    using System.Collections.Generic;
    using IQueue;

    public class UnsortedListPriorityQueue<T> : IQueue<T> where T : IComparable
    {
        private List<T> list;

        public UnsortedListPriorityQueue()
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

            var index = this.GetIndexOfLargestElement();
            var result = this.list[index];
            this.list.RemoveAt(index);
            return result;
        }

        private int GetIndexOfLargestElement()
        {
            int result = 0;

            for (int i = 1; i < this.GetSize(); i++)
            {
                if (this.list[i].CompareTo(this.list[result]) > 0)
                {
                    result = i;
                }
            }

            return result;
        }

        public void Enqueue(T value)
        {
            this.list.Add(value);
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
