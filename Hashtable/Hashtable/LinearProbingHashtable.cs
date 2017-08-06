using System;

namespace Hashtable
{
    public class LinearProbingHashtable<T> : IHashtable<T> where T : IComparable
    {
        private T[] _values;
        public int Size { get; private set; }

        public LinearProbingHashtable(int initialCapacity)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentException("Initial capacity cant be less than 1");
            }

            _values = new T[initialCapacity];
        }

        public void Add(T value)
        {
            EnsureCapacityForOneMore();
            int index = IndexFor(value);

            if (_values[index] == null)
            {
                _values[index] = value;
                Size++;
            }
        }

        private int IndexFor(T value)
        {
            int start = StartingIndexFor(value);
            int index = IndexFor(value, start, _values.GetLength(0));

            if (index == -1)
            {
                index = IndexFor(value, 0, start);
                if (index == -1)
                {
                    throw new Exception("No fee slot");
                }
            }

            return index;
        }

        private int IndexFor(T value, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (_values[i] == null || value.Equals(_values[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private int StartingIndexFor(T value)
        {
            return Math.Abs(value.GetHashCode() % _values.GetLength(0));
        }

        private void EnsureCapacityForOneMore()
        {
            if (Size == _values.GetLength(0))
            {
                Resize();
            }
        }

        private void Resize()
        {
            var copy = new LinearProbingHashtable<T>(_values.GetLength(0) * 2);

            for (int i = 0; i < _values.GetLength(0); i++)
            {
                if (_values[i] != null)
                {
                    copy.Add(_values[i]);
                }
            }

            _values = copy._values;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        private int IndexOf(T value)
        {
            int start = StartingIndexFor(value);
            int index = IndexOf(value, start, _values.GetLength(0));

            if (index == -1)
            {
                index = IndexOf(value, 0, start);
            }

            return index;
        }

        private int IndexOf(T value, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (value.Equals(_values[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
