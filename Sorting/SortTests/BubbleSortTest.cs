using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IListSorter;
using Bubble;

namespace SortTests
{
    [TestClass]
    public class BubbleSortTest : AbstractSorterTest
    {
        public BubbleSortTest()
        {
        }


        protected override IListSorter<string> CreateListSorter()
        {
            return new Bubble<string>();
        }
    }
}
