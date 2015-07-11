using System;
using System.Collections.Generic;
using IStack;

namespace ListStack
{
    public class ListStack<T>: IStack<T>
    {
        private LinkedList<T> list;

        public ListStack()
        {
            this.list = new LinkedList<T>();
        }

        public void Push(T value)
        {
            this.list.AddLast(value);
        }

        public T Pop()
        {
            if (this.GetSize() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var result = this.list.Last.Value;
            this.list.RemoveLast();
            return result;
        }

        public T Peek()
        {
            var result = this.Pop();
            this.Push(result);
            return result;
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public int GetSize()
        {
            return this.list.Count;
        }

        public bool IsEmpty()
        {
            return this.list.Count == 0;
        }
    }
}
