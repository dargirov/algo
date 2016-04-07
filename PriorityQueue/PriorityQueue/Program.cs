namespace PriorityQueue
{
    using System;
    using HeapOrderedListPriorityQueue;
    using UnsortedListPriorityQueue;

    class Program
    {
        static void Main()
        {
            var queue = new HeapOrderedListPriorityQueue<int>();
            queue.Enqueue(4);
            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(7);
            queue.Enqueue(5);
            queue.Enqueue(2);
            queue.Enqueue(9);
            queue.Enqueue(8);
            queue.Enqueue(6);
            queue.Enqueue(1);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
