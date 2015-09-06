using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IListSorter;

using Selection;

namespace SortTests
{
    [TestClass]
    public class SelectionSortTest : AbstractSorterTest
    {
        public SelectionSortTest()
        {
        }

        protected override IListSorter<string> CreateListSorter()
        {
            return new SelectionSortList<string>();
        }
    }
}
