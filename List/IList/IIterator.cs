using System;
using System.Collections.Generic;

namespace List
{
    public interface IIterator<T>
    {
        void First();
        void Last();
        bool IsDone();
        void Next();
        void Previus();
        T Current();
    }
}
