using System;

namespace Hashtable
{
    public interface IHashtable<T> where T : IComparable
    {
        void Add(T value);
        bool Contains(T value);
        int Size { get; }
    }
}
