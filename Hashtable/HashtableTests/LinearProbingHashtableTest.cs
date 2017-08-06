using Hashtable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashtableTests
{
    [TestClass]
    public class LinearProbingHashtableTest : AbstrcatHashtableTest
    {
        protected override IHashtable<string> CreateTable(int capacity)
        {
            return new LinearProbingHashtable<string>(capacity);
        }
    }
}
