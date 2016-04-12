namespace BinarySearchTests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IListSearcher;

    [TestClass]
    public abstract class AbstractListSearcherTest
    {
        private static string[] values = { "B", "C", "D", "F", "H", "I", "J", "K", "L", "M", "P", "Q" };
        private List<string> list;
        private IListSearcher<string> searcher;

        protected abstract IListSearcher<string> CreateSearcher();

        protected void Setup()
        {
            this.searcher = this.CreateSearcher();
            this.list = new List<string>(values);
        }

        [TestMethod]
        public void SearchForExistingValuesTest()
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                Assert.AreEqual(i, this.searcher.Search(this.list, this.list[i]));
            }
        }
    }
}
