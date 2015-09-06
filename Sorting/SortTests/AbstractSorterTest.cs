using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using IListSorter;

namespace SortTests
{
    [TestClass]
    public abstract class AbstractSorterTest
    {
        private IList<string> unsortedList;
        private IList<string> sortedList;

        protected void Setup()
        {
            this.unsortedList = new List<string>();
            this.sortedList = new List<string>();

            this.unsortedList.Add("this");
            this.unsortedList.Add("is");
            this.unsortedList.Add("just");
            this.unsortedList.Add("a");
            this.unsortedList.Add("simple");
            this.unsortedList.Add("test");
            this.unsortedList.Add("for");
            this.unsortedList.Add("sorting");
            this.unsortedList.Add("lists");

            this.sortedList.Add("a");
            this.sortedList.Add("for");
            this.sortedList.Add("is");
            this.sortedList.Add("just");
            this.sortedList.Add("lists");
            this.sortedList.Add("simple");
            this.sortedList.Add("sorting");
            this.sortedList.Add("test");
            this.sortedList.Add("this");
        }

        protected void Teardown()
        {
            this.unsortedList = null;
            this.sortedList = null;
        }

        protected abstract IListSorter<string> CreateListSorter();

        [TestMethod]
        public void sortSampleListTest()
        {
            IListSorter<string> sorter = this.CreateListSorter();
            this.Setup();
            var result = sorter.Sort(this.unsortedList);

            Assert.AreEqual(result.Count, this.unsortedList.Count);

            for (int i = 0; i < this.sortedList.Count; i++)
            {
                Assert.AreEqual(this.sortedList[i], result[i]);
            }
        }
    }
}
