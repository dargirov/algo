using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using List;

namespace ListTests
{
    [TestClass]
    public abstract class AbstractListTest
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
    
        protected abstract IList CreateList();

        [TestMethod]
        public virtual void InsertIntoEmptyListTest()
        {
            IList list = this.CreateList();
            Assert.AreEqual(0, list.GetSize());
            Assert.IsTrue(list.IsEmpty());

            list.Add(this.ValueA);

            Assert.AreEqual(1, list.GetSize());
            Assert.IsTrue(!list.IsEmpty());
            Assert.AreEqual(this.ValueA, list.Get(0));
        }

        [TestMethod]
        public virtual void InserBetweenElementsTest()
        {
            IList list = this.CreateList();
            list.Add(this.ValueA);
            list.Add(this.ValueC);

            Assert.AreEqual(2, list.GetSize());

            list.Insert(1, ValueB);

            Assert.AreEqual(3, list.GetSize());
            Assert.AreEqual(this.ValueA, list.Get(0));
            Assert.AreEqual(this.ValueB, list.Get(1));
            Assert.AreEqual(this.ValueC, list.Get(2));
        }

        [TestMethod]
        public virtual void InsertBeforeFirstTest()
        {
            IList list = this.CreateList();
            list.Add(ValueB);
            list.Add(ValueC);
            list.Insert(0, ValueA);

            Assert.AreEqual(3, list.GetSize());
            Assert.AreEqual(this.ValueA, list.Get(0));
            Assert.AreEqual(this.ValueB, list.Get(1));
            Assert.AreEqual(this.ValueC, list.Get(2));
        }

        [TestMethod]
        public virtual void InserAfterLastTest()
        {
            IList list = this.CreateList();
            list.Add(ValueA);
            list.Add(ValueB);

            Assert.AreEqual(2, list.GetSize());

            list.Insert(2, ValueC);

            Assert.AreEqual(3, list.GetSize());
            Assert.AreEqual(this.ValueA, list.Get(0));
            Assert.AreEqual(this.ValueB, list.Get(1));
            Assert.AreEqual(this.ValueC, list.Get(2));
        }

        [TestMethod]
        public virtual void InsertOutOfRangeTest()
        {
            IList list = this.CreateList();

            try
            {
                list.Insert(-1, this.ValueA);
            }
            catch (IndexOutOfRangeException e)
            {
            }

            try
            {
                list.Insert(1, this.ValueA);
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        [TestMethod]
        public virtual void SetTest()
        {
            IList list = this.CreateList();
            list.Add(ValueA);
            
            Assert.AreEqual(ValueA, list.Set(0, ValueB));
            Assert.AreEqual(ValueB, list.Get(0));
        }

        [TestMethod]
        public virtual void SetOutOfRangeTest()
        {
            IList list = this.CreateList();

            try
            {
                list.Set(-1, ValueA);
            }
            catch (IndexOutOfRangeException e)
            {
            }

            try
            {
                list.Set(0, ValueA);
            }
            catch (IndexOutOfRangeException e)
            {
            }

            try
            {
                list.Set(1, ValueA);
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }
    }

    [TestClass]
    public class ArrayListTest : AbstractListTest
    {
        public ArrayListTest()
        {
            //this.list = this.CreateList();
        }

        protected override IList CreateList()
        {
            return new ArrayList();
        }

    }
}
