using System;
using IQueue;
using ListQueue;
using BlockingQueue;

namespace Queue
{
    class Program
    {
        static void Main()
        {
            IQueue<int> queue = new BlockingQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("{0}, {1}, {2}", queue.Dequeue(), queue.Dequeue(), queue.Dequeue());
        }
    }
}
