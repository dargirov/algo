using System;
using System.Collections.Generic;

namespace IStack
{
    public interface IStack<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        void Clear();
        int GetSize();
        bool IsEmpty();
    }
}
