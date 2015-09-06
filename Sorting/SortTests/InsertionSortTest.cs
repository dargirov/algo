using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IListSorter;
using Insertion;

namespace SortTests
{
    [TestClass]
    public class InsertionSortTest : AbstractSorterTest
    {
        protected override IListSorter<string> CreateListSorter()
        {
            return new InsertionSortList<string>();
        }
    }
}
