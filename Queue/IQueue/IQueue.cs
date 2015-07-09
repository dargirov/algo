namespace IQueue
{
    public interface IQueue<T>
    {
        void enqueue(T value);
        T dequeue();
        void Clear();
        bool IsEmpty();
        int GetSize();
    }
}
