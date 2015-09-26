using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IListSorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Quick;

namespace SortTests
{
    [TestClass]
    public class QuickSortTest : AbstractSorterTest
    {
        protected override IListSorter<string> CreateListSorter()
        {
            return new QuickSortList<string>();
        }
    }
}
