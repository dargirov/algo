using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IQueue;

namespace QueueTests
{
    [TestClass]
    public abstract class AbstractQueueTest
    {
        protected int ValueA
        {
            get { return 1; }
        }

        protected int ValueB
        {
            get { return 2; }
        }

        protected int ValueC
        {
            get { return 3; }
        }

        protected abstract IQueue<int> CreateQueue();

        [TestMethod]
        public virtual void AccessEmptyQueueTest()
        {
            IQueue<int> queue = this.CreateQueue();
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
        public virtual void EnqueueDequeueTest()
        {
            IQueue<int> queue = this.CreateQueue();
            queue.Enqueue(this.ValueA);
            queue.Enqueue(this.ValueB);
            queue.Enqueue(this.ValueC);

            Assert.AreEqual(3, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            Assert.AreEqual(ValueA, queue.Dequeue());
            Assert.AreEqual(2, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            Assert.AreEqual(ValueB, queue.Dequeue());
            Assert.AreEqual(1, queue.GetSize());
            Assert.IsFalse(queue.IsEmpty());

            Assert.AreEqual(ValueC, queue.Dequeue());
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
        public virtual void ClearTest()
        {
            IQueue<int> queue = this.CreateQueue();
            queue.Enqueue(this.ValueA);
            queue.Enqueue(this.ValueB);
            queue.Enqueue(this.ValueC);

            queue.Clear();

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
    }
}
