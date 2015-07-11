using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListStack;

namespace StackTest
{
    [TestClass]
    public class ListStackTest: AbstractStackTest
    {
        protected override IStack.IStack<int> CreateStack()
        {
            return new ListStack<int>();
        }
    }
}
