using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using List;

namespace ListTests
{
    [TestClass]
    public class LinkedListTest : AbstractListTest
    {
        public LinkedListTest()
        {
        }

        protected override IList<int> CreateList()
        {
            return new LinkedList<int>();
        }

        protected override IList<int> CreateList(int capacity)
        {
            throw new NotImplementedException();
        }
    }
}
