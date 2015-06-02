using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using List;

namespace ListTests
{
    //[TestClass]
    public abstract class AbstractListTest
    {
        protected static int ValueA 
        {
            get { return 1; }
        }

        protected static int ValueB
        {
            get { return 2; }
        }

        protected static int ValueC
        {
            get { return 3; }
        }
    
        //[TestMethod]
        public virtual IList CreateList();
    }

    [TestClass]
    public class ArrayListTest : AbstractListTest
    {
        public IList CreateList()
        {
            return new ArrayList();
        }
    }
}
