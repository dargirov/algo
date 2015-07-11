using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IStack;

namespace StackTest
{
    [TestClass]
    public abstract class AbstractStackTest
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

        protected abstract IStack<int> CreateStack();

        [TestMethod]
        public virtual void PushAndPopTest()
        {
            IStack<int> stack = this.CreateStack();
            stack.Push(this.ValueA);
            stack.Push(this.ValueB);
            stack.Push(this.ValueC);

            Assert.AreEqual(3, stack.GetSize());
            Assert.IsFalse(stack.IsEmpty());

            Assert.AreEqual(this.ValueC, stack.Pop());
            Assert.AreEqual(2, stack.GetSize());
            Assert.IsFalse(stack.IsEmpty());

            Assert.AreEqual(this.ValueB, stack.Pop());
            Assert.AreEqual(1, stack.GetSize());
            Assert.IsFalse(stack.IsEmpty());

            Assert.AreEqual(this.ValueA, stack.Pop());
            Assert.AreEqual(0, stack.GetSize());
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public virtual void PopFromEmptyStackTest()
        {
            IStack<int> stack = this.CreateStack();
            Assert.AreEqual(0, stack.GetSize());
            Assert.IsTrue(stack.IsEmpty());
            try
            {
                stack.Pop();
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        [TestMethod]
        public virtual void PeekTest()
        {
            IStack<int> stack = this.CreateStack();
            stack.Push(this.ValueA);
            stack.Push(this.ValueB);

            Assert.AreEqual(2, stack.GetSize());
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(this.ValueB, stack.Peek());
            Assert.AreEqual(2, stack.GetSize());
        }

        [TestMethod]
        public virtual void PeekIntoEmptyStackTest()
        {
            IStack<int> stack = this.CreateStack();
            Assert.AreEqual(0, stack.GetSize());
            Assert.IsTrue(stack.IsEmpty());
            try
            {
                stack.Peek();
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        [TestMethod]
        public virtual void ClearTest()
        {
            IStack<int> stack = this.CreateStack();
            stack.Push(this.ValueA);
            stack.Push(this.ValueB);
            stack.Push(this.ValueC);

            Assert.AreEqual(3, stack.GetSize());
            Assert.IsFalse(stack.IsEmpty());
            
            stack.Clear();
            
            Assert.AreEqual(0, stack.GetSize());
            Assert.IsTrue(stack.IsEmpty());

            try
            {
                stack.Pop();
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }
    }
}
