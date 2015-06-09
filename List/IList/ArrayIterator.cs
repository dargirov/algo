using System;
using System.Collections.Generic;

namespace List
{
    public class ArrayIterator<T> : IIterator<T>
    {
        private T[] array;
        private int first;
        private int last;
        private int current = -1;

        public ArrayIterator(T[] array, int start, int length)
        {
            this.array = array;
            this.first = start;
            this.last = start + length - 1;
        }

        public void First()
        {
            this.current = this.first;
        }

        public void Last()
        {
            this.current = this.last;
        }

        public bool IsDone()
        {
            return this.current < this.first || this.current > this.last;
        }

        public void Next()
        {
            this.current++;
        }

        public void Previous()
        {
            this.current--;
        }

        public T Current()
        {
            if (this.IsDone())
            {
                throw new IndexOutOfRangeException();
            }

            return this.array[this.current];
        }
    }
}
