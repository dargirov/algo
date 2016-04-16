namespace BinarySearchTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using IListSearcher;
    using RecursiveBinaryListSearcher;

    [TestClass]
    public class RecursiveBinaryListSearcherTests : AbstractListSearcherTest
    {
        protected override IListSearcher<string> CreateSearcher()
        {
            return new RecursiveBinaryListSearcher<string>();
        }
    }
}
