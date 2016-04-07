namespace HeapOrderedListPriorityQueue
{
    using System;
    using System.Collections.Generic;
    using IQueue;

    public class HeapOrderedListPriorityQueue<T> : IQueue<T> where T : IComparable
    {
        private List<T> list;

        public HeapOrderedListPriorityQueue()
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

            var top = this.list[0];

            if (this.GetSize() == 1)
            {
                this.list.Clear();
                return top;
            }

            var last = this.list[this.GetSize() - 1];
            this.list[0] = last;
            this.list.RemoveAt(this.GetSize() - 1);
            this.Sink(0);

            return top;
        }

        private void Sink(int index)
        {
            var rightIndex = (2 * index) + 2;
            var leftIndex = (2 * index) + 1;

            if (rightIndex < this.GetSize())
            {
                var right = this.list[rightIndex];
                var left = this.list[leftIndex];
                var bigger = leftIndex;
                if (right.CompareTo(left) > 0)
                {
                    bigger = rightIndex;
                }

                if (this.list[index].CompareTo(this.list[bigger]) < 0)
                {
                    this.Swap(index, bigger);
                    this.Sink(bigger);
                }
            }
            else if (leftIndex < this.GetSize())
            {
                var left = this.list[leftIndex];
                if (this.list[index].CompareTo(this.list[leftIndex]) < 0)
                {
                    this.Swap(index, leftIndex);
                    this.Sink(leftIndex);
                }
            }
        }

        public void Enqueue(T value)
        {
            var index = this.list.Count;
            this.list.Add(value);

            if (index == 0)
            {
                return;
            }

            this.Swim(index);
        }

        private void Swim(int index)
        {
            int parentIndex = (index - 1) / 2;
            if (this.list[index].CompareTo(this.list[parentIndex]) > 0)
            {
                this.Swap(index, parentIndex);
                this.Swim(parentIndex);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.list[parentIndex];
            this.list[parentIndex] = this.list[index];
            this.list[index] = temp;
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
