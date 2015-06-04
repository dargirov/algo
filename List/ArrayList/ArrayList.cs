using System;
using System.Collections.Generic;

namespace List
{
    public class ArrayList<T> : IList<T>, IEnumerable<T>
    {
        private int size;
        private T[] array;
        private const int defaultCapacity = 16;
        private int capacity;
        private int enumeratorIndex;

        public ArrayList() : this(defaultCapacity)
        {
        }

        public ArrayList(int capacity)
        {
            this.capacity = capacity;
            this.Clear();
        }

        public int GetSize()
        {
            return this.size;
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > this.size)
            {
                throw new IndexOutOfRangeException();
            }

            this.EnsureCapacity(this.size + 1);
            Array.Copy(this.array, index, this.array, index + 1, this.size - index);
            this.array[index] = value;
            this.size++;
        }

        private void EnsureCapacity(int capacity)
        {
            if (array.Length < capacity)
            {
                T[] newArray = new T[this.capacity * 2];
                Array.Copy(this.array, newArray, this.capacity);
                this.array = newArray;
            }
        }

        public void Add(T value)
        {
            this.Insert(this.size, value);
        }

        public T Delete(int index)
        {
            this.CheckOutOfRange(index);
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            var oldValue = this.array[index];
            int copyFromIndex = index + 1;
            if (copyFromIndex < this.size)
            {
                Array.Copy(this.array, copyFromIndex, this.array, index, this.size - copyFromIndex);
            }

            this.size--;
            this.array[this.size] = default(T);
            return oldValue;
        }

        private void CheckOutOfRange(int index)
        {
            if (index < 0 || index >= this.size)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            this.array = new T[this.capacity];
            this.size = 0;
            this.enumeratorIndex = -1;
        }

        public T Set(int index, T value)
        {
            this.CheckOutOfRange(index);

            var oldValue = this.array[index];
            this.array[index] = value;
            return oldValue;
        }

        public T Get(int index)
        {
            this.CheckOutOfRange(index);

            return this.array[index];
        }

        public int IndexOf(T value)
        {
            int count = 0;
            foreach (var elem in this.array)
            {
                if (elem.Equals(value))
                {
                    return count;
                }

                count++;
            }

            return -1;
        }

        public bool Contains(T value)
        {
            return this.IndexOf(value) != -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int count = 0;
            foreach (var i in this.array)
            {
                if (count++ == this.size)
                {
                    break;
                }

                yield return i;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
