using IQueue;
using System;
using System.Collections.Generic;

namespace ListQueue
{
    public class ListQueue<T>: IQueue<T>
    {
        private LinkedList<T> list;

        public ListQueue()
        {
            this.list = new LinkedList<T>();
        }

        public void enqueue(T value)
        {
            this.list.AddLast(value);
        }

        public T dequeue()
        {
            if (this.list.Count == 0)
            {
                throw new IndexOutOfRangeException("Cant dequeue from empty queue");
            }

            var value = this.list.First.Value;
            this.list.RemoveFirst();
            return value;
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public bool IsEmpty()
        {
            return this.GetSize() == 0;
        }

        public int GetSize()
        {
            return this.list.Count;
        }
    }
}
