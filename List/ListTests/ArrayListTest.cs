using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using List;

namespace ListTests
{
    [TestClass]
    public class ArrayListTest : AbstractListTest
    {
        public ArrayListTest()
        {
        }

        protected override IList<int> CreateList()
        {
            return new ArrayList<int>();
        }


        protected override IList<int> CreateList(int capacity)
        {
            return new ArrayList<int>(capacity);
        }

        [TestMethod]
        public void ResizeBeyondInitialCapacityTest()
        {
            IList<int> list = this.CreateList(4);
            list.Add(ValueA);
            list.Add(ValueB);
            list.Add(ValueC);
            list.Add(ValueA);
            list.Add(ValueB);
            list.Add(ValueC);

            Assert.AreEqual(6, list.GetSize());
            Assert.AreEqual(ValueA, list.Get(0));
            Assert.AreEqual(ValueB, list.Get(1));
            Assert.AreEqual(ValueC, list.Get(2));
            Assert.AreEqual(ValueA, list.Get(3));
            Assert.AreEqual(ValueB, list.Get(4));
            Assert.AreEqual(ValueC, list.Get(5));
        }
    }
}
