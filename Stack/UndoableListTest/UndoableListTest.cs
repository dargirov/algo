using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListTests;
using List;
using UndoableList;

namespace UndoableListTest
{
    [TestClass]
    public class UndoableListTest : AbstractListTest
    {
        public UndoableListTest()
        {
        }


        [TestMethod]
        public void UndoInsertTest()
        {
            var list = new UndoableList<int>(new LinkedList<int>());

            Assert.IsFalse(list.CanUndo());

            list.Insert(0, this.ValueA);
            Assert.IsTrue(list.CanUndo());

            list.Undo();
            Assert.AreEqual(0, list.GetSize());
            Assert.IsFalse(list.CanUndo());
        }

        [TestMethod]
        public void UndoAddTest()
        {
            var list = new UndoableList<int>(new LinkedList<int>());

            Assert.IsFalse(list.CanUndo());

            list.Add(this.ValueA);
            Assert.IsTrue(list.CanUndo());

            list.Undo();
            Assert.AreEqual(0, list.GetSize());
            Assert.IsFalse(list.CanUndo());
        }

        [TestMethod]
        public void UndoDeleteByPosition()
        {
            var list = new UndoableList<int>(new LinkedList<int>());
            list.Add(this.ValueA);
            list.Add(this.ValueB);

            Assert.AreEqual(this.ValueB, list.Delete(1));
            Assert.IsTrue(list.CanUndo());

            list.Undo();

            Assert.AreEqual(2, list.GetSize());
            Assert.AreEqual(this.ValueA, list.Get(0));
            Assert.AreEqual(this.ValueB, list.Get(1));
            Assert.IsTrue(list.CanUndo());
        }

        [TestMethod]
        public void UndoSetTest()
        {
            var list = new UndoableList<int>(new LinkedList<int>());
            list.Add(this.ValueA);
            Assert.AreEqual(this.ValueA, list.Get(0));
            list.Set(0, this.ValueB);
            Assert.AreEqual(this.ValueB, list.Get(0));

            list.Undo();
            Assert.AreEqual(this.ValueA, list.Get(0));
        }

        protected override IList<int> CreateList()
        {
            throw new NotImplementedException();
        }

        protected override IList<int> CreateList(int capacity)
        {
            throw new NotImplementedException();
        }
    }
}
