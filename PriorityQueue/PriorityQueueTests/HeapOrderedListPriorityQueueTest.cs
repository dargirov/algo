namespace PriorityQueueTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IQueue;
    using HeapOrderedListPriorityQueue;

    [TestClass]
    public class HeapOrderedListPriorityQueueTest : AbstractPriorityQueueTest
    {
        protected override IQueue<string> CreateQueue()
        {
            return new HeapOrderedListPriorityQueue<string>();
        }
    }
}
