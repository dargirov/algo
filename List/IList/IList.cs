namespace List
{
    public interface IList<T> : IIterable<T>
    {
        void Insert(int index, T value);
        void Add(T value);
        T Delete(int index);
        void Clear();
        T Set(int index, T value);
        T Get(int index);
        int IndexOf(T value);
        bool Contains(T value);
        int GetSize();
        bool IsEmpty();
    }
}
