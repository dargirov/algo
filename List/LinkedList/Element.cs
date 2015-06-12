using System;
using System.Collections.Generic;

namespace List
{
    public class Element<T>
    {
        private T value;
        private Element<T> next;
        private Element<T> previous;

        public Element(T value)
        {
            this.SetValue(value);
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public T GetValue()
        {
            return this.value;
        }

        public Element<T> GetPrevious()
        {
            return this.previous;
        }

        public void SetPrevious(Element<T> prev)
        {
            this.previous = prev;
        }

        public Element<T> GetNext()
        {
            return this.next;
        }

        public void SetNext(Element<T> next)
        {
            this.next = next;
        }

        public void AttachBefore(Element<T> next)
        {
            var previous = next.GetPrevious();
            this.SetNext(next);
            this.SetPrevious(previous);
            next.SetPrevious(this);
            previous.SetNext(this);
        }

        public void Detach()
        {
            this.previous.SetNext(this.next);
            this.next.SetPrevious(this.previous);
        }
    }
}
