using System;
using System.Collections.Generic;

namespace List
{
    public class LinkedList<T> : IList<T>
    {
        private Element<T> headAndTail;
        private int size;

        public LinkedList()
        {
            this.headAndTail = new Element<T>(default(T));
            this.Clear();
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > this.GetSize())
            {
                throw new IndexOutOfRangeException();
            }

            var element = new Element<T>(value);
            element.AttachBefore(this.GetElement(index));
            this.size++;
        }

        private Element<T> GetElement(int index)
        {
            var element = this.headAndTail.GetNext();
            for (int i = index; i > 0; i--)
            {
                element = element.GetNext();
            }

            return element;
        }

        public void Add(T value)
        {
            this.Insert(this.GetSize(), value);
        }

        private void CheckOutOfRange(int index)
        {
            if (index < 0 || index >= this.GetSize())
            {
                throw new IndexOutOfRangeException();
            }
        }


        public T Delete(int index)
        {
            this.CheckOutOfRange(index);

            var element = this.GetElement(index);
            element.Detach();
            this.size--;
            return element.GetValue();
        }

        public void Clear()
        {
            this.headAndTail.SetNext(this.headAndTail);
            this.headAndTail.SetPrevious(this.headAndTail);
            this.size = 0;
        }

        public T Set(int index, T value)
        {
            this.CheckOutOfRange(index);

            var element = this.GetElement(index);
            var oldValue = element.GetValue();
            element.SetValue(value);
            return oldValue;
        }

        public T Get(int index)
        {
            this.CheckOutOfRange(index);

            return this.GetElement(index).GetValue();
        }

        public int IndexOf(T value)
        {
            var index = 0;
            for (var element = this.headAndTail.GetNext(); element != this.headAndTail; element = element.GetNext())
            {
                if (value.Equals(element.GetValue()))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public bool Contains(T value)
        {
            return this.IndexOf(value) != -1;
        }

        public int GetSize()
        {
            return this.size;
        }

        public bool IsEmpty()
        {
            return this.GetSize() == 0;
        }

        public IIterator<T> Iterator()
        {
            return new ValueIterator<T>(this.headAndTail);
        }
    }
}
