namespace PriorityQueueTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IQueue;
    using UnsortedListPriorityQueue;

    [TestClass]
    public class UnsortedListPriorityQueueTest : AbstractPriorityQueueTest
    {
        protected override IQueue<string> CreateQueue()
        {
            return new UnsortedListPriorityQueue<string>();
        }
    }
}
