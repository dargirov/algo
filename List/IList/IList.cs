namespace List
{
    public interface IList
    {
        void Insert(int index, int value);
        void Add(int value);
        int Delete(int index);
        void Clear();
        int Set(int index, int value);
        int Get(int index);
        int IndexOf(int value);
        bool Contains(int value);
        int GetSize();
        bool IsEmpty();
    }
}
