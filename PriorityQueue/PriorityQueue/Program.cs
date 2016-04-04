namespace PriorityQueue
{
    using System;
    using UnsortedListPriorityQueue;

    class Program
    {
        static void Main()
        {
            var queue = new UnsortedListPriorityQueue<string>();
            queue.Enqueue("Ivan");
            queue.Enqueue("Argirov");
            queue.Enqueue("Yordan");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
