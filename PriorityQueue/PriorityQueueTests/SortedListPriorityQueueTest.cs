namespace PriorityQueueTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IQueue;
    using SortedListPriorityQueue;

    [TestClass]
    public class SortedListPriorityQueueTest : AbstractPriorityQueueTest
    {
        protected override IQueue<string> CreateQueue()
        {
            return new SortedListPriorityQueue<string>();
        }
    }
}
