using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IQueue;
using ListQueue;

namespace QueueTests
{
    [TestClass]
    public class ListQueueTest: AbstractQueueTest
    {
        protected override IQueue<int> CreateQueue()
        {
            return new ListQueue<int>();
        }
    }
}
