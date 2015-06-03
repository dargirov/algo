using System;

namespace List
{
    public class ArrayList : IList
    {
        private int size;
        private int[] array;
        private const int defaultCapacity = 16;
        private int capacity;

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

        public void Insert(int index, int value)
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
                int[] newArray = new int[this.capacity * 2];
                Array.Copy(this.array, newArray, this.capacity);
                this.array = newArray;
            }
        }

        public void Add(int value)
        {
            this.Insert(this.size, value);
        }

        public int Delete(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            this.array = new int[this.capacity];
            this.size = 0;
        }

        public int Set(int index, int value)
        {
            if (index < 0 || index >= this.size)
            {
                throw new IndexOutOfRangeException();
            }

            var oldValue = this.array[index];
            this.array[index] = value;
            return oldValue;
        }

        public int Get(int index)
        {
            if (index < 0 || index > this.size)
            {
                throw new IndexOutOfRangeException();
            }

            return this.array[index];
        }

        public int IndexOf(int value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int value)
        {
            throw new NotImplementedException();
        }
    }
}
