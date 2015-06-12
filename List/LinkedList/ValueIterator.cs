using System;
using System.Collections.Generic;

namespace List
{
    public class ValueIterator<T> : IIterator<T>
    {
        private Element<T> current;
        private Element<T> headAndTail;

        public ValueIterator(Element<T> headAndTail)
        {
            this.current = this.headAndTail = headAndTail;
        }

        public void First()
        {
            this.current = this.headAndTail.GetNext();
        }

        public void Last()
        {
            this.current = this.headAndTail.GetPrevious();
        }

        public bool IsDone()
        {
            return this.current == this.headAndTail;
        }

        public void Next()
        {
            this.current = this.current.GetNext();
        }

        public void Previous()
        {
            this.current = this.current.GetPrevious();
        }

        public T Current()
        {
            if (this.IsDone())
            {
                throw new IndexOutOfRangeException();
            }

            return this.current.GetValue();
        }
    }
}
