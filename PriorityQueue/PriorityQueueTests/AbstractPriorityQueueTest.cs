namespace PriorityQueueTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IQueue;

    [TestClass]
    public abstract class AbstractPriorityQueueTest
    {
        protected string ValueA
        {
            get { return "A"; }
        }

        protected string ValueB
        {
            get { return "B"; }
        }

        protected string ValueC
        {
            get { return "C"; }
        }

        protected string ValueD
        {
            get { return "D"; }
        }

        protected string ValueE
        {
            get { return "E"; }
        }

        protected abstract IQueue<string> CreateQueue();

        [TestMethod]
        public void AccessEmptyQueueTest()
        {
            var queue = this.CreateQueue();
            Assert.AreEqual(0, queue.GetSize());
            Assert.IsTrue(queue.IsEmpty());

            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        [TestMethod]
        public void EnqueueDequeueTest()
        {
            var queue = this.CreateQueue();
            queue.Enqueue(this.ValueA);
            queue.Enqueue(this.ValueD);
            queue.Enqueue(this.ValueB);

            Assert.AreEqual(3, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            Assert.AreEqual(this.ValueD, queue.Dequeue());
            Assert.AreEqual(2, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            Assert.AreEqual(this.ValueB, queue.Dequeue());
            Assert.AreEqual(1, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            queue.Enqueue(this.ValueE);
            Assert.AreEqual(2, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            Assert.AreEqual(this.ValueE, queue.Dequeue());
            Assert.AreEqual(1, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            Assert.AreEqual(this.ValueA, queue.Dequeue());
            Assert.AreEqual(0, queue.GetSize());
            Assert.IsTrue(queue.IsEmpty());
        }
    }
}
