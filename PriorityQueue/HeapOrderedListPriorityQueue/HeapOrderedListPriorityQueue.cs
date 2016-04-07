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

            if (leftIndex >= this.GetSize())
            {
                return;
            }

            int largest = leftIndex;
            if (rightIndex < this.GetSize())
            {
                if (this.list[rightIndex].CompareTo(this.list[leftIndex]) > 0)
                {
                    largest = rightIndex;
                }
            }
            
            if (this.list[index].CompareTo(this.list[largest]) < 0)
            {
                this.Swap(index, largest);
                this.Sink(largest);
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
