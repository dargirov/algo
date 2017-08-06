using Hashtable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashtableTests
{
    [TestClass]
    public class BucketingHashtableTest : AbstrcatHashtableTest
    {
        protected override IHashtable<string> CreateTable(int capacity)
        {
            return new BucketingHashtable<string>(capacity, 0.75);
        }
    }
}
