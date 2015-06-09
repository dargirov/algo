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
    
        protected abstract IList<int> CreateList();

        protected abstract IList<int> CreateList(int capacity);

        [TestMethod]
        public virtual void InsertIntoEmptyListTest()
        {
            IList<int> list = this.CreateList();
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
            IList<int> list = this.CreateList();
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
            IList<int> list = this.CreateList();
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
            IList<int> list = this.CreateList();
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
            IList<int> list = this.CreateList();

            try
            {
                list.Insert(-1, this.ValueA);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            try
            {
                list.Insert(1, this.ValueA);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        [TestMethod]
        public virtual void SetTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            
            Assert.AreEqual(ValueA, list.Set(0, ValueB));
            Assert.AreEqual(ValueB, list.Get(0));
        }

        [TestMethod]
        public virtual void SetOutOfRangeTest()
        {
            IList<int> list = this.CreateList();

            try
            {
                list.Set(-1, ValueA);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            try
            {
                list.Set(0, ValueA);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            try
            {
                list.Set(1, ValueA);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            list.Add(this.ValueA);
            try
            {
                list.Set(1, ValueB);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        [TestMethod]
        public virtual void DeleteOnlyElementTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            list.Delete(0);

            Assert.AreEqual(0, list.GetSize());
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public virtual void DeleteFirstElementTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            list.Add(ValueB);
            list.Add(ValueC);

            list.Delete(0);
            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(ValueB, list.Get(0));
            Assert.AreEqual(ValueC, list.Get(1));
        }

        [TestMethod]
        public virtual void DeleteLastElementTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            list.Add(ValueB);
            list.Add(ValueC);

            Assert.AreEqual(3, list.GetSize());

            list.Delete(2);

            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(ValueA, list.Get(0));
            Assert.AreEqual(ValueB, list.Get(1));
        }

        [TestMethod]
        public virtual void DeleteOutOfRangeTest()
        {
            IList<int> list = this.CreateList();
            
            try
            {
                list.Delete(0);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            list.Add(ValueA);

            try
            {
                list.Delete(1);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }

            var value = list.Delete(0);
            Assert.AreEqual(ValueA, value);

            try
            {
                list.Delete(0);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        [TestMethod]
        public virtual void DeleteMiddleElementTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            list.Add(ValueB);
            list.Add(ValueC);

            list.Delete(1);

            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(ValueA, list.Get(0));
            Assert.AreEqual(ValueC, list.Get(1));
        }

        [TestMethod]
        public virtual void IndexOfTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            list.Add(ValueB);
            list.Add(ValueA);

            Assert.AreEqual(0, list.IndexOf(ValueA));
            Assert.AreEqual(1, list.IndexOf(ValueB));
            Assert.AreEqual(-1, list.IndexOf(ValueC));
        }

        [TestMethod]
        public virtual void ContainsTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            list.Add(ValueB);

            Assert.IsTrue(list.Contains(ValueA));
            Assert.IsTrue(list.Contains(ValueB));
            Assert.IsFalse(list.Contains(ValueC));
        }

        [TestMethod]
        public virtual void ClearListTest()
        {
            IList<int> list = this.CreateList();
            list.Add(ValueA);
            list.Add(ValueB);
            list.Add(ValueB);
            list.Add(ValueA);
            list.Add(ValueC);

            Assert.AreEqual(5, list.GetSize());
            
            list.Clear();

            Assert.AreEqual(0, list.GetSize());
            Assert.IsTrue(list.IsEmpty());
        }
    }

    
}
