namespace IQueue
{
    public interface IQueue<T>
    {
        void Enqueue(T value);
        T Dequeue();
        void Clear();
        bool IsEmpty();
        int GetSize();
    }
}