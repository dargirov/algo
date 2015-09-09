using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shell;
using IListSorter;

namespace SortTests
{
    [TestClass]
    public class ShellSortTest : AbstractSorterTest
    {
        public ShellSortTest()
        {
        }

        protected override IListSorter<string> CreateListSorter()
        {
            return new ShellSortList<string>();
        }
    }
}
