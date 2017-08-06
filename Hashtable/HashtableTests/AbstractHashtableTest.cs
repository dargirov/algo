using Hashtable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashtableTests
{
    [TestClass]
    public abstract class AbstrcatHashtableTest
    {
        private const int testSize = 1000;
        private IHashtable<string> _hashtable;

        protected abstract IHashtable<string> CreateTable(int capacity);

        [TestInitialize]
        public void Setup()
        {
            _hashtable = CreateTable(testSize);

            for (int i = 0; i < testSize; i++)
            {
                _hashtable.Add(i.ToString());
            }
        }

        [TestMethod]
        public void Contains()
        {
            for (int i = 0; i < testSize; i++)
            {
                Assert.IsTrue(_hashtable.Contains(i.ToString()));
            }
        }

        [TestMethod]
        public void DosNotContain()
        {
            for (int i = 0; i < testSize; i++)
            {
                Assert.IsFalse(_hashtable.Contains((i + testSize).ToString()));
            }
        }

        [TestMethod]
        public void AddingTheSameValueDoesNotChangeTheSize()
        {
            Assert.AreEqual(testSize, _hashtable.Size);

            for (int i = 0; i < testSize; i++)
            {
                _hashtable.Add(i.ToString());
                Assert.AreEqual(testSize, _hashtable.Size);
            }
        }
    }
}
