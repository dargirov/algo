using System;
using System.Collections.Generic;

namespace List
{
    public interface IIterable<T>
    {
        IIterator<T> Iterator();
    }
}
