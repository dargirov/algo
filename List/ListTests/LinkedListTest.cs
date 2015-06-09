using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using List;

namespace ListTests
{
    [TestClass]
    class LinkedListTest : AbstractListTest
    {
        protected override IList<int> CreateList()
        {
            //return new LinkedList<int>();
            throw new NotImplementedException();
        }

        protected override IList<int> CreateList(int capacity)
        {
            throw new NotImplementedException();
        }
    }
}
